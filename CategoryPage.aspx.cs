using System;
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
    public partial class CategoryPage : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryRptr();
            }
        }
        private void BindCategoryRptr()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Category", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtCategory = new DataTable();
                        sda.Fill(dtCategory);
                        if (dtCategory.Rows.Count > 0)
                        {
                            rptrCategory.DataSource = dtCategory;
                            rptrCategory.DataBind();
                        }
                        else
                        {
                            NoCategoryData.Text = "查無資料";
                        }

                    }

                }
            }
        }
    }
}