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
    public class Accountbijdrage
    {
        private DatabaseConnection _databaseConnection;
        public string Bijdragesoort = string.Empty;
        public Accountbijdrage()
        {
            this._databaseConnection = new Datalayer.DatabaseConnection();
        }



        public void Addbericht(int accountid, string titel, string inhoud)
        {
            this.Bijdragesoort = "bericht";
            int idneeded = 0;
            DateTime thistime = DateTime.Now;
            this._databaseConnection.addbijdrage(accountid, thistime, this.Bijdragesoort);
            idneeded = this._databaseConnection.getbijdrageID(accountid, thistime, this.Bijdragesoort);
            this._databaseConnection.addbericht(idneeded, titel, inhoud);
        }

        public void Addcategory(int accountid, string naam)
        {
            this.Bijdragesoort = "categorie";
            int idneeded = 0;
            DateTime thistime = DateTime.Now;
            this._databaseConnection.addbijdrage(accountid, thistime, this.Bijdragesoort);
            idneeded = this._databaseConnection.getbijdrageID(accountid, thistime, this.Bijdragesoort);
            this._databaseConnection.addcategory(idneeded, naam);
        }

        public void Addbestand(int accountid, string bestandslocatie, string categorie, int grootte)
        {
            this.Bijdragesoort = "bestand";
            int IDbijdrage = 0;
            int IDcategory = 0;
            DateTime thisTime = DateTime.Now;
            this._databaseConnection.addbijdrage(accountid, thisTime, this.Bijdragesoort);
            IDbijdrage = this._databaseConnection.getbijdrageID(accountid, thisTime, this.Bijdragesoort);
            IDcategory = this._databaseConnection.getcategoryid(categorie);
            this._databaseConnection.addFile(IDcategory, bestandslocatie, grootte);
        }

        public int Getaccountid(string username)
        {
            return this._databaseConnection.getaccountID(username);
        }

        public List<string> Getcategory()
        {
            return this._databaseConnection.Getcategory();
        }

    }
}