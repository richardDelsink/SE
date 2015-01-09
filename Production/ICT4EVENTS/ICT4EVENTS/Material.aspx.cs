// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Material.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   TODO The material.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Businesslayer;

namespace ICT4EVENTS
{
    /// <summary>
    /// TODO The material.
    /// </summary>
    public partial class Material : System.Web.UI.Page
    {
        /// <summary>
        /// TODO The b.
        /// </summary>
        private Business b = new Business();

        #region pageload

        /// <summary>
        /// TODO The page_ load.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1 keer een grid vullen met data
            if (!IsPostBack)
            {
                b.Materialgrid(gvLeft);
            }

            // Insert ingeloggde naam om ID terug te krijgen van verhuur
            b.naamReturn(Session["Username"].ToString());
        }

        #endregion

        #region Check change

        /// <summary>
        /// TODO The chk_ checked changed.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            // Als er iets veranderd
            GetGr1Rows();
            bindgr2();
        }

        #endregion

        #region bind data naar tweede grid

        /// <summary>
        /// TODO The bindgr 2.
        /// </summary>
        protected void bindgr2()
        {
            DataTable dt = (DataTable)ViewState["Data"];
            gvRight.DataSource = dt;
            gvRight.DataBind();
        }

        #endregion

        #region terug krijgen van de rijen

        // als bij de eerste grid is geselecteerd dan komt er bij de 2de dezelfde row als deze niet is geselecteerd dan niet
        /// <summary>
        /// TODO The get gr 1 rows.
        /// </summary>
        private void GetGr1Rows()
        {
            DataTable dt;
            if (ViewState["Data"] != null)
            {
                dt = (DataTable)ViewState["Data"];
            }
            else
            {
                dt = TempTable();
            }

            for (int i = 0; i < gvLeft.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvLeft.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvLeft.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvLeft.Rows[i], dt);
                }
            }

            ViewState["Data"] = dt;
        }

        #endregion

        #region temp datatable

        /// <summary>
        /// TODO The temp table.
        /// </summary>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        private DataTable TempTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id");
            dt.Columns.Add("Merk");
            dt.Columns.Add("Serie");
            dt.Columns.Add("Naam");
            dt.Columns.Add("prijs");
            dt.AcceptChanges();
            return dt;
        }

        #endregion

        #region toevoegen van een regel

        // voor elke kolom defineren en toevoegen
        /// <summary>
        /// TODO The add row.
        /// </summary>
        /// <param name="gvRow">
        /// TODO The gv row.
        /// </param>
        /// <param name="dt">
        /// TODO The dt.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        private DataTable AddRow(GridViewRow gvRow, DataTable dt)
        {
            DataRow[] dr = dt.Select("id = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length <= 0)
            {
                dt.Rows.Add();
                int rowscount = dt.Rows.Count - 1;
                dt.Rows[rowscount]["Id"] = gvRow.Cells[1].Text;
                dt.Rows[rowscount]["Merk"] = gvRow.Cells[2].Text;
                dt.Rows[rowscount]["Serie"] = gvRow.Cells[3].Text;
                dt.Rows[rowscount]["Naam"] = gvRow.Cells[4].Text;
                dt.Rows[rowscount]["prijs"] = gvRow.Cells[5].Text;
            }

            return dt;
        }

        #endregion

        #region verwijder regel

        // als het niet geselecteerd is word het verwijderd
        /// <summary>
        /// TODO The remove row.
        /// </summary>
        /// <param name="gvRow">
        /// TODO The gv row.
        /// </param>
        /// <param name="dt">
        /// TODO The dt.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
        {
            DataRow[] dr = dt.Select("id = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length > 0)
            {
                dt.Rows.Remove(dr[0]);
                dt.AcceptChanges();
            }

            return dt;
        }

        #endregion

        #region material reserveren button

        // Voor elke rij in de grid wordt er data toegevoegd
        /// <summary>
        /// TODO The mat reserv_ click.
        /// </summary>
        /// <param name="sender">
        /// TODO The sender.
        /// </param>
        /// <param name="e">
        /// TODO The e.
        /// </param>
        protected void MatReserv_Click(object sender, EventArgs e)
        {
            int test = b.Id();
            foreach (GridViewRow g in gvRight.Rows)
            {
                if (g != null)
                {
                    b.MaterialReservation(Convert.ToInt32(g.Cells[0].Text), test, 0, Convert.ToInt32(g.Cells[4].Text));
                }
            }
        }

        #endregion
    }
}