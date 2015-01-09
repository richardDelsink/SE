using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Businesslayer;

namespace ICT4EVENTS
{
    public partial class Mediasharing_Admin : System.Web.UI.Page
    {
        private Accountbijdrage Accountbijdrage = new Accountbijdrage();
        public string username = string.Empty;
        private List<string> CatList = new List<string>();
        private string category;

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
                CategorieList.Items.Add((string)(Session["category"]));
            }
            
            CatList = Accountbijdrage.Getcategory();
            foreach (string cat in CatList)
            {
                CategorieList.Items.Add(cat);
            }

            fileslist.DataSource = Accountbijdrage.Getfiles();
            fileslist.DataBind();
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                int accountid = 0;
                accountid = Accountbijdrage.Getaccountid(username);
                Accountbijdrage.AddFiletoFTP(this.FileUpload1.FileName, this.FileUpload1.PostedFile.ContentLength, this.categoriecb.SelectedItem.ToString());
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
    


        protected void fileslist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CategorieList_TextChanged(object sender, EventArgs e)
        {
            category = (string)(Session["category"]);
            fileslist.DataSource = Accountbijdrage.GetfilesOnCategory(category);
            fileslist.DataBind();
        }


        protected void rbtnSelect_CheckedChanged(object sender, EventArgs e)
        {
           
        }





    }
}