using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer;
using System.Data;

namespace Businesslayer
{ 
    public class Events
    {
        private Datalayer.DatabaseConnection _databaseConnection;

        public Events()
        {
            this._databaseConnection = new Datalayer.DatabaseConnection();
        }

        public List<string> GetLocations()
        {
            return _databaseConnection.Locations();
        }

        public void CreateEvent(string naam, DateTime start, DateTime eind, int max)
        {
            _databaseConnection.CreateEvent(naam, start, eind, max);
        }

        public DataSet GetAllEvents()
        {
            return _databaseConnection.GetEvents();
        }
    }
}
