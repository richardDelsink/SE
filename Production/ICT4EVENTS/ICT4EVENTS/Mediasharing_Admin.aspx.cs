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
        /// TODO The category.
        /// </summary>
        private string file;

        /// <summary>
        /// TODO The category.
        /// </summary>
        private int categoryid;

        /// <summary>
        /// TODO The category.
        /// </summary>
        private List<string> files = new List<string>();


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
            if (fileslist.SelectedItem != null)
            {
                Session["file"] = fileslist.SelectedItem.Text;
            }
            fileslist.Items.Clear();
            //username = Session["Username"].ToString();
            username = "admin";
            Session["category"] = CategorieList.Text;



            CategorieList.Items.Clear();
            if (Session["category"] == null)
            {
                CategorieList.Items.Add(" ");
            }
            else
            {
                CategorieList.Items.Add((string)(Session["category"]));
            }
            if (Session["categoryid"] != null)
            {

                categoryid = (int)(Session["categoryid"]);

                GridView1.DataSource = Accountbijdrage.Comments(categoryid);
                GridView1.DataBind();
            }
            CatList = Accountbijdrage.Getcategory();
            foreach (string cat in CatList)
            {
                CategorieList.Items.Add(cat);
            }



            if (!IsPostBack)
            {
                files = Accountbijdrage.Getfiles();

                foreach (string fil in files)
                {
                    fileslist.Items.Add(fil);
                }
            }
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
            category = (string)(Session["category"]);
            Session["categoryid"] = Accountbijdrage.GetcategoryID(category);
            categoryid = (int)(Session["categoryid"]);

            files = Accountbijdrage.GetfilesOnCategory(category);

            foreach (string fil in files)
            {
                fileslist.Items.Add(fil);
            }
            
            
            GridView1.DataSource = null;
                GridView1.DataBind();
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CategorieList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void fileslist_SelectedIndexChanged1(object sender, EventArgs e)
        {
            category = (string)(Session["category"]);
            file = (string)(Session["file"]);
            Session["categoryid"] = Accountbijdrage.GetcategoryID(file);
            categoryid = (int)(Session["categoryid"]);


            GridView1.DataSource = Accountbijdrage.Comments(categoryid);
            GridView1.DataBind();

            if (category != "")
            {
                files = Accountbijdrage.GetfilesOnCategory(category);

                foreach (string fil in files)
                {
                    fileslist.Items.Add(fil);
                }
            }
            else
            {
                files = Accountbijdrage.Getfiles();

                foreach (string fil in files)
                {
                    fileslist.Items.Add(fil);
                }

            }

        }

        protected void BtnComment_Click(object sender, EventArgs e)
        {
            Accountbijdrage.Addbericht(Accountbijdrage.accountid(username), TextBox2.Text, TextBox1.Text, categoryid);


            if (category != "")
            {
                files = Accountbijdrage.GetfilesOnCategory(category);
                foreach (string fil in files)
                {
                    fileslist.Items.Add(fil);
                }
            }
            else
            {
                files = Accountbijdrage.Getfiles();
                foreach (string fil in files)
                {
                    fileslist.Items.Add(fil);
                }
            }

            fileslist_SelectedIndexChanged1(this, e);
            ClearTextBoxes(Page);

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
    }
}