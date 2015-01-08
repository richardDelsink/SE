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
            FillListBoxes();
        }

        public void FillListBoxes()
        {
            foreach (string s in B.ReservationInfo("admin"))
            {
                ReserverationInfoListBox.Items.Add(s);
            }
           
        }
    }
}