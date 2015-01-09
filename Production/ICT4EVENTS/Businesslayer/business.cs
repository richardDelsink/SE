using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
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
        public List<string> Getcategory()
        {
            return this._databaseConnection.Getcategory();
        }

        public List<string> UserInfo(string user)
        {
            return _databaseConnection.GetUserInfo(user);
        } 

       public List<string> ReservationInfo(string user)
       {
           return _databaseConnection.GetReservationInfo(user);
       }

       public List<int> CampNumbersInfo(string user)
       {
           return _databaseConnection.CampReservationList(user);
       }

       public List<string> ReserveditemsList(string username)
       {
        return _databaseConnection.ReservedItemsList(username);
       }

       public void LeasedItemViews(ListView LV)
       {
           _databaseConnection.LeasedItemView(LV);
       }



    }
}
