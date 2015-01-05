using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4EVENTS
{
    public partial class Login : System.Web.UI.Page
    {
        LoginAD loginAD;
        protected void Page_Load(object sender, EventArgs e)
        {
            loginAD = new LoginAD();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ///Basic Active directory login (if on server)
            /*
            if (loginAD.Authenticate(tbUsername.Text, tbPassword.Text, "DC=INFRA-S42,DC=local"))
            {
                ///Succes
                ///To-do after programm is on server - Redirect to new page + Add session in Authenticate method
            }
            else
            {
                ///Show error message
                ///To-do after programm is on server - make and show error message
                Response.Write("succes");
            }*/
            

            //Basic replacement for login mechanism while programm is not running on the server
            Session["Username"] = tbUsername.Text;
            Response.Redirect("Home.aspx", true);
        }
    }
}