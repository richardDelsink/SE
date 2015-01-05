using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4EVENTS
{
    public partial class Reservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Click(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            string color = btn.BackColor.Name;
            switch (color)
            {
                case "Red":
                    break;
                case "Blue":
                    btn.BackColor = Color.Green;
                    break;
                case "Green":
                    btn.BackColor = Color.Blue;
                    break;
                default:
                    btn.BackColor = Color.Green;
                    break;
            }
        }
    }
}