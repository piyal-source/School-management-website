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
    public partial class Change_Password : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            conn.Open();
            SqlCommand cmnd = new SqlCommand("Select UserId,Password from schoolreg where UserId ='" + Session["UserId"] + "' ", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmnd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if(i>0)
            {
                lbluser.Text = ds.Tables[0].Rows[0]["UserId"].ToString();
            }
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtold.Text == "" || txtnew.Text == "" || txtconfirm.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter all the fields')", true);
            }
            else
            {
                conn.Open();
                if (txtnew.Text == txtconfirm.Text)
                {
                    SqlCommand c1 = new SqlCommand("Select UserId,Password from schoolreg where UserId='" + lbluser.Text + "' and Password = '" + txtold.Text + "' ", conn);
                    SqlDataAdapter da = new SqlDataAdapter(c1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = ds.Tables[0].Rows.Count;
                    if (i > 0)
                    {
                        string updatesql = "update schoolreg set Password = @password where UserId = '" + lbluser.Text + "' ";
                        SqlCommand cmd = new SqlCommand(updatesql, conn);
                        cmd.Parameters.AddWithValue("@password", txtconfirm.Text);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        lblmsg.Text = "Password changed successfully";
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblmsg.Text = "Incorrect Password";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblmsg.Text = "Password did not match";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}