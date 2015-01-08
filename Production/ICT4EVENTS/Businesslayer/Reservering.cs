using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer;
using System.Data;

namespace Businesslayer
{
    public class Reservering
    {
        private Datalayer.DatabaseConnection _databaseConnection;

        public Reservering()
        {
            this._databaseConnection = new Datalayer.DatabaseConnection();
        }

        public List<string> Getplaces()
        {
            return _databaseConnection.Getplaces();
        }

        public void AddPerson(string voornaam, string tussenvoegsel, string achternaam, string straat, string huisnr,
            string woonplaats, string banknr)
        {
            _databaseConnection.AddPerson(voornaam, tussenvoegsel, achternaam, straat, huisnr, woonplaats, banknr);
        }

        public void AddReservering(string voornaam, string achternaam, DateTime startdate, DateTime enddate, int betaald, int plek)
        {
            _databaseConnection.AddReservering(voornaam,achternaam, startdate, enddate, betaald,plek);
        }
    }
}
