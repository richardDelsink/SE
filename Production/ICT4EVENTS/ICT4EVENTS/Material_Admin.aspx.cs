using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Businesslayer;

namespace ICT4EVENTS
{
    public partial class Material_Admin : System.Web.UI.Page
    {
        Business B = new Business();
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemGridView.DataSource = B.LeasedItemViews(ItemGridView);
            ItemGridView.DataBind();
        }
    }
}