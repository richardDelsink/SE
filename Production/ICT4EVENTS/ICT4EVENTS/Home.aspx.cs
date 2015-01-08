using System;
using System.Collections.Generic;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Session["Usergroup"].ToString() == "1")
            {

            }
            else
            {*/
                FillListBoxes();
           // }
       
        }

        public void FillListBoxes()
        {
            string username = "admin";
            
            ReserverationInfoListBox.Items.Clear();

            List<string> reservationList = new List<string>();

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

        }
    }
}