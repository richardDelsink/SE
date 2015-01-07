using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer;

namespace Businesslayer
{
    class Business
    {
        private Datalayer.DatabaseConnection _databaseConnection;

        public Business()
        {
            this._databaseConnection = new DatabaseConnection();
        }







    }
}
