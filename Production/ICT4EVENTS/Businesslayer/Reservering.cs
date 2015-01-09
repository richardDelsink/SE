// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Reservering.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The reservering.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datalayer;

namespace Businesslayer
{
    /// <summary>
    /// TODO The reservering.
    /// </summary>
    public class Reservering
    {
        /// <summary>
        /// TODO The _database connection.
        /// </summary>
        private DatabaseConnection _databaseConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Reservering"/> class.
        /// </summary>
        public Reservering()
        {
            this._databaseConnection = new Datalayer.DatabaseConnection();
        }

        /// <summary>
        /// TODO The getplaces.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> Getplaces()
        {
            return _databaseConnection.Getplaces();
        }

        /// <summary>
        /// TODO The add person.
        /// </summary>
        /// <param name="voornaam">
        /// TODO The voornaam.
        /// </param>
        /// <param name="tussenvoegsel">
        /// TODO The tussenvoegsel.
        /// </param>
        /// <param name="achternaam">
        /// TODO The achternaam.
        /// </param>
        /// <param name="straat">
        /// TODO The straat.
        /// </param>
        /// <param name="huisnr">
        /// TODO The huisnr.
        /// </param>
        /// <param name="woonplaats">
        /// TODO The woonplaats.
        /// </param>
        /// <param name="banknr">
        /// TODO The banknr.
        /// </param>
        public void AddPerson(
            string voornaam, 
            string tussenvoegsel, 
            string achternaam, 
            string straat, 
            string huisnr, 
            string woonplaats, 
            string banknr)
        {
            _databaseConnection.AddPerson(voornaam, tussenvoegsel, achternaam, straat, huisnr, woonplaats, banknr);
        }

        /// <summary>
        /// TODO The add reservering.
        /// </summary>
        /// <param name="voornaam">
        /// TODO The voornaam.
        /// </param>
        /// <param name="achternaam">
        /// TODO The achternaam.
        /// </param>
        /// <param name="startdate">
        /// TODO The startdate.
        /// </param>
        /// <param name="enddate">
        /// TODO The enddate.
        /// </param>
        /// <param name="betaald">
        /// TODO The betaald.
        /// </param>
        /// <param name="plek">
        /// TODO The plek.
        /// </param>
        public void AddReservering(
            string voornaam, 
            string achternaam, 
            DateTime startdate, 
            DateTime enddate, 
            int betaald, 
            int plek)
        {
            _databaseConnection.AddReservering(voornaam, achternaam, startdate, enddate, betaald, plek);
        }
    }
}