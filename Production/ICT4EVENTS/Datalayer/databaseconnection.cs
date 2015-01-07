using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class DatabaseConnection
    {

        private OracleConnection conn;

        public DatabaseConnection()
        {
            this.conn = new OracleConnection();
            this.conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            this.conn.Open();
            this.conn.Close();
        }

        public void UpdatePresence(string barcode)
        {
            OracleCommand cmd = new OracleCommand("Aanwezigheid", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //Ad parameter list--
            cmd.Parameters.Add("rfiduser", "nvarchar2").Value = barcode;
            cmd.ExecuteNonQuery();

        }

        public void FillDataGrid(GridView d)
        {

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_myOracle";
                OracleParameter oraP = new OracleParameter();
                oraP.OracleDbType = OracleDbType.RefCursor;
                oraP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(oraP);
                DataSet ds = new DataSet();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    d.DataSource = ds;
                    d.DataBind();
                }


            }
            catch (Exception ex)
            {


            }
            finally
            {
                conn.Close();
            }

        }


        public string GetAccountInfo(string barcode)
        {
            string result = " ";



            OracleCommand cmd = new OracleCommand("GetAccountInfo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("v_totaal", OracleDbType.Varchar2, 100).Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("rfid", OracleDbType.NVarchar2).Value = barcode;


                conn.Open();
                cmd.ExecuteNonQuery();

                result = Convert.ToString(cmd.Parameters["v_totaal"].Value);


                return result;

            }
            catch (OracleException OE)
            {

            }
            finally
            {

                conn.Close();
            }

            return result;
        }

        public string CheckBarcode(string barcodevalue)
        {
            string result = " ";



            OracleCommand cmd = new OracleCommand("CheckRFIDS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("v_Result", OracleDbType.Varchar2, 255).Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("barcode_id", OracleDbType.NVarchar2).Value = barcodevalue;

                conn.Open();
                cmd.ExecuteNonQuery();

                result = Convert.ToString(cmd.Parameters["v_Result"].Value);

                if (result.Contains("RFID_FOUND!"))
                {
                    UpdatePresence(barcodevalue);
                }

                return result;



            }
            catch (OracleException OE)
            {

            }
            finally
            {

                cmd.Connection.Close();
            }

            return result;
        }

        ///Methods of the Log-in page
        ///
        public string getUserGroup(string username)
        {
            OracleCommand cmd = this.conn.CreateCommand();
            cmd.CommandText = "SELECT \"gebruikersgroep_id\" FROM ACCOUNT WHERE \"gebruikersnaam\" = :SELUSERNAME";
            cmd.Parameters.Add("SELUSERNAME", username);
            string result = "";
            try
            {
                this.conn.Open();
                result = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (OracleException exc)
            {
                Console.Write(exc);
            }
            finally
            {
                this.conn.Close();
            }

            return result;
        }

        /////EVENTS


        public List<string> Locations()
        {
            List<string> Locations = new List<string>();
            try
            {
                string queryString = "select \"naam\" from locatie";



                OracleCommand cmd = new OracleCommand(queryString, this.conn);


                this.conn.Open();

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Locations.Add(reader.GetString(0));
                    }
                }
            }
            catch
            {

            }
            finally
            {
                this.conn.Close();
            }
            return Locations;
        }

        public void CreateEvent(string naam, DateTime start, DateTime eind, int max)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText =
                    "INSERT INTO EVENT(\"locatie_id\",\"naam\", \"datumstart\", \"datumEinde\", \"maxBezoekers\") VALUES (1,:naam, :startd, :eindd, :bezoek)";
                cmd.Parameters.Add("naam", naam);
                cmd.Parameters.Add("startd", start);
                cmd.Parameters.Add("eindd", eind);
                cmd.Parameters.Add("bezoek", max);

                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException e)
            {

            }
            finally
            {
                this.conn.Close();
            }

        }

        public DataSet GetEvents()
        {
            string queryString =
                "Select l.\"naam\" as Locatie, e.\"naam\" as Naam, e.\"datumstart\" As BeginDatum, e.\"datumEinde\" as EindDatum, e.\"maxBezoekers\" as MaxBezoekers From Event e, Locatie l";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);


            this.conn.Open();

            DataSet ds = new DataSet();

            try
            {
                // Fill the DataSet.
                adapter.Fill(ds);

            }
            catch (OracleException e)
            {
                // The connection failed. Display an error message            
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
    }
}
