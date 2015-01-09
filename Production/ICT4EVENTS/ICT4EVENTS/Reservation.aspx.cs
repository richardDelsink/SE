using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Businesslayer;
using ICT4EVENTS.Models;

namespace ICT4EVENTS
{
    public partial class Reservation : System.Web.UI.Page
    {
        Reservering db = new Reservering();
        ReservationRegister ResReg = new ReservationRegister();

        private int selected = 0;

        List<string> place = new List<string>();
        private string color;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["selected"] != null)
            {
                selected = (int)Session["selected"];
            }
            if (!this.IsPostBack)
            {
                selected = 0;
                Session["Achternaam"] = Request.QueryString["lastname"];
                Session["Voornaam"] = Request.QueryString["firstname"];
            }
        }

        protected void Getcolor(object sender, EventArgs e)
        {
            place = db.Getplaces();
            Button btn = (Button) sender;
            string number = btn.Text;
            if (btn.BackColor != Color.Blue)
            {
                if (place.Contains(number))
                {
                    btn.BackColor = Color.Red;
                    btn.Enabled = false;
                }
                else
                {
                    btn.BackColor = Color.Green;
                    btn.Enabled = true;
                }
                
            }
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
                    Session["selected"] = 0;
                    selected = 0;
                    break;
                case "Green":
                    btn.BackColor = Color.Blue;
                    Session["selected"] = Convert.ToInt32(btn.Text);
                    color = "Test";
                    break;
            }
        }

        protected void BtnReserveer_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                ResReg.GetPersons(Convert.ToInt16(DropDownList1.SelectedValue));
                ResReg.GetReservation((int)Session["selected"], Calendar1.SelectedDate, Calendar2.SelectedDate);
                Response.Redirect("ReservationRegister.aspx");
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (Calendar1.SelectedDate == null || Calendar1.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0) ||
                Calendar2.SelectedDate == null || Calendar2.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0))
            
                // not click any date
            {
                args.IsValid = false;
            }
            else
                args.IsValid = true;

        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (Calendar1.SelectedDate >= Calendar2.SelectedDate)

            // not click any date
            {
                args.IsValid = false;
            }
            else
                args.IsValid = true;

        }

       protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
               if (selected ==0)

                   // not click any date
               {
                   args.IsValid = false;
               }
               else
               {
                   args.IsValid = true;
               }
        }
    }
}