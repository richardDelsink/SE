// --------------------------------------------------------------------------------------------------------------------
// <copyright file="business.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The business.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Datalayer;

namespace Businesslayer
{
    /// <summary>
    /// TODO The business.
    /// </summary>
    public class Business
    {
        /// <summary>
        /// TODO The _database connection.
        /// </summary>
        private DatabaseConnection _databaseConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Business"/> class.
        /// </summary>
        public Business()
        {
            this._databaseConnection = new Datalayer.DatabaseConnection();
        }

        /// <summary>
        /// TODO The datagrid.
        /// </summary>
        /// <param name="d">
        /// TODO The d.
        /// </param>
        public void Datagrid(GridView d)
        {
            _databaseConnection.FillDataGrid(d);
        }

        /// <summary>
        /// TODO The materialgrid.
        /// </summary>
        /// <param name="gv">
        /// TODO The gv.
        /// </param>
        public void Materialgrid(GridView gv)
        {
            _databaseConnection.MaterialGrid(gv);
        }

        /// <summary>
        /// TODO The get account info from bc.
        /// </summary>
        /// <param name="barcode">
        /// TODO The barcode.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetAccountInfoFromBC(string barcode)
        {
            return _databaseConnection.GetAccountInfo(barcode);
        }

        /// <summary>
        /// TODO The db check barcode.
        /// </summary>
        /// <param name="barcode">
        /// TODO The barcode.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string DBCheckBarcode(string barcode)
        {
            return _databaseConnection.CheckBarcode(barcode);
        }

        /// <summary>
        /// TODO The getcategory.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> Getcategory()
        {
            return this._databaseConnection.Getcategory();
        }

        /// <summary>
        /// TODO The user info.
        /// </summary>
        /// <param name="user">
        /// TODO The user.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> UserInfo(string user)
        {
            return _databaseConnection.GetUserInfo(user);
        }

        /// <summary>
        /// TODO The reservation info.
        /// </summary>
        /// <param name="user">
        /// TODO The user.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> ReservationInfo(string user)
        {
            return _databaseConnection.GetReservationInfo(user);
        }

        /// <summary>
        /// TODO The camp numbers info.
        /// </summary>
        /// <param name="user">
        /// TODO The user.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<int> CampNumbersInfo(string user)
        {
            return _databaseConnection.CampReservationList(user);
        }

        /// <summary>
        /// TODO The reserveditems list.
        /// </summary>
        /// <param name="username">
        /// TODO The username.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> ReserveditemsList(string username)
        {
            return _databaseConnection.ReservedItemsList(username);
        }

        /// <summary>
        /// TODO The leased item views.
        /// </summary>
        /// <param name="gridViewV">
        /// TODO The grid view v.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
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

        /// <summary>
        /// TODO The naam return.
        /// </summary>
        /// <param name="naam">
        /// TODO The naam.
        /// </param>
        public void naamReturn(string naam)
        {
            _databaseConnection.naamReturn(naam);
        }

        /// <summary>
        /// TODO The material reservation.
        /// </summary>
        /// <param name="productexemplaar_id">
        /// TODO The productexemplaar_id.
        /// </param>
        /// <param name="res_pb_id">
        /// TODO The res_pb_id.
        /// </param>
        /// <param name="betaald">
        /// TODO The betaald.
        /// </param>
        /// <param name="prijs">
        /// TODO The prijs.
        /// </param>
        public void MaterialReservation(int productexemplaar_id, int res_pb_id, int betaald, int prijs)
        {
            _databaseConnection.MateriaalReservation(productexemplaar_id, res_pb_id, betaald, prijs);
        }

        /// <summary>
        /// TODO The id.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Id()
        {
            return _databaseConnection.ReturnId;
        }
    }
}