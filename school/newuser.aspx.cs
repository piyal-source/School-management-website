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
    public partial class newuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbox1.Text == "" || tbox2.Text == "" || tbox3.Text == "" || tbox4.Text == "" || txtnum.Text == "" || txt_addr.Text == "" || gender.SelectedValue == null || txtdob.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter all the fields')", true);
                }
                else
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
                    con.Open();

                    SqlCommand com = new SqlCommand("select * from schoolreg where UserId = '" + tbox1.Text + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataSet ds1 = new DataSet();
                    da.Fill(ds1);
                    int i = ds1.Tables[0].Rows.Count;
                    if (i > 0)
                    {
                        label9.Text = "Username already exists";
                        label9.ForeColor = System.Drawing.Color.Red;
                        tbox1.Text = "";
                        tbox2.Text = "";
                        tbox3.Text = "";
                        tbox4.Text = ""; 
                        txtnum.Text = "";
                        txt_addr.Text = "";
                        gender.SelectedValue = null;
                        txtdob.Text = "";
                    }
                    else
                    {
                        string insert = "insert into schoolreg(UserId,Password,Name,EMail,Phone,Address,Gender,DOB) values(@user,@pass,@name,@email,@phone,@address,@gender,@dob)";
                        SqlCommand cmd = new SqlCommand(insert, con);
                        cmd.Parameters.AddWithValue("@user", tbox1.Text);
                        cmd.Parameters.AddWithValue("@pass", tbox2.Text);
                        cmd.Parameters.AddWithValue("@name", tbox3.Text);
                        cmd.Parameters.AddWithValue("@email", tbox4.Text);
                        cmd.Parameters.AddWithValue("@phone", txtnum.Text);
                        cmd.Parameters.AddWithValue("@address", txt_addr.Text);
                        cmd.Parameters.AddWithValue("@gender", gender.SelectedValue);
                        cmd.Parameters.AddWithValue("@dob", txtdob.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        label9.Text = "Registration Successful";
                        label9.ForeColor = System.Drawing.Color.Green;
                        button2.Visible = true;
                    }
                }
                   
                   
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}