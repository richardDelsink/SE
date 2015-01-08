using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Datalayer;

namespace Businesslayer
{
   public class Business
    {
        private Datalayer.DatabaseConnection _databaseConnection;

        public Business()
        {
            this._databaseConnection = new Datalayer.DatabaseConnection();
        }

        public void Datagrid(GridView d)
        {
            _databaseConnection.FillDataGrid(d);
        }

        public void Materialgrid(GridView gv)
        {
            _databaseConnection.MaterialGrid(gv);
        }
        public string GetAccountInfoFromBC(string barcode)
        {
           return _databaseConnection.GetAccountInfo(barcode);
        }

        public string DBCheckBarcode(string barcode)
        {
            return _databaseConnection.CheckBarcode(barcode);
        }









    }
}
