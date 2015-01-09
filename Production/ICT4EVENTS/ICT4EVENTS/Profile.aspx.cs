namespace ICT4EVENTS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Businesslayer;

    /// <summary>
    /// Class which loads the information of the logged in user. 
    /// </summary>
    public partial class Profile : System.Web.UI.Page
    {
        /// <summary>
        /// Necessary to get information from the database.
        /// </summary>
        private Business b = new Business();

        /// <summary>
        /// Fills the textboxes with the correct information
        /// </summary>
        public void FillTextBoxes()
        {
        
            List<string> inhoud = this.b.UserInfo(Session["Username"].ToString());
            this.UserLB.Text = inhoud.ElementAt(0);
            this.PassLB.Text = inhoud.ElementAt(1);

            string pwstring = PassLB.Text;
            string pwnew = string.Empty;

            for (int i = 0; i < pwstring.Length; i++)
            {
                pwstring = pwstring.Replace(pwstring.ElementAt(i), '*');
                pwnew += pwstring.ElementAt(i);
            }

            this.PassLB.Text = pwnew;
            this.MailLB.Text = inhoud.ElementAt(2);
        }

        /// <summary>
        /// Occurs when the profile page loads.
        /// </summary>
        /// <param name="sender">needed as a base class</param>
        /// <param name="e">needed to execute events</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.FillTextBoxes();
        }
    }
}