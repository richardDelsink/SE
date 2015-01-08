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
    /// Pagina waar de admin een event kan toevoegen
    /// </summary>
    public partial class Event_AdminCreate : System.Web.UI.Page
    {
        /// <summary>
        /// Een list waar alle locaties uit de database in worden opgeslagen.
        /// </summary>
        private List<string> locations;

        /// <summary>
        /// Maakt een instane van de klasse Events uit de Business Layer om gebruik te maken van de database.
        /// </summary>
        private Events evt = new Events();

        /// <summary>
        /// Vult de list 'locations' met de database functie getlocations().
        /// En daar vult hij de dropdownlist met de locaties uit de list locaties.
        /// </summary>
        /// <param name="sender">standard sender</param>
        /// <param name="e">standard e</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.locations = this.evt.GetLocations();
            foreach (string lc in this.locations)
            {
                DropDownList1.Items.Add(lc);
            }
        }

        /// <summary>
        /// Maakt gebruik van de database functie CreateEvent. En geeft de waardes uit de textboxs, dropdownlist en calenders mee als parameters.
        /// Als de waarde van page.isvalid false is dan kun je niks toevoegen aan de database. De waarde van page.IsValid word gezet door de CustomValidator1 en CustomValidator2
        /// </summary>
        /// <param name="sender">standard sender</param>
        /// <param name="e">standard e</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.evt.CreateEvent(this.TextBox1.Text, this.Calendar2.SelectedDate, this.Calendar1.SelectedDate, Convert.ToInt32(this.TextBox2.Text), this.DropDownList1.Text);
                this.ClearTextBoxes(this.Page);
            }
        }

        /// <summary>
        /// Controleert of je wel een startdatum en een einddatum hebt gekozen.
        /// Als je geen datum gekozen hebt dan is args.IsValid false en is page.isvalid ook false.
        /// </summary>
        /// <param name="source">source </param>
        /// <param name="args">args </param>
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Calendar1.SelectedDate == null || Calendar1.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0) ||
                Calendar2.SelectedDate == null || Calendar2.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// Kijk of je wel een naam en maxbezoekers hebt opgegeven, voordat je op de button klikt.
        /// Als de textboxs leeg zijn dan is args.IsValid false en is page.isvalid ook false.
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="args">args</param>
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TextBox1.Text == string.Empty || TextBox2.Text == string.Empty)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// DropDownList1
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Kijkt naar alle controls op de pagina en kijk 1 voor 1 of het een textbox is. 
        /// Als de control een textbox is dan voor de text waarde string.Empty
        /// </summary>
        /// <param name="p1">Parameter voor de Page</param>
        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = string.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        this.ClearTextBoxes(ctrl);
                    }
                }
            }
        }
    }
}