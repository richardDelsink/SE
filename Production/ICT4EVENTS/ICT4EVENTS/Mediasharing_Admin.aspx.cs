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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["Username"].ToString();
            categorylist.DataSource = Accountbijdrage.Getcategory();
            categorylist.DataBind();
            fileslist.DataSource = Accountbijdrage.Getfilelist();
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
    }
}