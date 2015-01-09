using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4EVENTS
{
    using Businesslayer;

    public partial class About : Page
    {
       private Accountbijdrage Accountbijdrage= new Accountbijdrage();

        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void categoriecb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}