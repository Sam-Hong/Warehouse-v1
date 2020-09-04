using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //this namespace is for sqlclient server  
using System.Configuration; // this namespace is add I am adding connection name in web config file config connection name


namespace Warehouse
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            try
            {
                string CategoryName = txtCatName.Text;
                string CategoryIndex = TextBoxCategoryIndex.Text;
                string StartTime = TextBox2.Text;
                string EndTime = TextBox3.Text;
                string MaintainMoney = TextBoxMaintainMoney.Text;
                string RepairMoney = TextBoxRepairMoney.Text;

                con.Open();
                string qry = "insert into Category (CategoryName,CategoryIndex,StartTime,EndTime,MaintainMoney,RepairMoney) values ('"+CategoryName+"','"+CategoryIndex+"','"+StartTime+"','"+EndTime+"','"+MaintainMoney+"','"+RepairMoney+"')";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                
                con.Close();

                Response.Redirect("~/CategoryPage.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
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