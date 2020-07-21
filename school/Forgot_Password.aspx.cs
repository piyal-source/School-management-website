using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace school
{
    public partial class Forgot_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
            conn.Open();
            SqlCommand cmnd = new SqlCommand("Select * from schoolreg where UserId='" + txtuser.Text + "'", conn);
            SqlDataAdapter dt = new SqlDataAdapter(cmnd);
            DataSet ds2 = new DataSet();
            dt.Fill(ds2);
            int i = ds2.Tables[0].Rows.Count;
            if (i > 0)
            {
                SqlCommand c1 = new SqlCommand("select * from schoolreg where Name='" + txtname.Text + "' and EMail='" + txtmail.Text + "' and Phone='" + txtphone.Text + "' ", conn);
                SqlDataAdapter dt1 = new SqlDataAdapter(c1);
                DataSet ds3 = new DataSet();
                dt1.Fill(ds3);
                int j = ds3.Tables[0].Rows.Count;
                if (j > 0)
                {
                    string password = ds2.Tables[0].Rows[0]["Password"].ToString();
                    lblconfirm.Text = "Your password is" + password;
                    lblconfirm.ForeColor = System.Drawing.Color.Green;
                    Session["UserId"] = txtuser.Text;
                }
                else
                {
                    lblconfirm.Text = "Details did not match the records";
                    lblconfirm.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                lblconfirm.Text = "User Id not found";
                lblconfirm.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}