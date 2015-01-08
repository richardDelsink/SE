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





            string username;
            string usergroup;

            //Basic replacement for login mechanism while programm is not running on the server
            Session["Username"] = tbUsername.Text;
            //Check if user is Admin or regular user
            Session["Usergroup"] = loginAD.getUserGroupDB(tbUsername.Text);

            //Debugging, check values of the sessions
            username = Session["Username"].ToString();
            usergroup = Session["Usergroup"].ToString();

            Response.Redirect("Home.aspx", true);
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            //Check if password and confirm password match
            if(loginAD.confirmPassword(tbPassword1.Text, tbPassword2.Text))
            {
                loginAD.addAccount(tbEmail.Text, tbUsernameSU.Text, tbPassword1.Text);
                //Create Useraccount, returns a bool. true if it worked, false if something went wrong
               // if (loginAD.CreateUserAccount(tbUsernameSU.Text, tbPassword1.Text))
               // {
                    //Check if the person has made a reservation, for redirecting purposes
                    if (loginAD.accountReservationCheck(tbFirstName.Text, tbLastName.Text))
                    {
                        Response.Redirect("Home.aspx", true);
                    }
                    else
                    {
                        Response.Redirect("Reservation.aspx?firstname="+tbFirstName.Text+"&lastname="+tbLastName.Text, true);
                    }
            //    }
            //    else
            //    {
                    //Username doesn't exist
            //    }
            }
        }
    }
}