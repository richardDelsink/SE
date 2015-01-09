using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Businesslayer;

namespace ICT4EVENTS
{
    public partial class _Default : Page
    {
         Business B = new Business();
        private string username = "admin";
        private DataTable dtReservation;
        private DataTable dtItemReservation;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Session["Usergroup"].ToString() == "1")
            {

            }
            else
            {*/
                 dtReservation = new DataTable();
                 dtItemReservation = new DataTable();
                 MakeDataTable();
                 AddToDataTable();
                 BindGrids();

            // }

        }

        private void MakeDataTable()
        {
            dtReservation.Columns.Add("ReservationID");
            dtReservation.Columns.Add("PersoonsID");
            dtReservation.Columns.Add("Startdatum reservering");
            dtReservation.Columns.Add("Einddatum reservering");
            dtReservation.Columns.Add("Betaalstatus");
            dtReservation.Columns.Add("Kampeerplaatsen");

            //"datumIn" as UITLEENDATUM, v."datumUit" as TERUGBRENGDATUM , p."merk" as MERK, pc."naam" as NAAM, v."prijs" as PRIJS 
            dtItemReservation.Columns.Add("Uitleendatum");
            dtItemReservation.Columns.Add("Terugbrengdatum");
            dtItemReservation.Columns.Add("Merk");
            dtItemReservation.Columns.Add("Naam");
            dtItemReservation.Columns.Add("Prijs");
        }

        private void AddToDataTable()
     {
            DataRow dr = dtReservation.NewRow();
           

            List<string> Inhoud = new List<string>();
            Inhoud = B.ReservationInfo(username);

            dr["ReservationID"] = Inhoud.ElementAt(0);
            dr["PersoonsID"] = Inhoud.ElementAt(1);
            dr["Startdatum Reservering"] = Inhoud.ElementAt(2);
            dr["Einddatum Reservering"] = Inhoud.ElementAt(3); ;
            dr["Betaalstatus"] = Inhoud.ElementAt(4);

            string campspots = string.Empty;
            for (int i = 0; i < B.CampNumbersInfo(username).Count; i++)
            {
                if (i >= 1)
                {
                    campspots = campspots + "," + B.CampNumbersInfo(username).ElementAt(i);
                }
                else
                {
                    campspots = campspots + B.CampNumbersInfo(username).ElementAt(i);
                }
               
            }

            dr["Kampeerplaatsen"] = campspots;
            dtReservation.Rows.Add(dr);


            for (int i = 0; i < B.ReserveditemsList(username).Count; i++)
            {

                DataRow dr2 = dtItemReservation.NewRow();

                string subbedString = B.ReserveditemsList(username).ElementAt(i);
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

                    dtItemReservation.Rows.Add(dr2);
                 
                }

               
            }

     }

    private void BindGrids()
    {
        ReservationGridView.DataSource = dtReservation;
        ReservationGridView.DataBind();

        reservedItemgrid.DataSource = dtItemReservation;
        reservedItemgrid.DataBind();
    }

        /*
        public void FillListBoxes()
        {
            string username = "admin";
            B.ReserveditemsList(reservedItemgrid, username);

            GridViewRow Row = new GridViewRow();
        
            
            ReservationGridView.add
            ReserverationInfoListBox.Items.Clear();

            List<string> reservationList = new List<string>();
            List<string> reservationitemList = new List<string>();
            reservationList = B.ReservationInfo(username);
       

                string ResID = "ReserveringsID:      " + reservationList.ElementAt(0);
                string Personen = "AccountID:       " +  reservationList.ElementAt(1);
                string start = "Aankomstdatum reservering:        " + reservationList.ElementAt(2);
                string stop = "Einddatum reservering:        " + reservationList.ElementAt(3);
                string bestaald = reservationList.ElementAt(4); 

                ReserverationInfoListBox.Items.Add(ResID);
                ReserverationInfoListBox.Items.Add(Personen);
                ReserverationInfoListBox.Items.Add(start);
                ReserverationInfoListBox.Items.Add(stop);
                ReserverationInfoListBox.Items.Add(bestaald);

            string Kampeer = "Kampeerplaatsen:  ";
            for (int i = 0; i < B.CampNumbersInfo(username).Count; i++)
            {
                Kampeer += B.CampNumbersInfo(username).ElementAt(i) + ",";
            }

            ReserverationInfoListBox.Items.Add(Kampeer);
           
        } */

        
    }
}