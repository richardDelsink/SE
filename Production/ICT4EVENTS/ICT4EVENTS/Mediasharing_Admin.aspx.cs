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

        protected void Page_Load(object sender, EventArgs e)
        {
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

        }


        protected void rbtnSelect_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectButton = (RadioButton)sender;
            GridViewRow row = (GridViewRow)selectButton.Parent.Parent;
            int a = row.RowIndex;
            foreach (GridViewRow rw in fileslist.Rows)
            {
                if (selectButton.Checked)
                {
                    if (rw.RowIndex != a)
                    {
                        RadioButton rd = rw.FindControl("rbtnSelect") as RadioButton;
                        rd.Checked = false;
                    }
                }
            }
        }




    }
}