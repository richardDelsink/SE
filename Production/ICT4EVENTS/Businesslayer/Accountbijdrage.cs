using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using Datalayer;
using ICT4EVENTS;

namespace Businesslayer
{
    using System.IO;
    using System.Net;
    using System.Security.AccessControl;

    public class Accountbijdrage
    {
        private DatabaseConnection _databaseConnection;

        public string bijdragesoort = string.Empty;

        public Accountbijdrage()
        {
            this._databaseConnection = new Datalayer.DatabaseConnection();
        }





        public void Addbericht(int accountid, string titel, string inhoud)
        {
            bijdragesoort = "bericht";
            int idneeded = 0;
            DateTime thistime = DateTime.Now;
            this._databaseConnection.addbijdrage(accountid, thistime, bijdragesoort);
            idneeded = this._databaseConnection.getbijdrageID(accountid, thistime, bijdragesoort);
            this._databaseConnection.addbericht(idneeded, titel, inhoud);
        }

        public void Addcategory(int accountid, string naam)
        {
            bijdragesoort = "categorie";
            int idneeded = 0;
            DateTime thistime = DateTime.Now;
            this._databaseConnection.addbijdrage(accountid, thistime, bijdragesoort);
            idneeded = this._databaseConnection.getbijdrageID(accountid, thistime, bijdragesoort);
            this._databaseConnection.addcategory(idneeded, naam);
        }

        public void AddFiletoDb(int accountid,string bestandslocatie,int bestandsgrootte,string category)
        {
            bijdragesoort = "bestand";
            int idneeded = 0;
            int categoryid = 0;
            DateTime thistime = DateTime.Now;
            this._databaseConnection.addbijdrage(accountid, thistime, bijdragesoort);
            idneeded = this._databaseConnection.getbijdrageID(accountid, thistime, bijdragesoort);
            categoryid = this._databaseConnection.getcategoryid(category);
            this._databaseConnection.addFile(idneeded, categoryid, bestandslocatie, bestandsgrootte);

        }

        public int GetcategoryID(string category)
        {
            return this._databaseConnection.getcategoryid(category);
        }

        public int Getaccountid(string username)
        {
            return this._databaseConnection.getaccountID(username);
        }

        public List<string> Getcategory()
        {
            return this._databaseConnection.Getcategory();
        }

        public void AddFiletoFTP(string fileName, int contentLength, string categoriecb)
        {
            //FTP ZOOI
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp:192.168.21.142");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential("Administrator", "Fontysict!");
            StreamReader sourceStream = new StreamReader(fileName);
            byte [] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            var response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
            response.Close();
        }

        }
    }

