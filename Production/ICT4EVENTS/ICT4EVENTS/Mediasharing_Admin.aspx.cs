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
        private List<string> CatList = new List<string>();
        private string category;

        protected void Page_Load(object sender, EventArgs e)
        {
            
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

            fileslist.DataSource = Accountbijdrage.Getfilelist();
            fileslist.DataBind();
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void fileslist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CategorieList_TextChanged(object sender, EventArgs e)
        {
            category = (string)(Session["category"]);
            fileslist.DataSource = Accountbijdrage.GetFilesOnCategory(category);
            fileslist.DataBind();
        }


        protected void rbtnSelect_CheckedChanged(object sender, EventArgs e)
        {
           
        }





    }
}