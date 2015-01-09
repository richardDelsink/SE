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

            if (!IsPostBack)
            {

                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    tbUsername.Text = Request.Cookies["UserName"].Value;
                    tbPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                    chkBox.Checked = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //  on server enable
            //  activeDirectoryLogin();

            //Use when you are not on the server
            localLogin();

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            if (loginAD.checkUsernameExist(tbUsernameSU.Text) == false)
            {
                //Check if password and confirm password match
                if (loginAD.confirmPassword(tbPassword1.Text, tbPassword2.Text))
                {
                    //Add account to database
                    loginAD.addAccount(tbEmail.Text, tbUsernameSU.Text, tbPassword1.Text);

                    //Check if the person has made a reservation, for redirecting purposes
                    if (loginAD.accountReservationCheck(tbFirstName.Text, tbLastName.Text))
                    {
                        Response.Redirect("Home.aspx", true);
                    }
                    else
                    {
                        Response.Redirect("Reservation.aspx?firstname=" + tbFirstName.Text + "&lastname=" + tbLastName.Text, true);
                    }
                }
            }
            else
            {
                //Username already exists
                lblUsernameError.Visible = true;
            }

            //Activate on server
            //activeDirectorySignUp();
        }
        private void activeDirectoryLogin()
        {
            ///Basic Active directory login (if on server)
            if (loginAD.Authenticate(tbUsername.Text, tbPassword.Text, "DC=INFRA-S42,DC=local"))
            {
                ///Succes
                ///Create sessions to enable the rest of the pages to check who is logged in, and what his/hers usertype is
                Session["Username"] = tbUsername.Text;
                Session["Usergroup"] = loginAD.getUserGroupDB(tbUsername.Text);

                ///Check if remember me is checked, if so create cookies if not delete cookies
                if (chkBox.Checked == true)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["UserName"].Value = tbUsername.Text.Trim();
                    Response.Cookies["Password"].Value = tbPassword.Text.Trim();
                }
                else
                {
                    if (Request.Cookies["UserName"] != null || Request.Cookies["Password"] != null)
                    {
                        Response.Cookies.Remove("Username");
                        Response.Cookies.Remove("Password");
                    }
                }

                Response.Redirect("Home.aspx");
            }
            else
            {
                ///Show error message because we couldn't authenticate the account
                lblLoginError.Visible = true;
            }
        }
        private void localLogin()
        {
            string username;
            string usergroup;

            //Basic replacement for login mechanism while programm is not running on the server
            Session["Username"] = tbUsername.Text;
            //Check if user is Admin or regular user
            Session["Usergroup"] = loginAD.getUserGroupDB(tbUsername.Text);

            //Debugging, check values of the sessions
            username = Session["Username"].ToString();
            usergroup = Session["Usergroup"].ToString();

            //Create cookies for remember me
            if (chkBox.Checked == true)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["UserName"].Value = tbUsername.Text.Trim();
                Response.Cookies["Password"].Value = tbPassword.Text.Trim();
            }
            else
            {
                if (Request.Cookies["UserName"] != null || Request.Cookies["Password"] != null)
                {
                    Response.Cookies.Remove("Username");
                    Response.Cookies.Remove("Password");
                }
            }



            Response.Redirect("Home.aspx", true);
        }
        private void activeDirectorySignUp()
        {
            //Check if username already exists
            if (loginAD.checkUsernameExist(tbUsernameSU.Text) == false)
            {
                //Check if password and confirm password match
                if (loginAD.confirmPassword(tbPassword1.Text, tbPassword2.Text))
                {
                    //Create Useraccount, returns a bool. true if it worked, false if something went wrong
                    if (loginAD.CreateUserAccount(tbUsernameSU.Text, tbPassword1.Text))
                    {
                        //Add account to database
                        loginAD.addAccount(tbEmail.Text, tbUsernameSU.Text, tbPassword1.Text);

                        //Check if the person has made a reservation, for redirecting purposes
                        if (loginAD.accountReservationCheck(tbFirstName.Text, tbLastName.Text))
                        {
                            Response.Redirect("Home.aspx", true);
                        }
                        else
                        {
                            //redirect with querystring, for use in the reservationpage
                            Response.Redirect("Reservation.aspx?firstname=" + tbFirstName.Text + "&lastname=" + tbLastName.Text, true);
                        }
                    }
                    else
                    {
                        //Account creation failed, probably invalid information (example: Admin as username)
                    }
                }
            }
            else
            {
                //Username already exists
            }
        }
    }
}