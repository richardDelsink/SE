using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4EVENTS
{
    public partial class Controle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillAccInfoOnBar();
            LoadGrid();
        }



        public void LoadGrid()
        {
            DB.FillDataGrid(gridview);
        }

        public void FillAccInfoOnBar()
        {

            string SubbedString = DB.GetAccountInfo(barcodetb.Text);
            int Index;
            int EndIndex;
            string FinalSubString;

            if (SubbedString != " ")
            {
                Index = SubbedString.IndexOf('@') + 1;
                EndIndex = SubbedString.IndexOf('#');
                FinalSubString = SubbedString.Substring(Index, EndIndex - Index);
                userlabel.Text = FinalSubString;

                Index = SubbedString.IndexOf('#') + 1;
                EndIndex = SubbedString.IndexOf('$');
                FinalSubString = SubbedString.Substring(Index, EndIndex - Index);
                mailLabel.Text = FinalSubString;

                Index = SubbedString.IndexOf('$') + 1;
                EndIndex = SubbedString.IndexOf('%');
                FinalSubString = SubbedString.Substring(Index, EndIndex - Index);

                if (Convert.ToInt32(FinalSubString) == 1)
                {
                    activLabel.Text = "Account is geactiveerd!";
                }
                else if (Convert.ToInt32(FinalSubString) == 0)
                {
                    activLabel.Text = "Account is nog niet geactiveerd!";
                }

                Index = SubbedString.IndexOf('%') + 1;
                EndIndex = SubbedString.IndexOf('>');
                FinalSubString = SubbedString.Substring(Index, EndIndex - Index);
                BarcoLabel.Text = FinalSubString;

                Index = SubbedString.IndexOf('>') + 1;
                EndIndex = SubbedString.IndexOf('<');
                FinalSubString = SubbedString.Substring(Index, EndIndex - Index);
                if (Convert.ToInt32(FinalSubString) == 1)
                {
                    PaidLabel.Text = "Bezoeker heeft de reservering al betaald!";
                }
                else if (Convert.ToInt32(FinalSubString) == 0)
                {

                    PaidLabel.Text = "Bezoeker heeft de reservering nog niet betaald!";
                }

                Index = SubbedString.IndexOf('<') + 1;
                EndIndex = SubbedString.IndexOf('!');
                FinalSubString = SubbedString.Substring(Index, EndIndex - Index);

                if (Convert.ToInt32(FinalSubString) == 1)
                {
                    Presencelbl.Text = "Ingecheckt!";
                }
                else if (Convert.ToInt32(FinalSubString) == 0)
                {
                    Presencelbl.Text = "Uitgecheckt!";
                }

            }
        }

        protected void barcodetb_TextChanged(object sender, EventArgs e)
        {
            Presencelbl.Text = string.Empty;
            PaidLabel.Text = string.Empty;
            userlabel.Text = string.Empty;
            mailLabel.Text = string.Empty;
            BarcoLabel.Text = string.Empty;
            activLabel.Text = string.Empty;



            if (DB.CheckBarcode(barcodetb.Text).Contains("RFID_FOUND!"))
            {
                rfidworth.Text = string.Empty;

                if (barcodetb.Text.Length > 4)
                {
                    FillAccInfoOnBar();
                    LoadGrid();
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