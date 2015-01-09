// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mediasharing.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The about.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4EVENTS
{
    using Businesslayer;

    /// <summary>
    /// TODO The about.
    /// </summary>
    public partial class About : Page
    {
        /// <summary>
        /// TODO The accountbijdrage.
        /// </summary>
        private Accountbijdrage Accountbijdrage = new Accountbijdrage();

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
        }

        /// <summary>
        /// TODO The categoriecb_ on selected index changed.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        protected void categoriecb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO The btn upload_ on click.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}