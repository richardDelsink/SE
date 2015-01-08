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

        public void Addbestand()
        {
            throw new NotImplementedException();
        }

        public int Getaccountid(string username)
        {
            return this._databaseConnection.getaccountID(username);
        }



    }
}