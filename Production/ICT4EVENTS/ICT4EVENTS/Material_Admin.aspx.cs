// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Material_Admin.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The material_ admin.
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
    /// TODO The material_ admin.
    /// </summary>
    public partial class Material_Admin : System.Web.UI.Page
    {
        /// <summary>
        /// TODO The b.
        /// </summary>
        private Business B = new Business();

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
            ItemGridView.DataSource = B.LeasedItemViews(ItemGridView);
            ItemGridView.DataBind();
        }
    }
}