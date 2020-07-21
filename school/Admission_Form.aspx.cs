using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace school
{
    public partial class Admission_Form : System.Web.UI.Page
    {
        static String imagelink;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
            conn.Open();
            SqlCommand cmnd = new SqlCommand("Select School_Name from sms_school_master where School_Code='" + Session["School_Code"] + "'", conn);
            SqlDataAdapter dt = new SqlDataAdapter(cmnd);
            DataSet ds2 = new DataSet();
            dt.Fill(ds2);
            int i = ds2.Tables[0].Rows.Count;
            if (i > 0)
            {
                School.Text= ds2.Tables[0].Rows[0]["School_Name"].ToString();
            }
            conn.Close();
            load_class();
        }

        //internal void connection()
        //{
        //    throw new NotImplementedException();
        //}

        public void load_class()
        {
            ddlclass.Items.Insert(0, "-Select-");
            ddlclass.Items.Insert(1, "I");
            ddlclass.Items.Insert(2, "II");
            ddlclass.Items.Insert(3, "III");
            ddlclass.Items.Insert(4, "IV");
            ddlclass.Items.Insert(5, "V");
            ddlclass.Items.Insert(6, "VI");
            ddlclass.Items.Insert(7, "VII");
            ddlclass.Items.Insert(8, "VIII");
            ddlclass.Items.Insert(9, "IX");
            ddlclass.Items.Insert(10, "X");
            ddlclass.Items.Insert(11, "XI");
            ddlclass.Items.Insert(12, "XII");
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            try
            {
                //if (FileUpload1.HasFile)
                //{
                //    int imagefilelenth = FileUpload1.PostedFile.ContentLength;
                //    byte[] imgarray = new byte[imagefilelenth];
                //    HttpPostedFile image = FileUpload1.PostedFile;
                //    image.InputStream.Read(imgarray, 0, imagefilelenth);


                //    if (txtname.Text == "" || txtdob.Text == "" || txtadd.Text == "" || txtnum.Text == "" || gender.SelectedItem.Value == null || ddlclass.SelectedItem.Value == null)
                //    {
                //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter all the fields')", true);
                //    }
                //    else
                //    {
                //        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
                //        con.Open();
                //        string insert = "insert into sms_student_application(Student_Name, DOB, Father_Name, Father_Occ, Mother_Name, Mother_Occ, Address, Phone, Gender, Class, Image) values(@name, @dob, @fname, @focc, @mname, @mocc, @add, @phone, @gender, @class, @img)";
                //        SqlCommand cmd = new SqlCommand(insert, con);
                //        cmd.Parameters.AddWithValue("@name", txtname.Text);
                //        cmd.Parameters.AddWithValue("@dob", txtdob.Text);
                //        cmd.Parameters.AddWithValue("@fname", txtfname.Text);
                //        cmd.Parameters.AddWithValue("@focc", txtfocc.Text);
                //        cmd.Parameters.AddWithValue("@mname", txtmname.Text);
                //        cmd.Parameters.AddWithValue("@mocc", txtmocc.Text);
                //        cmd.Parameters.AddWithValue("@add", txtadd.Text);
                //        cmd.Parameters.AddWithValue("@phone", txtnum.Text);
                //        cmd.Parameters.AddWithValue("@gender", gender.SelectedValue);
                //        cmd.Parameters.AddWithValue("@class", ddlclass.SelectedValue);
                //        cmd.Parameters.AddWithValue("@img", imagelink);
                //        cmd.ExecuteNonQuery();
                //        con.Close();
                //        lblmsg.Text = "Application Registered";
                //        lblmsg.ForeColor = System.Drawing.Color.Green;
                //    }
                //}   

                if (txtname.Text == "" || txtdob.Text == "" || txtadd.Text == "" || txtnum.Text == "" || gender.SelectedItem.Value == null || ddlclass.SelectedItem.Value == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter all the fields')", true);
                }
                else
                {

                    if (uploadimage() == true)
                    {
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
                        con.Open();
                        string insert = "insert into sms_student_application1(Student_Name, School_Code, DOB, Father_Name, Father_Occ, Mother_Name, Mother_Occ, Address, Phone, Gender, Class, Image) values(@name,@school, @dob, @fname, @focc, @mname, @mocc, @add, @phone, @gender, @class, @img)";
                        SqlCommand cmd = new SqlCommand(insert, con);
                        cmd.Parameters.AddWithValue("@name", txtname.Text);
                        cmd.Parameters.AddWithValue("@school", Session["School_Code"]);
                        cmd.Parameters.AddWithValue("@dob", txtdob.Text);
                        cmd.Parameters.AddWithValue("@fname", txtfname.Text);
                        cmd.Parameters.AddWithValue("@focc", txtfocc.Text);
                        cmd.Parameters.AddWithValue("@mname", txtmname.Text);
                        cmd.Parameters.AddWithValue("@mocc", txtmocc.Text);
                        cmd.Parameters.AddWithValue("@add", txtadd.Text);
                        cmd.Parameters.AddWithValue("@phone", txtnum.Text);
                        cmd.Parameters.AddWithValue("@gender", gender.SelectedValue);
                        cmd.Parameters.AddWithValue("@class", ddlclass.SelectedValue);
                        cmd.Parameters.AddWithValue("@img", imagelink.ToString());
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblmsg.Text = "Application Registered";
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                    }
                }

            }
            catch(Exception ex)
            {
                Response.Write(ex);
            }
        }

        private Boolean uploadimage()
        {
            Boolean imagesaved = false;
            if (FileUpload1.HasFile == true)
            {

                String contenttype = FileUpload1.PostedFile.ContentType;

                if (contenttype == "image/jpeg")
                {
                    int filesize;
                    filesize = FileUpload1.PostedFile.ContentLength;

                    if (filesize <= 614400)
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                        int height = img.Height;
                        int width = img.Width;
                        FileUpload1.SaveAs(Server.MapPath("~/images/") + txtname.Text + ".jpg");
                        Image1.ImageUrl = "~/images/" + txtname.Text + ".jpg";
                        imagelink = "images/" + txtname.Text + ".jpg";
                        imagesaved = true;
                    }
                    else
                    {
                        lblmsg.Text = "File Size exceeds 600 KB - Please Upload File Size Maximum 600 KB";
                    }

                }
                else
                {
                    lblmsg.Text = "Only JPEG/JPG Image File Acceptable - Please Upload Image File Again";
                }
            }
            else
            {
                lblmsg.Text = "You have not selected any file - Browse and Select File First";
            }

            return imagesaved;

        }
    }
}