namespace ICT4EVENTS
{
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Input;
using Businesslayer;

    public partial class Material_Admin : System.Web.UI.Page
    {
        /// <summary>
        /// Necessary to perform actions from the Database.
        /// </summary>
        private Business b = new Business();

        /// <summary>
        /// Occurs when the page loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         protected void Page_Load(object sender, EventArgs e)
        {
            this.ItemGridView.DataSource = this.b.LeasedItemViews(this.ItemGridView);
            this.ItemGridView.DataBind();

            Calendar1.VisibleDate = Convert.ToDateTime("27-12-2013");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ItemGridView.SelectedRow != null)
            {
                this.b.CompleteReservation(Convert.ToInt16(ItemGridView.SelectedRow.Cells[1].Text), Calendar1.SelectedDate);
                ItemGridView.DataSource = this.b.LeasedItemViews(this.ItemGridView);
                    ItemGridView.DataBind();      
            }
            else
            {
                Label2.Visible = true;
                Label2.Text = "Klik eerst op een item!";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ItemGridView.SelectedRow != null)
            {
                if (ItemGridView.SelectedRow.Cells[5].Text == "&nbsp;")
                {
                    Label2.Visible = true;
                    Label2.Text = "Deze reservering is nog niet af!";
                }
                else
                {
                    Label2.Visible = false;
                    this.b.CompletedLease(Convert.ToInt16(this.ItemGridView.SelectedRow.Cells[1].Text));
                    this.ItemGridView.DataSource = this.b.LeasedItemViews(this.ItemGridView);
                    this.ItemGridView.DataBind();
                }
            }
            else
            {
                Label2.Visible = true;
                Label2.Text = "Klik eerst op een item!";
            }
           
        }
    }
}