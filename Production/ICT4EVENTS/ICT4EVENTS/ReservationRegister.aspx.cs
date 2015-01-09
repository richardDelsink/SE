// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReservationRegister.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The reservation register.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Businesslayer;

namespace ICT4EVENTS
{
    /// <summary>
    /// TODO The reservation register.
    /// </summary>
    public partial class ReservationRegister : System.Web.UI.Page
    {
        /// <summary>
        /// TODO The db.
        /// </summary>
        private Reservering db = new Reservering();

        /// <summary>
        /// TODO The page_ load.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ToRegister"] != null)
            {
                if (!this.IsPostBack)
                {
                }

                LblRegister.Text = Session["ToRegister"].ToString();
            }
        }

        /// <summary>
        /// TODO The get persons.
        /// </summary>
        /// <param name="persons">
        /// TODO The persons.
        /// </param>
        public void GetPersons(int persons)
        {
            Session["ToRegister"] = persons;
        }

        /// <summary>
        /// TODO The btn signup_ on click.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void btnSignup_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if ((int)Session["ToRegister"] != 1)
                {
                    Session["ToRegister"] = (int)Session["ToRegister"] - 1;
                    this.db.AddPerson(
                        tbVoornaam.Text, 
                        tbtussenvoegsel.Text, 
                        tbachternaam.Text, 
                        tbstraat.Text, 
                        tbhuisnr.Text, 
                        tbwoonplaats.Text, 
                        tbbanknr.Text);
                    Refresh();
                }
                else
                {
                    this.db.AddPerson(
                        tbVoornaam.Text, 
                        tbtussenvoegsel.Text, 
                        tbachternaam.Text, 
                        tbstraat.Text, 
                        tbhuisnr.Text, 
                        tbwoonplaats.Text, 
                        tbbanknr.Text);
                    this.db.AddReservering(
                        Session["Voornaam"].ToString(), 
                        Session["Achternaam"].ToString(), 
                        (DateTime)Session["starttime"], 
                        (DateTime)Session["endtime"], 
                        1, 
                        (int)Session["places"]);
                    Response.Redirect("Home.aspx", true);
                }
            }
        }

        /// <summary>
        /// TODO The refresh.
        /// </summary>
        protected void Refresh()
        {
            if (Session["ToRegister"] != null)
            {
                if (!this.IsPostBack)
                {
                }

                LblRegister.Text = Session["ToRegister"].ToString();
            }

            this.ClearTextBoxes(Page);
        }

        /// <summary>
        /// TODO The clear text boxes.
        /// </summary>
        /// <param name="p1">
        /// TODO The p 1.
        /// </param>
        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = string.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        this.ClearTextBoxes(ctrl);
                    }
                }
            }
        }

        /// <summary>
        /// TODO The get reservation.
        /// </summary>
        /// <param name="places">
        /// TODO The places.
        /// </param>
        /// <param name="start">
        /// TODO The start.
        /// </param>
        /// <param name="end">
        /// TODO The end.
        /// </param>
        public void GetReservation(int places, DateTime start, DateTime end)
        {
            Session["places"] = places;
            Session["starttime"] = start;
            Session["endtime"] = end;
        }
    }
}