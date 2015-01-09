namespace ICT4EVENTS
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Businesslayer;

    /// <summary>
    /// Also known as the Homepage.
    /// </summary>
    public partial class _Default : Page
    {
        /// <summary>
        /// References to the Business class for database use.
        /// </summary>
        private Business b = new Business();

        /// <summary>
        /// Used in several methods.
        /// </summary>
        private string username;
        
        /// <summary>
        /// DataTable for the first GridView
        /// </summary>
        private DataTable dtReservation;

        /// <summary>
        /// DataTable for the second GridView
        /// </summary>
        private DataTable dtItemReservation;

        /// <summary>
        /// Occurs when the page loads.
        /// </summary>
        /// <param name="sender">mandatory </param>
        /// <param name="e">mandatory as well </param>
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (Session["Usergroup"].ToString() == "1")
            {
            }
            else
            {
                 this.username = Session["Username"].ToString();
                 this.dtReservation = new DataTable();
                 this.dtItemReservation = new DataTable();
                 this.MakeDataTable();
                 this.AddToDataTable();
                 this.BindGrids();
            }
        }

        /// <summary>
        /// Creates the columns which we will use to fill in later. 
        /// </summary>
        private void MakeDataTable()
        {
            this.dtReservation.Columns.Add("ReservationID");
            this.dtReservation.Columns.Add("PersoonsID");
            this.dtReservation.Columns.Add("Startdatum reservering");
            this.dtReservation.Columns.Add("Einddatum reservering");
            this.dtReservation.Columns.Add("Betaalstatus");
            this.dtReservation.Columns.Add("Kampeerplaatsen");

            this.dtItemReservation.Columns.Add("Uitleendatum");
            this.dtItemReservation.Columns.Add("Terugbrengdatum");
            this.dtItemReservation.Columns.Add("Merk");
            this.dtItemReservation.Columns.Add("Naam");
            this.dtItemReservation.Columns.Add("Prijs");
        }

        /// <summary>
        /// Adds the data from the business layer to the correct column, while creating a row for the GridView
        /// </summary>
        private void AddToDataTable()
     {
         DataRow dr = this.dtReservation.NewRow();
         List<string> inhoud = new List<string>();
            inhoud = this.b.ReservationInfo(this.username);

            dr["ReservationID"] = inhoud.ElementAt(0);
            dr["PersoonsID"] = inhoud.ElementAt(1);
            dr["Startdatum Reservering"] = inhoud.ElementAt(2);
            dr["Einddatum Reservering"] = inhoud.ElementAt(3); 
            dr["Betaalstatus"] = inhoud.ElementAt(4);

            string campspots = string.Empty;
            for (int i = 0; i < this.b.CampNumbersInfo(this.username).Count; i++)
            {
                if (i >= 1)
                {
                    campspots = campspots + "," + this.b.CampNumbersInfo(this.username).ElementAt(i);
                }
                else
                {
                    campspots = campspots + this.b.CampNumbersInfo(this.username).ElementAt(i);
                }   
            }

            dr["Kampeerplaatsen"] = campspots;
            this.dtReservation.Rows.Add(dr);

            for (int i = 0; i < this.b.ReserveditemsList(this.username).Count; i++)
            {
                DataRow dr2 = this.dtItemReservation.NewRow();

                string subbedString = this.b.ReserveditemsList(this.username).ElementAt(i);
                int index;
                int endIndex;
                string finalSubString;
                if (subbedString != " ")
                {
                    index = subbedString.IndexOf('@') + 1;
                    endIndex = subbedString.IndexOf('#');
                    finalSubString = subbedString.Substring(index, endIndex - index);
                    dr2["Uitleendatum"] = finalSubString;

                    index = subbedString.IndexOf('#') + 1;
                    endIndex = subbedString.IndexOf('$');
                    finalSubString = subbedString.Substring(index, endIndex - index);
                    dr2["Terugbrengdatum"] = finalSubString;

                    index = subbedString.IndexOf('$') + 1;
                    endIndex = subbedString.IndexOf('%');
                    finalSubString = subbedString.Substring(index, endIndex - index);
                    dr2["Merk"] = finalSubString;

                    index = subbedString.IndexOf('%') + 1;
                    endIndex = subbedString.IndexOf('|');
                    finalSubString = subbedString.Substring(index, endIndex - index);
                    dr2["Naam"] = finalSubString;

                    index = subbedString.IndexOf('|') + 1;
                    endIndex = subbedString.IndexOf('~');
                    finalSubString = subbedString.Substring(index, endIndex - index);
                    dr2["Prijs"] = finalSubString;

                    this.dtItemReservation.Rows.Add(dr2);           
                }
            }
     }

      /// <summary>
      /// Binds the data from the AddToDataTable method to the correct GridView
      /// </summary>
    private void BindGrids()
    {
        ReservationGridView.DataSource = this.dtReservation;
        ReservationGridView.DataBind();
        reservedItemgrid.DataSource = this.dtItemReservation;
        reservedItemgrid.DataBind();
    }
    }
}