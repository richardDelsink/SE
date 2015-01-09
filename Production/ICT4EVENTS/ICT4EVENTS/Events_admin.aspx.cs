
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Businesslayer;

namespace ICT4EVENTS
{
    public partial class Events_admin : System.Web.UI.Page
    {

        Events Event = new Events();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["Usergroup"] != null)
            {
              if (Session["Usergroup"].ToString() == "1")
              {
                  actionmenu.Visible = true;
              }
              else
              {

              }
              GridView1.DataSource = Event.GetAllEvents();
              GridView1.DataBind();

            }
            
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int intRow = GridView1.SelectedRow.RowIndex;

            string strDescription = GridView1.Rows[intRow].Cells[2].Text;
            string strPrice = GridView1.Rows[intRow].Cells[3].Text;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            

        }
    }
}

