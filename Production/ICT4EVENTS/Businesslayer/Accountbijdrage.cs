// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Accountbijdrage.cs" company="">
//   
// </copyright>
// <summary>
//   The accountbijdrage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.UI.WebControls;

using Datalayer;

using ICT4EVENTS;

namespace Businesslayer
{
    /// <summary>
    /// The accountbijdrage.
    /// </summary>
    public class Accountbijdrage
    {
        /// <summary>
        /// The _database connection.
        /// </summary>
        private DatabaseConnection _databaseConnection;

        /// <summary>
        /// bijdragesoort (bestand/categorie/bericht
        /// </summary>
        public string bijdragesoort = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Accountbijdrage"/> class.
        /// </summary>
        public Accountbijdrage()
        {
            this._databaseConnection = new Datalayer.DatabaseConnection();
        }

        /// <summary>
        /// adds a comment on a file to the dba.
        /// </summary>
        /// <param name="accountid">
        /// The accountid.
        /// </param>
        /// <param name="titel">
        /// title of comment
        /// </param>
        /// <param name="inhoud">
        /// body of the comment
        /// </param>
        public void Addbericht(int accountid, string titel, string inhoud)
        {
            bijdragesoort = "bericht";
            int idneeded = 0;
            DateTime thistime = DateTime.Now;
            this._databaseConnection.addbijdrage(accountid, thistime, bijdragesoort);
            idneeded = this._databaseConnection.getbijdrageID();
            this._databaseConnection.addbericht(idneeded, titel, inhoud);
        }

        /// <summary>
        /// Adds the category to the database
        /// </summary>
        /// <param name="accountid">
        /// the accountid
        /// </param>
        /// <param name="naam">
        /// name
        /// </param>
        public void Addcategory(int accountid, string naam)
        {
            bijdragesoort = "categorie";
            int idneeded = 0;
            DateTime thistime = DateTime.Now;
            this._databaseConnection.addbijdrage(accountid, thistime, bijdragesoort);
            idneeded = this._databaseConnection.getbijdrageID();
            this._databaseConnection.addcategory(idneeded, naam);
        }

        /// <summary>
        /// adss the file to the database
        /// </summary>
        /// <param name="accountid">
        /// accountid
        /// </param>
        /// <param name="bestandslocatie">
        /// file location
        /// </param>
        /// <param name="bestandsgrootte">
        /// file size
        /// </param>
        /// <param name="category">
        /// category
        /// </param>
        public void AddFiletoDb(int accountid, string bestandslocatie, int bestandsgrootte, string category)
        {
            bijdragesoort = "bestand";
            int idneeded = 0;
            int categoryid = 0;
            DateTime thistime = DateTime.Now;
            this._databaseConnection.addbijdrage(accountid, thistime, bijdragesoort);
            idneeded = this._databaseConnection.getbijdrageID();
            categoryid = this._databaseConnection.getcategoryid(category);
            this._databaseConnection.addFile(idneeded, categoryid, bestandslocatie, bestandsgrootte);
        }

        /// <summary>
        /// returns the category id
        /// </summary>
        /// <param name="category">
        /// category
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetcategoryID(string category)
        {
            return this._databaseConnection.getcategoryid(category);
        }

        /// <summary>
        /// Returns the account id
        /// </summary>
        /// <param name="username">
        /// the username
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Getaccountid(string username)
        {
            return this._databaseConnection.getaccountID(username);
        }

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> Getcategory()
        {
            return this._databaseConnection.Getcategory();
        }

        /// <summary>
        /// Gets the files in the database
        /// </summary>
        /// <returns>
        /// The <see cref="DataSet"/>.
        /// </returns>
        public DataSet Getfiles()
        {
            return this._databaseConnection.Getfiles();
        }

        /// <summary>
        /// get files based on category
        /// </summary>
        /// <param name="category">
        /// category
        /// </param>
        /// <returns>
        /// The <see cref="DataSet"/>.
        /// </returns>
        public DataSet GetfilesOnCategory(string category)
        {
            return this._databaseConnection.GetfilesOnCategory(category);
        }

        /// <summary>
        /// adding file to the ftp server
        /// </summary>
        /// <param name="fileName">
        /// filename
        /// </param>
        /// <param name="contentLength">
        /// filesize
        /// </param>
        /// <param name="categoriecb">
        /// categorie of file
        /// </param>
        public void AddFiletoFTP(string fileName, int contentLength, string categoriecb)
        {
            // FTP ZOOI
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp:192.168.21.142");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential("Administrator", "Fontysict!");
            StreamReader sourceStream = new StreamReader(fileName);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
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