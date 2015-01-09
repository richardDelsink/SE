// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Events.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The events.
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
    /// TODO The events.
    /// </summary>
    public class Events
    {
        /// <summary>
        /// TODO The _database connection.
        /// </summary>
        private DatabaseConnection _databaseConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Events"/> class.
        /// </summary>
        public Events()
        {
            this._databaseConnection = new Datalayer.DatabaseConnection();
        }

        /// <summary>
        /// TODO The get locations.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> GetLocations()
        {
            return _databaseConnection.Locations();
        }

        /// <summary>
        /// TODO The create event.
        /// </summary>
        /// <param name="naam">
        /// TODO The naam.
        /// </param>
        /// <param name="start">
        /// TODO The start.
        /// </param>
        /// <param name="eind">
        /// TODO The eind.
        /// </param>
        /// <param name="max">
        /// TODO The max.
        /// </param>
        /// <param name="locatie">
        /// TODO The locatie.
        /// </param>
        public void CreateEvent(string naam, DateTime start, DateTime eind, int max, string locatie)
        {
            _databaseConnection.CreateEvent(naam, start, eind, max, locatie);
        }

        /// <summary>
        /// TODO The get all events.
        /// </summary>
        /// <returns>
        /// The <see cref="DataSet"/>.
        /// </returns>
        public DataSet GetAllEvents()
        {
            return _databaseConnection.GetEvents();
        }
    }
}