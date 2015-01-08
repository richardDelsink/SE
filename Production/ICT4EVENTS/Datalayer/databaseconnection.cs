﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using System.Text;
using System.Web;
using System.Threading.Tasks;


namespace Datalayer
{
    public class DatabaseConnection
    {

        private OracleConnection conn;

        public DatabaseConnection()
        {
            //Oude proftaak connection
            //conn = new OracleConnection();
            //string user = "SYSTEM";
            //string pw = "proftaak";
            //conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //192.168.21.142:1521/" + ";";
            
            //vdi.fhict connection van iemand
            this.conn = new OracleConnection();
            string user = "dbi306956"; // zie email voor logingegevens
            string pw = "kyqSZFxe7N";
            this.conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //192.168.15.50:1521/fhictora" + ";";

            //Locale connectie hieronder
            /*conn = new OracleConnection();
            String user = "SYSTEM";
            String pw = "qwe123";
            conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //localhost:1521/xe" + ";"; */
            //orcl is de servicename (kan anders zijn, is afhankelijk van de Oracle server die geinstalleerd is. Mogelijk is ook Oracle Express: xe
            

            //dafuq is this shit
            //this.conn = new OracleConnection();
            //this.conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //this.conn.Open();
            //this.conn.Close();
        }

        public void UpdatePresence(string barcode)
        {
            OracleCommand cmd = new OracleCommand("Aanwezigheid", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //Ad parameter list--
            cmd.Parameters.Add("rfiduser", "nvarchar2").Value = barcode;
            cmd.ExecuteNonQuery();

        }

        public void MaterialGrid(GridView gv)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT p.id,\"merk\", \"serie\",\"naam\", \"prijs\" FROM productexemplaar pe, product p, productcat pc WHERE pe.\"product_id\" = p.\"productcat_id\" AND p.ID = pc.ID";
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable ds = new DataTable();
                adapter.Fill(ds);
                gv.DataSource = ds;
                gv.DataBind();
                


            }
            catch (Exception ex)
            {
                Console.ReadLine();

            }
            finally
            {
                conn.Close();
            }
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

                if (result.Contains("RFID_Found!"))
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

        ///Methods of the Log-in/Registration page
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

        public bool checkForReservation(string firstname, string lastname)
        {
            OracleCommand cmd = this.conn.CreateCommand();
            cmd.CommandText = "SELECT \"voornaam\" FROM persoon WHERE \"voornaam\" = :SELFIRSTNAME AND \"achternaam\" = :SELLASTNAME";
            cmd.Parameters.Add("SELFIRSTNAME", firstname);
            cmd.Parameters.Add("SELLASTNAME", lastname);
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

            if(result != "")
            {
                return true;
            }
            return false;
        }
        public void addAccount(string email, string username, string wachtwoord)
        {
            try
            {
                Random rnd =new Random();
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "INSERT INTO ACCOUNT(\"gebruikersgroep_id\", \"gebruikersnaam\", \"wachtwoord\", \"email\", \"activatiehash\", \"geactiveerd\") VALUES (:gebrgroep, :gebruikersnaam, :wachtwoord, :email, :activatiehash, :geactiveerd)";
                cmd.Parameters.Add("gebrgroep", "2");
                cmd.Parameters.Add("gebruikersnaam", username);
                cmd.Parameters.Add("wachtwoord", wachtwoord);
                cmd.Parameters.Add("email", email);
                cmd.Parameters.Add("activatiehash", rnd.Next(1, 9999999).ToString());
                cmd.Parameters.Add("geactiveerd", "1");

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
        public bool usernameExistsCheck(string username)
        {
            OracleCommand cmd = this.conn.CreateCommand();
            cmd.CommandText = "SELECT \"gebruikersnaam\" FROM account WHERE \"gebruikersnaam\" = :SELFIRSTNAME";
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

            if (result != "")
            {
                return true;
            }
            return false;
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

        public void CreateEvent(string naam, DateTime start, DateTime eind, int max, string locatie)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText ="INSERT INTO EVENT(\"locatie_id\",\"naam\", \"datumstart\", \"datumEinde\", \"maxBezoekers\") VALUES (:loc ,:naam, :startd, :eindd, :bezoek)";
                cmd.Parameters.Add("loc", locatieID(locatie));
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

        public int locatieID(string naam)
        {
            int locatieid = 0;
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText ="Select \"ID\" From locatie where \"naam\"= :naam";
                cmd.Parameters.Add("naam", naam);

                this.conn.Open();
                locatieid = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (OracleException e)
            {

            }
            finally
            {
                this.conn.Close();
            }
            return locatieid;
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

        public List<string> Getplaces()
        {
            List<string> places = new List<string>();
            try
            {

                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "SELECT \"plek_id\" FROM PLEK_RESERVERING";
                this.conn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    places.Add(dr.GetInt16(0).ToString());
                }
            }
            catch (OracleException exc)
            {

            }
            finally
            {
                this.conn.Close();
            }
            return places;
        }

        public void AddPerson(string voornaam, string tussenvoegsel, string achternaam, string straat, string huisnr, string woonplaats, string banknr)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();

                cmd.CommandText = "INSERT INTO PERSOON(\"voornaam\",\"tussenvoegsel\",\"achternaam\",\"straat\",\"huisnr\",\"woonplaats\",\"banknr\") VALUES(:voornaam,:tussenvoegsel,:achternaam,:straat,:huisnr,:woonplaats,:banknr)";
                cmd.Parameters.Add("voornaam", voornaam);
                cmd.Parameters.Add("tussenvoegsel", tussenvoegsel);
                cmd.Parameters.Add("achternaam", achternaam);
                cmd.Parameters.Add("straat", straat);
                cmd.Parameters.Add("huisnr", huisnr);
                cmd.Parameters.Add("woonplaats", woonplaats);
                cmd.Parameters.Add("banknr", banknr);

                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException exc)
            {
            }
            finally
            {
                this.conn.Close();
            }
        }

        public void AddReservering(int persoon, DateTime startdate, DateTime enddate, int betaald)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();

                cmd.CommandText = "INSERT INTO RESERVERING(persoon_id,datumStart, datumEinde, betaald) VALUES(:persoon_id,:datumStart, :datumEinde, :betaald)";
                cmd.Parameters.Add("voornaam", persoon);
                cmd.Parameters.Add("tussenvoegsel", startdate);
                cmd.Parameters.Add("achternaam", enddate);
                cmd.Parameters.Add("straat", betaald);

                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException exc)
            {
            }
            finally
            {
                this.conn.Close();
            }
        }

        public string Getcategory(int id)
        {
            string category = string.Empty;
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select naam from Categorie where Categorie_ID='" + id + "';";
            try
            {
                this.conn.Open();
                category = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (OracleException exception)
            {
                Console.WriteLine(exception);

            }
            finally
            {
                this.conn.Close();
            }
            return category;
        }

        public void addbericht(int accountid, string titel, string inhoud)
        {
            OracleCommand cmd = this.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO BERICHT VALUES(TITEL,INHOUD)";
            cmd.Parameters.Add("TITEL", titel);
            cmd.Parameters.Add("INHOUD", inhoud);
        }

        public void addbijdrage(int accountid, DateTime now, string bijdragesoort)
        {
            OracleCommand cmd = this.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO BIJDRAGE VALUES(ACCOUNTID,DATUM,SOORT);";
            cmd.Parameters.Add("ACCOUNTID", accountid);
            cmd.Parameters.Add("DATUM", now);
            cmd.Parameters.Add("SOORT", bijdragesoort);
            try
            {
                this.conn.Open();
                cmd.ExecuteScalar();
            }
            catch (OracleException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.conn.Close();
            }
        }

        public int getaccountID(string username)
        {
            int idnumber = 0;
            OracleCommand cmd = this.conn.CreateCommand();
            cmd.CommandText = "SELECT \"ID\" from ACCOUNT  WHERE  GEBRUIKERSNAAM='" + username + "';";
            try
            {
                this.conn.Open();
                idnumber = Convert.ToInt32(cmd.ExecuteReader());
            }
            catch (OracleException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                this.conn.Close();
            }
            return idnumber;
        }

        public void addcategory(int idneeded, string naam)
        {
            throw new NotImplementedException();
        }

        public int getbijdrageID(int accountid, DateTime thistime, string bijdragesoort)
        {
            throw new NotImplementedException();
        }


        public List<string> GetUserInfo(string user)
        {
            throw new NotImplementedException();
        }
    }
}
