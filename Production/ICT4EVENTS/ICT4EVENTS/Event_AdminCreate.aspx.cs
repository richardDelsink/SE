using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Businesslayer;

namespace ICT4EVENTS
{
    public partial class Event_AdminCreate : System.Web.UI.Page
    {
        private List<string> locations;
        Events Event = new Events();

        
        protected void Page_Load(object sender, EventArgs e)
        {

            locations = Event.GetLocations();
            foreach (string lc in locations)
            {
                DropDownList1.Items.Add(lc);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Event.CreateEvent(TextBox1.Text, Calendar2.SelectedDate, Calendar1.SelectedDate, Convert.ToInt32(TextBox2.Text), DropDownList1.Text);
            ClearTextBoxes(Page);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }
    }
}