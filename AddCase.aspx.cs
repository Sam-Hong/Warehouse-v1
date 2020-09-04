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
    public partial class AddCase : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategory();
                BindKind();
                BindStatus();
            }
        }
        private void BindCategory()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Category", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryId";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }
        private void BindKind()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Kind", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    DropDownListKind.DataSource = dt;
                    DropDownListKind.DataTextField = "KindName";
                    DropDownListKind.DataValueField = "KindId";
                    DropDownListKind.DataBind();
                    DropDownListKind.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }
        private void BindStatus()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Status", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    DropDownListStatus.DataSource = dt;
                    DropDownListStatus.DataTextField = "StatusName";
                    DropDownListStatus.DataValueField = "StatusId";
                    DropDownListStatus.DataBind();
                    DropDownListStatus.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("insert into Cases (CaseName,CategoryId,KindId,StartTime,EndTime,StatusId,Cost) values('" + txtCatName.Text + "','" + ddlCategory.SelectedItem.Value + "','" + DropDownListKind.SelectedItem.Value + "','" + TextBox2.Text+"','"+TextBox3.Text+ "','" + DropDownListStatus.SelectedItem.Value + "','" + TextBoxCost.Text+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                
                con.Close();

                Response.Redirect("~/Home.aspx");
            }

        }

        protected void StartTime_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar1.SelectedDate.Date.Year.ToString();
            TextBox2.Text += "/" + Calendar1.SelectedDate.Date.Month.ToString();
            TextBox2.Text += "/" + Calendar1.SelectedDate.Date.Day.ToString();

            Calendar1.Visible = false;
        }

        protected void EndTime_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TextBox3.Text = Calendar2.SelectedDate.Date.Year.ToString();
            TextBox3.Text += "/" + Calendar2.SelectedDate.Date.Month.ToString();
            TextBox3.Text += "/" + Calendar2.SelectedDate.Date.Day.ToString();

            Calendar2.Visible = false;
        }
    }
}