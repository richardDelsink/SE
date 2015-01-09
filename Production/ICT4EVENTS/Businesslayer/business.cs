using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data; 
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

       public DataTable LeasedItemViews(GridView gridViewV)
       {
           List<string> ValuesToTranslate = new List<string>();
           ValuesToTranslate = _databaseConnection.FillMaterialAdmin();

           DataTable DT = new DataTable();
           DT.Columns.Add("VerhuurID");
           DT.Columns.Add("Product-exemplaarID");
           DT.Columns.Add("Reserving_Polsbandje_ID");
           DT.Columns.Add("Uitleendatum");
           DT.Columns.Add("Terugbrengdatum");
           DT.Columns.Add("Prijs");
           DT.Columns.Add("Betaalstatus");
           DT.Columns.Add("Gebruikersnaam");

           for (int i = 0; i < ValuesToTranslate.Count; i++)
           {
               DataRow dr2 = DT.NewRow();

               string subbedString = ValuesToTranslate.ElementAt(i);
               int index;
               int endIndex;
               string finalSubString;
               if (subbedString != " ")
               {
                   index = subbedString.IndexOf('@') + 1;
                   endIndex = subbedString.IndexOf('#');
                   finalSubString = subbedString.Substring(index, endIndex - index);
                   dr2["VerhuurID"] = finalSubString;

                   index = subbedString.IndexOf('#') + 1;
                   endIndex = subbedString.IndexOf('$');
                   finalSubString = subbedString.Substring(index, endIndex - index);
                   dr2["Product-exemplaarID"] = finalSubString;

                   index = subbedString.IndexOf('$') + 1;
                   endIndex = subbedString.IndexOf('%');
                   finalSubString = subbedString.Substring(index, endIndex - index);
                   dr2["Reserving_Polsbandje_ID"] = finalSubString;

                   index = subbedString.IndexOf('%') + 1;
                   endIndex = subbedString.IndexOf('^');
                   finalSubString = subbedString.Substring(index, endIndex - index);
                   dr2["Uitleendatum"] = finalSubString;

                   index = subbedString.IndexOf('^') + 1;
                   endIndex = subbedString.IndexOf('&');
                   finalSubString = subbedString.Substring(index, endIndex - index);
                   dr2["Terugbrengdatum"] = finalSubString;

                   index = subbedString.IndexOf('&') + 1;
                   endIndex = subbedString.IndexOf('*');
                   finalSubString = subbedString.Substring(index, endIndex - index);
                   dr2["Prijs"] = finalSubString;

                   index = subbedString.IndexOf('*') + 1;
                   endIndex = subbedString.IndexOf('~');
                   finalSubString = subbedString.Substring(index, endIndex - index);
                   dr2["Betaalstatus"] = finalSubString;

                   index = subbedString.IndexOf('~') + 1;
                   endIndex = subbedString.IndexOf('€');
                   finalSubString = subbedString.Substring(index, endIndex - index);
                   dr2["Gebruikersnaam"] = finalSubString;

                   DT.Rows.Add(dr2);
               }
           }

           return DT;
       }

       public void CompletedLease(int huur_id)
       {
           _databaseConnection.CompleteLease(huur_id);
       }

       public void CompleteReservation(int huur_id, DateTime datum)
       {
           _databaseConnection.AddEndDateLease(huur_id, datum);
       }

       public void naamReturn(string naam)
       {
          // _databaseConnection.naamReturn(naam);
       }


       public void MaterialReservation(int productexemplaar_id, int res_pb_id, int betaald, int prijs)
       {
     //      _databaseConnection.MateriaalReservation(productexemplaar_id, res_pb_id, betaald, prijs);
       }

       public int Id()
       {
           return 0;
           //   return _databaseConnection.ReturnId;
       }


    }
}
