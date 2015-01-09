// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mediasharing_Admin.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The mediasharing_ admin.
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
    /// TODO The mediasharing_ admin.
    /// </summary>
    public partial class Mediasharing_Admin : System.Web.UI.Page
    {
        /// <summary>
        /// TODO The accountbijdrage.
        /// </summary>
        private Accountbijdrage Accountbijdrage = new Accountbijdrage();

        /// <summary>
        /// TODO The username.
        /// </summary>
        public string username = string.Empty;

        /// <summary>
        /// TODO The cat list.
        /// </summary>
        private List<string> CatList = new List<string>();

        /// <summary>
        /// TODO The category.
        /// </summary>
        private string category;

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
            username = Session["Username"].ToString();
            Session["category"] = CategorieList.Text;
            CategorieList.Items.Clear();
            if (Session["category"] == null)
            {
                CategorieList.Items.Add(" ");
            }
            else
            {
                CategorieList.Items.Add((string)Session["category"]);
            }

            CatList = Accountbijdrage.Getcategory();
            foreach (string cat in CatList)
            {
                CategorieList.Items.Add(cat);
            }

            fileslist.DataSource = Accountbijdrage.Getfiles();
            fileslist.DataBind();
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
        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                int accountid = 0;
                accountid = Accountbijdrage.Getaccountid(username);
                Accountbijdrage.AddFiletoFTP(
                    this.FileUpload1.FileName, 
                    this.FileUpload1.PostedFile.ContentLength, 
                    this.categoriecb.SelectedItem.ToString());
                Accountbijdrage.AddFiletoDb(
                    accountid, 
                    this.FileUpload1.FileName, 
                    this.FileUpload1.PostedFile.ContentLength, 
                    categoriecb.SelectedItem.ToString());
            }
            else
            {
                Response.Write("get a file");
            }
        }

        /// <summary>
        /// TODO The fileslist_ selected index changed.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void fileslist_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// TODO The categorie list_ text changed.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void CategorieList_TextChanged(object sender, EventArgs e)
        {
            category = (string)Session["category"];
            fileslist.DataSource = Accountbijdrage.GetfilesOnCategory(category);
            fileslist.DataBind();
        }

        /// <summary>
        /// TODO The rbtn select_ checked changed.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void rbtnSelect_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}