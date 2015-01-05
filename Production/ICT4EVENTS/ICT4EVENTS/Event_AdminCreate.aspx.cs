using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4EVENTS
{
    public partial class Events_AdminCreate : System.Web.UI.Page
    {
        private List<string> locations;
        DatabaseConnection db = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            locations = db.Locations();
            foreach (string lc in locations)
            {
                DropDownList1.Items.Add(lc);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            db.CreateEvent(TextBox1.Text, Calendar2.SelectedDate, Calendar1.SelectedDate, Convert.ToInt32(TextBox2.Text));
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}