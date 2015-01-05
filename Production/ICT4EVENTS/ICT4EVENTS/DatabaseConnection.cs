using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;

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

        public int GetPlaces()
        {

            int uitkomst = 0;
            int id;

            OracleDataReader Reader;
            this.conn = new OracleConnection();
            this.conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand("SELECT * from Plek", conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            Reader = cmd.ExecuteReader();

            try
            {
                while (Reader.Read())
                {
                    uitkomst = Convert.ToInt16(Reader.GetValue(3));
                }
            }
            catch (OracleException OE)
            {

            }
            finally
            {
                conn.Close();

            }
            return uitkomst;

        }
    }
}