// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Events_admin.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The events_admin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

using Businesslayer;

namespace ICT4EVENTS
{
    /// <summary>
    /// TODO The events_admin.
    /// </summary>
    public partial class Events_admin : System.Web.UI.Page
    {
        /// <summary>
        /// TODO The event.
        /// </summary>
        private Events Event = new Events();

        /// <summary>
        /// TODO The ds.
        /// </summary>
        private DataSet ds = new DataSet();

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
            if (Session["Usergroup"] != null)
            {
                if (Session["Usergroup"].ToString() == "1")
                {
                    actionmenu.Visible = true;
                }
                else
                {
                }

                GridView1.DataSource = Event.GetAllEvents();
                GridView1.DataBind();
            }
        }

        /// <summary>
        /// TODO The drop down list 1_ selected index changed.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// TODO The button 1_ click.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// TODO The grid view 1_ selected index changed.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// TODO The chk_ checked changed.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int intRow = GridView1.SelectedRow.RowIndex;

            string strDescription = GridView1.Rows[intRow].Cells[2].Text;
            string strPrice = GridView1.Rows[intRow].Cells[3].Text;
        }

        /// <summary>
        /// TODO The btn delete_ click.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
        }
    }
}