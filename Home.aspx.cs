﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warehouse
{
    public partial class Home : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCaseRptr();
            }
        }
        
        private void BindCaseRptr()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select A.*,B.*,C.*,D.* from Cases as A inner join Category as B on A.CategoryId=B.CategoryId inner join Kind as C on A.KindId=C.KindId inner join Status as D on A.StatusId=D.StatusId", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtCase = new DataTable();
                        sda.Fill(dtCase);
                        if (dtCase.Rows.Count > 0)
                        {
                            RepeaterCases.DataSource = dtCase;
                            RepeaterCases.DataBind();
                        }
                        else
                        {
                            NoCaseData.Text = "查無資料";
                        }

                    }

                }
            }
        }
    }
}