using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

namespace school
{
    public partial class Slider : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Clear();
            label2.Text = "";
            if (!IsPostBack)
            {
                FillCapctha();
            }
        }

        void FillCapctha()
        {
            try
            {
                Random random = new Random();
                string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                StringBuilder captcha = new StringBuilder();
                for (int i = 0; i < 6; i++)
                    captcha.Append(combination[random.Next(combination.Length)]);
                //captchatext.Text = captcha.ToString();
                Session["captcha"] = captcha.ToString();
                imgcaptcha.ImageUrl = "Captcha.aspx?" + DateTime.Now.Ticks.ToString();
            }
            catch
            {

                throw;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("newuser.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
            conn.Open();
            SqlCommand cmnd = new SqlCommand("Select * from schoolreg where UserId='" + txt1.Text + "'", conn);
            SqlDataAdapter dt = new SqlDataAdapter(cmnd);
            DataSet ds2 = new DataSet();
            dt.Fill(ds2);
            int i = ds2.Tables[0].Rows.Count;
            if(i>0)
            {
                SqlCommand c1 = new SqlCommand("select * from schoolreg where Password='" + txt2.Text + "'", conn);
                SqlDataAdapter dt1 = new SqlDataAdapter(c1);
                DataSet ds3 = new DataSet();
                dt1.Fill(ds3);
                int j = ds3.Tables[0].Rows.Count;
                if(j>0)
                {
                    if (Session["captcha"].ToString() == txtcap.Text)
                    {
                        Response.Write("Valid Captcha Code");
                        FillCapctha();
                        label2.Text = "Login Successfull";
                        label2.ForeColor = System.Drawing.Color.Green;
                        Session["UserId"] = txt1.Text;
                        Response.Redirect("User_Dashboard.aspx");
                    }
                    else
                        Response.Write("Valid Captcha Code");
                    label2.Text = "Login Failed";
                    label2.ForeColor = System.Drawing.Color.Red;
                    txt1.Text = "";

                }
                else
                {
                    label2.Text = "Login Failed";
                    label2.ForeColor = System.Drawing.Color.Red;
                    txt1.Text = "";
                }

            }
            else
            {
                label2.Text = "Login Failed";
                label2.ForeColor = System.Drawing.Color.Red;
                txt1.Text = "";
            }
            
        }
        

        protected void refreshbtn_Click(object sender, ImageClickEventArgs e)
        {
            FillCapctha();
        }
    }
}