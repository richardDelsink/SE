using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4EVENTS
{
    public partial class Events_admin : System.Web.UI.Page
    {
        DatabaseConnection db = new DatabaseConnection();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = db.GetEvents();
            GridView1.DataBind();
            
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}