namespace ICT4EVENTS
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

    /// <summary>
    /// ASP class for access control. 
    /// </summary>
    public partial class Controle : System.Web.UI.Page
    {
        /// <summary>
        /// Needed to initialize information from the database.
        /// </summary>
        private DatabaseConnection db = new DatabaseConnection();

        /// <summary>
        /// Loads the GridViews to be used. 
        /// </summary>
        public void LoadGrid()
        {
            this.db.FillDataGrid(this.gridview);
        }

        /// <summary>
        /// Fills the correct labels with information from the database query.
        /// </summary>
        public void FillAccInfoOnBar()
        {
            string subbedString = this.db.GetAccountInfo(BarcodeTB.Text);
            int index;
            int endIndex;
            string finalSubString;

            if (subbedString != " ")
            {
                index = subbedString.IndexOf('@') + 1;
                endIndex = subbedString.IndexOf('#');
                finalSubString = subbedString.Substring(index, endIndex - index);
                this.userlabel.Text = finalSubString;

                index = subbedString.IndexOf('#') + 1;
                endIndex = subbedString.IndexOf('$');
                finalSubString = subbedString.Substring(index, endIndex - index);
                this.mailLabel.Text = finalSubString;

                index = subbedString.IndexOf('$') + 1;
                endIndex = subbedString.IndexOf('%');
                finalSubString = subbedString.Substring(index, endIndex - index);

                if (Convert.ToInt32(finalSubString) == 1)
                {
                    this.activLabel.Text = "Account is geactiveerd!";
                }
                else if (Convert.ToInt32(finalSubString) == 0)
                {
                    this.activLabel.Text = "Account is nog niet geactiveerd!";
                }

                index = subbedString.IndexOf('%') + 1;
                endIndex = subbedString.IndexOf('>');
                finalSubString = subbedString.Substring(index, endIndex - index);
                this.BarcoLabel.Text = finalSubString;

                index = subbedString.IndexOf('>') + 1;
                endIndex = subbedString.IndexOf('<');
                finalSubString = subbedString.Substring(index, endIndex - index);
                if (Convert.ToInt32(finalSubString) == 1)
                {
                    this.PaidLabel.Text = "Bezoeker heeft de reservering al betaald!";
                }
                else if (Convert.ToInt32(finalSubString) == 0)
                {
                    this.PaidLabel.Text = "Bezoeker heeft de reservering nog niet betaald!";
                }

                index = subbedString.IndexOf('<') + 1;
                endIndex = subbedString.IndexOf('!');
                finalSubString = subbedString.Substring(index, endIndex - index);

                if (Convert.ToInt32(finalSubString) == 1)
                {
                    this.Presencelbl.Text = "Ingecheckt!";
                }
                else if (Convert.ToInt32(finalSubString) == 0)
                {
                    this.Presencelbl.Text = "Uitgecheckt!";
                }
            }
        }

        /// <summary>
        /// Occurs when the page is loads or refreshes
        /// </summary>
        /// <param name="sender">Mandatory for references.</param>
        /// <param name="e">To hold event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

        /// <summary>
        /// Occurs when the text has changed
        /// </summary>
        /// <param name="sender">Mandatory for references.</param>
        /// <param name="e">To hold event data.</param>
        protected void BarcodeTB_TextChanged(object sender, EventArgs e)
        {
            Presencelbl.Text = string.Empty;
            PaidLabel.Text = string.Empty;
            userlabel.Text = string.Empty;
            mailLabel.Text = string.Empty;
            BarcoLabel.Text = string.Empty;
            activLabel.Text = string.Empty;

            if (this.db.CheckBarcode(BarcodeTB.Text).Contains("RFID_Found!"))
            {
                rfidworth.Text = string.Empty;

                if (BarcodeTB.Text.Length > 4)
                {
                    this.FillAccInfoOnBar();
                    this.LoadGrid();
                    BarcodeTB.Text = string.Empty;
                }
            }
            else
            {
                rfidworth.Text = "Barcode is niet bekend!";
                Presencelbl.Text = string.Empty;
                PaidLabel.Text = string.Empty;
                userlabel.Text = string.Empty;
                mailLabel.Text = string.Empty;
                BarcoLabel.Text = string.Empty;
                activLabel.Text = string.Empty;
            }
        }
    }
}