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

            conn = new OracleConnection();
            string user = "system";
            string pw = "infra-s38";
           // conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //192.168.21.142:1521/" + ";";
             conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //172.21.142.1:1521/" + ";";

            
            //vdi.fhict connection van iemand
           // this.conn = new OracleConnection();
           // string user = "dbi306956"; // zie email voor logingegevens
          //  string pw = "kyqSZFxe7N";
           // this.conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //192.168.15.50:1521/fhictora" + ";";

            //conn = new OracleConnection();
            //string user = "system";
            //string pw = "infra-s38";
            //conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //192.168.21.142:1521/" + ";";

            //vdi.fhict connection van iemand
            //this.conn = new OracleConnection();
            //string user = "dbi306956"; // zie email voor logingegevens
            //string pw = "kyqSZFxe7N";
            //this.conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" +
              //                           " //192.168.15.50:1521/fhictora" + ";";


            //Locale connectie hieronder
           //conn = new OracleConnection();
           //String user = "SYSTEM";
           //String pw = "2438747";
           //conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //localhost:1521/xe" + ";"; 
            //orcl is de servicename (kan anders zijn, is afhankelijk van de Oracle server die geinstalleerd is. Mogelijk is ook Oracle Express: xe


            //Mark z'n connectie afblijven pls
            //conn = new OracleConnection();
            // String user = "dbi304910";
            //String pw = "Y3cqxa8GS6";
            //  conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //fhictora01.fhict.local:1521/fhictora" + ";"; 
            /*
            try
            {
                conn = new OracleConnection();
                String user = "dbi304910";
                String pw = "Y3cqxa8GS6";
                conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //fhictora01.fhict.local:1521/fhictora" + ";"; 


            }
                catch(OracleException exception)
            {}
            finally
            {
                
            }
           */
        }

        ///METHODS OF ACCESS CONTROL///
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
                cmd.CommandText =
                    "SELECT p.id,\"merk\", \"serie\",\"naam\", \"prijs\" FROM productexemplaar pe, product p, productcat pc WHERE pe.\"product_id\" = p.\"productcat_id\" AND p.ID = pc.ID";
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

        ///Methods of the Log-in/Registration page///
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
            cmd.CommandText =
                "SELECT \"voornaam\" FROM persoon WHERE \"voornaam\" = :SELFIRSTNAME AND \"achternaam\" = :SELLASTNAME";
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

            if (result != "")
            {
                return true;
            }
            return false;
        }

        public void addAccount(string email, string username, string wachtwoord)
        {
            try
            {
                Random rnd = new Random();
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText =
                    "INSERT INTO ACCOUNT(\"gebruikersgroep_id\", \"gebruikersnaam\", \"wachtwoord\", \"email\", \"activatiehash\", \"geactiveerd\") VALUES (:gebrgroep, :gebruikersnaam, :wachtwoord, :email, :activatiehash, :geactiveerd)";
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

        ///FILESHARING///
        ///

        public List<string> Searchfiles(string searchterm)
        {
            List<string> searchresults = new List<string>();
            try
            {
                string queryString = "select \"bestandslocatie\" from bestand where \"bestandslocatie\" LIKE :un";

                OracleCommand cmd = new OracleCommand(queryString, this.conn);
                cmd.Parameters.Add(":un", OracleDbType.NVarchar2).Value = "%" + searchterm + "%";


                this.conn.Open();

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        searchresults.Add(reader.GetString(0));
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
            return searchresults;
        }

        public DataSet Comments(int file)
        {
            string queryString = "select c.\"gebruikersnaam\" as Username, a.\"titel\" as Titel, a.\"inhoud\" as Message from bericht a, bijdrage b, account c where c.ID = b.\"account_id\" and a.\"bijdrage_id\" = b.ID and a.\"bijdrage_id_over\" = :un";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("un", file);
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


        public void addcomment(int account_id, DateTime datum, string soort)
        {

            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "insert into bijdrage(\"account_id\", \"datum\", \"soort\") VALUES (:acc, :date, :soort)";
                cmd.Parameters.Add("acc", account_id);
                cmd.Parameters.Add("date", datum);
                cmd.Parameters.Add("soort", soort);
                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException exception)
            {

            }
            finally
            {
                this.conn.Close();
            }
        }


        public List<string> Getfiles()
        {
            List<string> files = new List<string>();
            string queryString = "select \"bestandslocatie\" as naam from Bestand";

            OracleCommand cmd = new OracleCommand(queryString, this.conn);

            this.conn.Open();

            try
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        files.Add(reader.GetString(0));
                    }
                }

            }
            catch (OracleException e)
            {
                // The connection failed. Display an error message            
            }
            finally
            {
                conn.Close();
            }
            return files;
        }

        public List<string> GetfilesOnCategory(string category)
        {
            List<string> files = new List<string>();
            string queryString = "select \"bestandslocatie\" from bestand where \"categorie_id\" = (select \"categorie_id\" from categorie where \"naam\" = :cat)";

            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("cat", category);

            this.conn.Open();

            try
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        files.Add(reader.GetString(0));
                    }
                }

            }
            catch (OracleException e)
            {
                // The connection failed. Display an error message            
            }
            finally
            {
                conn.Close();
            }
            return files;
        }



        public void addbijdrage(int bijdrageid, int accountid, DateTime thistime, string bijdragesoort)
        {
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "INSERT INTO BIJDRAGE(\"ID\" ,\"account_id\",\"datum\",\"soort\") VALUES(:bidd, :accd,:datede,:soort)";
                cmd.Parameters.Add("bidd", bijdrageid);
                cmd.Parameters.Add("accd", accountid);
                cmd.Parameters.Add("datede", thistime);
                cmd.Parameters.Add("soort", bijdragesoort);
                try
                {
                    this.conn.Open();
                    cmd.ExecuteReader();
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
        }

        public List<string> Getcategory()
        {
            List<string> category = new List<string>();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select \"naam\" from Categorie";
            try
            {
                this.conn.Open();
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        category.Add(reader.GetString(0));
                    }
                }
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
        public void addbericht(int bijdrageid, string titel, string inhoud, int fileid)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "INSERT INTO BERICHT (\"bijdrage_id\", \"bijdrage_id_over\",\"titel\",\"inhoud\") VALUES(:een,:twee,:drie, :vier)";
                cmd.Parameters.Add("een", bijdrageid);
                cmd.Parameters.Add("twee", fileid);
                cmd.Parameters.Add("drie", titel);
                cmd.Parameters.Add("vier", inhoud);
                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException exception)
            {

            }
            finally
            {
                this.conn.Close();
            }
        }
        public int getbijdrageID()
        {
            int bijdrageid = 0;
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "select MAX(\"ID\") from Bijdrage";
                this.conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bijdrageid = reader.GetInt32(0);
                }
            }
            catch (OracleException e)
            {

            }
            finally
            {
                this.conn.Close();
            }
            bijdrageid++;
            return bijdrageid;

        }

        public int getcategoryid(string categorie)
        {
            int catid = 0;
            OracleCommand cmd = this.conn.CreateCommand();
            cmd.CommandText = "SELECT \"bijdrage_id\" from bestand WHERE \"bestandslocatie\"= :cat ";
            cmd.Parameters.Add("cat", categorie);
            try
            {
                this.conn.Open();
                catid = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (OracleException exc)
            {
                Console.Write(exc);
            }
            finally
            {
                this.conn.Close();
            }

            return catid;

        }
        public void addFile(int idneeded, int dcategory, string bestandslocatie, int grootte)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText =
             "INSERT INTO BESTAND (\"bijdrage_id\",\"categorieid\",\"bestandslocatie\",\"grootte\") VALUES (:idneed, :category,:loc,:size)";
                cmd.Parameters.Add("idneed", idneeded);
                cmd.Parameters.Add("category", dcategory);
                cmd.Parameters.Add("loc", bestandslocatie);
                cmd.Parameters.Add("size", grootte);
                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException exception)
            {

            }
            finally
            {
                this.conn.Close();
            }

        }

        public void addcategory(int idneeded, string naam)
        {

            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "INSERT INTO CATEGORIE (\"bijdrage_id\",\"naam\") VALUES (:idneed, :name)";
                cmd.Parameters.Add("idneed", idneeded);
                cmd.Parameters.Add("name", naam);
                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException exception)
            {

            }
            finally
            {
                this.conn.Close();
            }
        }

        public int getaccountID(string username)
        {
            int catid = 0;
            OracleCommand cmd = this.conn.CreateCommand();
            cmd.CommandText = "SELECT \"ID\" from ACCOUNT  WHERE  \"gebruikersnaam\"= :cat";
            cmd.Parameters.Add("cat", username);
            try
            {
                this.conn.Open();
                catid = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (OracleException exc)
            {
                Console.Write(exc);
            }
            finally
            {
                this.conn.Close();
            }

            return catid;
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
                cmd.CommandText =
                    "INSERT INTO EVENT(\"locatie_id\",\"naam\", \"datumstart\", \"datumEinde\", \"maxBezoekers\") VALUES (:loc ,:naam, :startd, :eindd, :bezoek)";
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
                cmd.CommandText = "Select \"ID\" From locatie where \"naam\"= :naam";
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

        public void AddPerson(string voornaam, string tussenvoegsel, string achternaam, string straat, string huisnr,
            string woonplaats, string banknr)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();

                cmd.CommandText =
                    "INSERT INTO PERSOON(\"voornaam\",\"tussenvoegsel\",\"achternaam\",\"straat\",\"huisnr\",\"woonplaats\",\"banknr\") VALUES(:voornaam,:tussenvoegsel,:achternaam,:straat,:huisnr,:woonplaats,:banknr)";
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

        public void AddReservering(string voornaam, string achternaam, DateTime startdate, DateTime enddate, int betaald,
            int plek)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();

                cmd.CommandText =
                    "INSERT INTO RESERVERING(persoon_id,datumStart, datumEinde, betaald) VALUES(:persoon_id,:datumStart, :datumEinde, :betaald)";
                cmd.Parameters.Add("persoon_id", GetpersonId(voornaam, achternaam, plek));
                cmd.Parameters.Add("datumStart", startdate);
                cmd.Parameters.Add("datumEinde", enddate);
                cmd.Parameters.Add("betaald", betaald);

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

        public int GetpersonId(string voornaam, string achternaam, int plek)
        {
            int personid = 0;
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();

                cmd.CommandText =
                    "SELECT \"id\" FROM PERSOON WHERE upper(voornaam)=upper(:voornaam )and upper(achternaam)=upper(:achternaam)";
                cmd.Parameters.Add("voornaam", voornaam);
                cmd.Parameters.Add("achternaam", achternaam);

                this.conn.Open();
                personid = Convert.ToInt32(cmd.ExecuteReader());
                Getreservationid(personid, voornaam, achternaam, plek);

            }
            catch (OracleException exc)
            {
            }
            finally
            {
                this.conn.Close();
            }
            return personid;
        }

        public int Getreservationid(int persoonid, string voornaam, string achternaam, int plek)
        {
            int reservationid = 0;
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();

                cmd.CommandText = "SELECT \"id\" FROM RESERVERING WHERE persoon_id=:persoonid";
                cmd.Parameters.Add("voornaam", voornaam);
                cmd.Parameters.Add("achternaam", achternaam);

                this.conn.Open();
                reservationid = Convert.ToInt32(cmd.ExecuteReader());
                InsertplekReservation(plek, reservationid);

            }
            catch (OracleException exc)
            {
            }
            finally
            {
                this.conn.Close();
            }
            return reservationid;
        }

        public void InsertplekReservation(int plek, int reservation)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();

                cmd.CommandText =
                    "INSERT INTO PLEK_RESERVERING(\"plek_id\",\"Reservering_id\") VALUES(:plek_id,:Reservering_id)";
                cmd.Parameters.Add("plek_id", plek);
                cmd.Parameters.Add("Reservering_id", reservation);

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

        public List<string> GetUserInfo(string user)
        {
            throw new NotImplementedException();
        }

        public List<string> GetReservationInfo(string username)
        {
            List<string> reservationList = new List<string>();
            OracleCommand cmd = this.conn.CreateCommand();
            OracleDataReader reader;
            cmd.CommandText =
                "SELECT R.* FROM RESERVERING R, RESERVERING_POLSBANDJE RP, ACCOUNT AC, Persoon PE WHERE AC.ID = RP.\"account_id\" AND RP.\"reservering_id\" = R.ID AND AC.\"gebruikersnaam\" = :USERNAME";
            cmd.Parameters.Add("USERNAME", username);


            try
            {
                this.conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        reservationList.Add(Convert.ToString(reader.GetValue(0)));
                    }

                    if (!reader.IsDBNull(1))
                    {
                        reservationList.Add(Convert.ToString(reader.GetValue(1)));
                    }

                    if (!reader.IsDBNull(2))
                    {
                        reservationList.Add(Convert.ToString(reader.GetDateTime(2).ToShortDateString()));
                    }

                    if (!reader.IsDBNull(3))
                    {
                        reservationList.Add(Convert.ToString(reader.GetDateTime(3).ToShortDateString()));
                    }

                    if (!reader.IsDBNull(4))
                    {
                        if (reader.GetInt32(4) == 1)
                        {
                            reservationList.Add("De reservering is betaald!");
                        }
                        else
                        {
                            reservationList.Add("De reservering is nog niet betaald!");
                        }

                    }
                }


            }
            catch (OracleException exc)
            {
                Console.Write(exc);
            }
            finally
            {
                this.conn.Close();
            }

            return reservationList;
        }

        public List<int> CampReservationList(string username)
        {
            List<int> CampNumbers = new List<int>();
            OracleCommand cmd = this.conn.CreateCommand();
            OracleDataReader reader;
            cmd.CommandText =
                "SELECT PR.\"plek_id\"  FROM PLEK_RESERVERING PR, RESERVERING R, RESERVERING_POLSBANDJE RP, ACCOUNT AC  WHERE PR.\"reservering_id\" = R.ID and R.ID = RP.ID AND RP.\"account_id\" = AC.ID AND AC.\"gebruikersnaam\" = :USERNAME'";
            cmd.CommandText =
                "SELECT PR.\"plek_id\"  FROM PLEK_RESERVERING PR, RESERVERING R, RESERVERING_POLSBANDJE RP, ACCOUNT AC  WHERE PR.\"reservering_id\" = R.ID and R.ID = RP.ID AND RP.\"account_id\" = AC.ID AND AC.\"gebruikersnaam\" = :USERNAME";
            cmd.Parameters.Add("USERNAME", username);

            try
            {
                this.conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    CampNumbers.Add(reader.GetInt16(0));
                }
            }

            catch (OracleException exc)
            {
                Console.Write(exc);
            }
            finally
            {
                conn.Close();
            }

            return CampNumbers;
        }

        public List<string> ReservedItemsList(string username)
        {

            List<string> reserveditemStringList = new List<string>();
            OracleCommand cmd = this.conn.CreateCommand();
            OracleDataReader reader;
            cmd.CommandText = "SELECT \"datumIn\", v.\"datumUit\", p.\"merk\", pc.\"naam\", v.\"prijs\" FROM VERHUUR v, productexemplaar pe, product p, productcat pc, reservering_polsbandje rp, account ac WHERE v.\"productexemplaar_id\" = pe.Id AND p.ID = pe.\"product_id\" AND pc.id = p.\"productcat_id\" AND rp.\"account_id\" = ac.ID AND v.\"res_pb_id\" = ac.ID AND AC.\"gebruikersnaam\" = :naam";
            cmd.Parameters.Add("USERNAME", username);

            try
            {
                this.conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3) && !reader.IsDBNull(4))
                    {

                        reserveditemStringList.Add("@" + reader.GetDateTime(0).ToShortDateString() + "#" + reader.GetDateTime(1).ToShortDateString() + "$" + reader.GetString(2) + "%" + reader.GetString(3) + "|" + Convert.ToString(reader.GetValue(4) + "~"));

                    }
                }



            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                conn.Close();
            }

            return reserveditemStringList;
        }

        public List<string> FillMaterialAdmin()
        {

            List<string> verhuurList = new List<string>();
            OracleCommand cmd = this.conn.CreateCommand();
            OracleDataReader reader;
            cmd.CommandText =
                "SELECT V.*, AC.\"gebruikersnaam\" FROM VERHUUR V, ACCOUNT AC, RESERVERING_POLSBANDJE RP WHERE V.\"res_pb_id\" = RP.ID AND RP.\"account_id\" = AC.ID";

            try
            {
                this.conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3) &&
                        !reader.IsDBNull(4) && !reader.IsDBNull(5) && !reader.IsDBNull(6) && !reader.IsDBNull(7))
                    {
                        verhuurList.Add("@" + Convert.ToString(reader.GetValue(0)) + "#" +
                                        Convert.ToString(reader.GetValue(1)) + "$" +
                                        Convert.ToString(reader.GetValue(2)) + "%" +
                                        reader.GetDateTime(3).ToShortDateString() + "^" +
                                        reader.GetDateTime(4).ToShortDateString() + "&" +
                                        Convert.ToString(reader.GetValue(5)) + "*" +
                                        Convert.ToString(reader.GetValue(6)) + "~" + reader.GetString(7) + '€');

                    }
                }



            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                conn.Close();
            }

            return verhuurList;
        }


        public void CompleteLease(int verhuurID)
        {

            OracleCommand cmd = this.conn.CreateCommand();
            OracleDataReader reader;
            cmd.CommandText = " DELETE FROM VERHUUR WHERE ID = :VERHUURID";
            cmd.Parameters.Add("VERHUURID", verhuurID);


            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                conn.Close();
            }

        }

        public void AddEndDateLease(int verhuurID, DateTime datum)
        {

            OracleCommand cmd = this.conn.CreateCommand();
            OracleDataReader reader;
            cmd.CommandText = " UPDATE VERHUUR SET \"datumUit\" = :DATUM WHERE ID = :VERHUURID";
            cmd.Parameters.Add("DATUM", datum);
            cmd.Parameters.Add("VERHUURID", verhuurID);


            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

    


