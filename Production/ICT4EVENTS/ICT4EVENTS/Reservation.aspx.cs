// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Reservation.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The reservation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Businesslayer;

using ICT4EVENTS.Models;

namespace ICT4EVENTS
{
    /// <summary>
    /// TODO The reservation.
    /// </summary>
    public partial class Reservation : System.Web.UI.Page
    {
        /// <summary>
        /// TODO The db.
        /// </summary>
        private Reservering db = new Reservering();

        /// <summary>
        /// TODO The res reg.
        /// </summary>
        private ReservationRegister ResReg = new ReservationRegister();

        /// <summary>
        /// TODO The selected.
        /// </summary>
        private int selected = 0;

        /// <summary>
        /// TODO The place.
        /// </summary>
        private List<string> place = new List<string>();

        /// <summary>
        /// TODO The color.
        /// </summary>
        private string color;

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

        /// <summary>
        /// TODO The getcolor.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void Getcolor(object sender, EventArgs e)
        {
            place = db.Getplaces();
            Button btn = (Button)sender;
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

        /// <summary>
        /// TODO The btn_ click.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void Btn_Click(object sender, EventArgs e)
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
                    break;
                default:
                    btn.BackColor = Color.Green;
                    Session["selected"] = 0;
                    selected = 0;
                    break;
            }
        }

        /// <summary>
        /// TODO The btn reserveer_ click.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void BtnReserveer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ResReg.GetPersons(Convert.ToInt16(DropDownList1.SelectedValue));
                ResReg.GetReservation((int)Session["selected"], Calendar1.SelectedDate, Calendar2.SelectedDate);
                Response.Redirect("ReservationRegister.aspx");
            }
        }

        /// <summary>
        /// TODO The custom validator 1_ server validate.
        /// </summary>
        /// <param name="source">
        /// TODO The source.
        /// </param>
        /// <param name="args">
        /// TODO The args.
        /// </param>
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Calendar1.SelectedDate == null || Calendar1.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0)
                || Calendar2.SelectedDate == null || Calendar2.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0))
            {
                // not click any date
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// TODO The custom validator 3_ server validate.
        /// </summary>
        /// <param name="source">
        /// TODO The source.
        /// </param>
        /// <param name="args">
        /// TODO The args.
        /// </param>
        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Calendar1.SelectedDate >= Calendar2.SelectedDate)
            {
                // Invalid dates clicked
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// TODO The custom validator 2_ server validate.
        /// </summary>
        /// <param name="source">
        /// TODO The source.
        /// </param>
        /// <param name="args">
        /// TODO The args.
        /// </param>
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (selected == 0)
            {
                // not click any place
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}