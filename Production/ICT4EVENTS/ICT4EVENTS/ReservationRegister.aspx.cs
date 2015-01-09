using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Businesslayer;

namespace ICT4EVENTS
{
    public partial class ReservationRegister : System.Web.UI.Page
    {
        Reservering db = new Reservering();
        //private string firstname;
        //private string lastname;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ToRegister"] != null)
            {
                if (!this.IsPostBack)
                {
                    
                }
                LblRegister.Text = Session["ToRegister"].ToString();
                //firstname = Request.QueryString["firstname"];
                //lastname = Request.QueryString["lastname"];

            }
        }

        public void GetPersons(int persons)
        {
            Session["ToRegister"] = persons;
        }

        protected void btnSignup_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if ((int)Session["ToRegister"] != 1)
                {
                    Session["ToRegister"] = (int) (Session["ToRegister"]) - 1;
                    db.AddPerson(tbVoornaam.Text, tbtussenvoegsel.Text, tbachternaam.Text, tbstraat.Text, tbhuisnr.Text, tbwoonplaats.Text, tbbanknr.Text);
                    Refresh();
                }
                else
                {
                    db.AddPerson(tbVoornaam.Text, tbtussenvoegsel.Text, tbachternaam.Text, tbstraat.Text, tbhuisnr.Text, tbwoonplaats.Text, tbbanknr.Text);
                    db.AddReservering(Session["Voornaam"].ToString(), Session["Achternaam"].ToString(),(DateTime)Session["starttime"],(DateTime)Session["endtime"],1,(int)Session["places"]);
                    Response.Redirect("Home.aspx", true);
                }
            }
        }

        protected void Refresh()
        {
            if (Session["ToRegister"] != null)
            {
                if (!this.IsPostBack)
                {

                }
                LblRegister.Text = Session["ToRegister"].ToString();
            }
            ClearTextBoxes(Page);
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

        public void GetReservation(int places, DateTime start, DateTime end)
        {
            Session["places"] = places;
            Session["starttime"] = start;
            Session["endtime"] = end;
        }
    }
}