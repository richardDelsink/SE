using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;
using System.Data;

namespace ICT4EVENTS
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
                cmd.CommandText = "INSERT INTO EVENT(\"locatie_id\",\"naam\", \"datumstart\", \"datumEinde\", \"maxBezoekers\") VALUES (1,:naam, :startd, :eindd, :bezoek)";
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
            string queryString = "Select l.\"naam\" as Locatie, e.\"naam\" as Naam, e.\"datumstart\" As BeginDatum, e.\"datumEinde\" as EindDatum, e.\"maxBezoekers\" as MaxBezoekers From Event e, Locatie l";
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