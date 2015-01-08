using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Businesslayer;

namespace ICT4EVENTS
{
    public partial class Material : System.Web.UI.Page
    {
        Business b = new Business();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                b.Materialgrid(gvLeft);
            }
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            GetGr1Rows();
            bindgr2();
        }

        protected void bindgr2()
        {
            DataTable dt = (DataTable)ViewState["Data"];
            gvRight.DataSource = dt;
            gvRight.DataBind();
        }

        private void GetGr1Rows()
        {
            DataTable dt;
            if (ViewState["Data"] != null)
            {
                dt = (DataTable) ViewState["Data"];
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

    }
}