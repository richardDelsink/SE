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
        protected void Page_Load(object sender, EventArgs e)
        {
            
            fileslist.DataSource = Accountbijdrage.Getcategory();
            fileslist.DataBind();
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}