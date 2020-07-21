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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace school
{
    public partial class Vacancy_Master : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnsave.Visible = true;
            //btnupdate.Visible = false;
            ddldist.Enabled = true;
            ddlsub.Enabled = false;
            ddlschool.Enabled = false;
            if (!IsPostBack)
            {
                load_dist();
                load_grid();
            }
        }

        public void load_dist()
        {
            string com = "select * from Dist_List";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddldist.DataSource = dt;
            ddldist.DataBind();

            ddldist.Items.Insert(0, "-Select-");
        }

        public void load_subdiv()
        {
            string com = "select * from SMS_Sub_Division";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlsub.DataSource = dt;
            ddlsub.DataBind();

            ddlsub.Items.Insert(0, "-Select-");
        }

        public void load_school()
        {
            string com = "select * from sms_school_master";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlschool.DataSource = dt;
            ddlschool.DataBind();

            ddlschool.Items.Insert(0, "-Select-");
        }

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

        public void load_grid()
        {
            string sqlgrid = "Select Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_vacancy.School_Code, sms_school_master.School_Name, sms_school_vacancy.Class, sms_school_vacancy.Vacancy from (((sms_school_vacancy inner join Dist_List on sms_school_vacancy.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_vacancy.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) inner join sms_school_master on sms_school_vacancy.School_Code=sms_school_master.School_Code) order by Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name, sms_school_vacancy.Class";
            SqlCommand cmd = new SqlCommand(sqlgrid, con);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    schgrid.DataSource = dt;
                    schgrid.DataBind();
                }
            }
        }

        protected void ddlsub_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlschool.Items.Clear();
            ddlclass.Items.Clear();
            txtvacancy.Text = "";
            if (ddlsub.Text == "-Select-")
            {
                ddlschool.Enabled = false;
                ddlclass.Enabled = false;
                txtvacancy.Enabled = false;
            }
            else
            {
                ddlschool.Enabled = true;
                txtvacancy.Enabled = true;
                ddlclass.Enabled = true;
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from sms_school_master where Sub_Div_Code='" + ddlsub.SelectedItem.Value + "' ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                ddlschool.DataSource = dt;
                ddlschool.DataBind();
                con.Close();
                ddlschool.Items.Insert(0, "-Select-");
                load_class();
            }
        }

        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlsub.Items.Clear();
            ddlschool.Items.Clear();
            ddlclass.Items.Clear();
            txtvacancy.Text = "";
            if (ddldist.Text == "-Select-")
            {
                ddlsub.Enabled = false;
                ddlschool.Enabled = false;
                txtvacancy.Enabled = false;
                ddlclass.Enabled = false;
            }
            else
            {
                ddlsub.Enabled = true;
                SqlCommand cmd = new SqlCommand("select * from SMS_Sub_Division where Dist_Code='" + ddldist.SelectedItem.Value + "' ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                ddlsub.DataSource = dt;
                ddlsub.DataBind();
                ddlsub.Items.Insert(0, "-Select-");
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string qry1 = "Select * from sms_school_vacancy where Dist_Code='" + ddldist.SelectedItem.Value + "' and Sub_Div_Code ='" + ddlsub.SelectedItem.Value + "' and School_Code = '" + ddlschool.SelectedItem.Value + "' and Class = '" + ddlclass.SelectedItem.Value + "' ";
            SqlCommand cmnd = new SqlCommand(qry1, con);
            SqlDataAdapter da = new SqlDataAdapter(cmnd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int c = 0;
            try
            {
                if (ddlschool.Text == "-Select-" || txtvacancy.Text == "" || ddldist.Text == "-Select-" || ddlsub.Text == "-Select-" || ddlclass.Text == "-Select-")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter all the fields')", true);
                }
                else if (ds.Tables[0].Rows.Count > 0)
                {
                    string updatesql = "UPDATE sms_school_vacancy SET Class = @class, Vacancy = @vacancy WHERE School_Code = @code";
                    SqlCommand cmd = new SqlCommand(updatesql, con);
                    cmd.Parameters.AddWithValue("@code", ddlschool.SelectedValue);
                    cmd.Parameters.AddWithValue("@vacancy", txtvacancy.Text);
                    cmd.Parameters.AddWithValue("@class", ddlclass.SelectedValue);
                    con.Open();
                    c = cmd.ExecuteNonQuery();
                    if (c > 0)
                    {
                        con.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data updated successfully')", true);
                        ddlsub.Items.Clear();
                        ddldist.Items.Clear();
                        ddlschool.Items.Clear();
                        ddlclass.Items.Clear();
                        load_dist();
                        load_subdiv();
                        load_school();
                        load_class();
                        load_grid();
                        txtvacancy.Text = null;
                    }
                    else
                    {
                        con.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Oops Server error')", true);
                    }
                }
                else
                {
                    string insert = "insert into sms_school_vacancy (Dist_Code,Sub_Div_Code, School_Code, Class, Vacancy) values(@dist, @sub, @school, @class, @vacancy)";
                    SqlCommand cmd = new SqlCommand(insert, con);
                    cmd.Parameters.AddWithValue("@dist", ddldist.SelectedValue);
                    cmd.Parameters.AddWithValue("@sub", ddlsub.SelectedValue);
                    cmd.Parameters.AddWithValue("@school", ddlschool.SelectedValue);
                    cmd.Parameters.AddWithValue("@class", ddlclass.SelectedValue);
                    cmd.Parameters.AddWithValue("@vacancy", txtvacancy.Text);
                    con.Open();

                    c = cmd.ExecuteNonQuery();

                    if (c > 0)
                    {
                        con.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data inserted successfully')", true);
                        ddlsub.Items.Clear();
                        ddldist.Items.Clear();
                        ddlschool.Items.Clear();
                        ddlclass.Items.Clear();
                        load_dist();
                        load_subdiv();
                        load_school();
                        load_class();
                        load_grid();
                        txtvacancy.Text = "";
                    }
                    else
                    {
                        con.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Oops Server error')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void btnpdf_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.ContentType = "Application/PDF";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename= Vacancy_Master.pdf");
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            string qry1 = "Select Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_vacancy.School_Code, sms_school_master.School_Name, sms_school_vacancy.Class, sms_school_vacancy.Vacancy from (((sms_school_vacancy inner join Dist_List on sms_school_vacancy.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_vacancy.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) inner join sms_school_master on sms_school_vacancy.School_Code=sms_school_master.School_Code) order by Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name, sms_school_vacancy.Class";
            SqlCommand cmd = new SqlCommand(qry1, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            iTextSharp.text.Table tb = new iTextSharp.text.Table(5);
            tb.BorderWidth = 0.6f;
            tb.BorderColor = new Color(0, 0, 0);
            tb.CellsFitPage = true;
            tb.Padding = 2;
            tb.Width = 90;

            //Single widths = new Single() [ 5, 5];
            //tb.Widths = widths;


            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt;
                dt = ds.Tables[0];

                Paragraph p31 = new Paragraph("District", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_1 = new iTextSharp.text.Cell(p31);
                tcell_1.Header = true;
                tcell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_1.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_1);
                tb.EndHeaders();

                Paragraph p32 = new Paragraph("Sub Division", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_2 = new iTextSharp.text.Cell(p32);
                tcell_2.Header = true;
                tcell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_2.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_2);
                tb.EndHeaders();

                Paragraph p33 = new Paragraph("School", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_3 = new iTextSharp.text.Cell(p33);
                tcell_3.Header = true;
                tcell_3.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_3.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_3);
                tb.EndHeaders();

                Paragraph p34 = new Paragraph("Class", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_4 = new iTextSharp.text.Cell(p34);
                tcell_4.Header = true;
                tcell_4.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_4.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_4);
                tb.EndHeaders();

                Paragraph p35 = new Paragraph("Vacancy", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_5 = new iTextSharp.text.Cell(p35);
                tcell_5.Header = true;
                tcell_5.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_5.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_5);
                tb.EndHeaders();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Paragraph p11;
                    Paragraph p12;
                    Paragraph p13;
                    Paragraph p14;
                    Paragraph p15;

                    p11 = new Paragraph(ds.Tables[0].Rows[i]["Dist_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                    p12 = new Paragraph(ds.Tables[0].Rows[i]["Sub_Div_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                    p13 = new Paragraph(ds.Tables[0].Rows[i]["School_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                    p14 = new Paragraph(ds.Tables[0].Rows[i]["Class"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                    p15 = new Paragraph(ds.Tables[0].Rows[i]["Vacancy"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));

                    iTextSharp.text.Cell tcell_p111 = new iTextSharp.text.Cell(p11);
                    tcell_p111.HorizontalAlignment = Element.ALIGN_CENTER;
                    tb.AddCell(tcell_p111);

                    iTextSharp.text.Cell tcell_p112 = new iTextSharp.text.Cell(p12);
                    tcell_p112.HorizontalAlignment = Element.ALIGN_CENTER;
                    tb.AddCell(tcell_p112);

                    iTextSharp.text.Cell tcell_p113 = new iTextSharp.text.Cell(p13);
                    tcell_p113.HorizontalAlignment = Element.ALIGN_CENTER;
                    tb.AddCell(tcell_p113);

                    iTextSharp.text.Cell tcell_p114 = new iTextSharp.text.Cell(p14);
                    tcell_p114.HorizontalAlignment = Element.ALIGN_CENTER;
                    tb.AddCell(tcell_p114);

                    iTextSharp.text.Cell tcell_p115 = new iTextSharp.text.Cell(p15);
                    tcell_p115.HorizontalAlignment = Element.ALIGN_CENTER;
                    tb.AddCell(tcell_p115);

                }

            }
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 2, 2, 2, 1);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            String pcnt;
            pcnt = (writer.CurrentPageNumber - 1).ToString();
            pcnt = pcnt.Substring(1);
            pdfDoc.Open();
            pdfDoc.Add(new Paragraph("              VACANCY MASTER"));
            pdfDoc.Add(tb);
            pdfDoc.Close();
            HttpContext.Current.Response.Write(pdfDoc);
            HttpContext.Current.Response.End();
        }

        protected void schgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = "";
            id = e.CommandArgument.ToString().Trim();
            if (e.CommandName == "Edit")
            {
                con.Open();
                string qry_edit = "select Dist_Code, Sub_Div_Code, School_Code, Class, Vacancy from sms_school_vacancy where School_Code='" + id + "'";
                SqlCommand cmd = new SqlCommand(qry_edit, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //txt_dist_name.Text = ds.Tables[0].Rows[0][0].ToString();
                ddldist.SelectedValue = ds.Tables[0].Rows[0]["Dist_Code"].ToString();
                ddlsub.SelectedValue = ds.Tables[0].Rows[0]["Sub_Div_Code"].ToString();
                ddlschool.SelectedValue = ds.Tables[0].Rows[0]["School_Code"].ToString();
                txtvacancy.Text = ds.Tables[0].Rows[0]["Vacancy"].ToString();
                ddlclass.SelectedValue = ds.Tables[0].Rows[0]["Class"].ToString();
                con.Close();
                ddldist.Enabled = false;
                ddlsub.Enabled = false;
                ddlschool.Enabled = false;
                //btnupdate.Visible = true;
                //btnsave.Visible = false;
            }
            else if (e.CommandName == "Delete")
            {
                string qrydel = "DELETE FROM sms_school_vacancy WHERE School_Code='" + id + "'";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(qrydel, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data deleted successfully')", true);
                    ddlsub.Items.Clear();
                    ddldist.Items.Clear();
                    ddlschool.Items.Clear();
                    ddlclass.Items.Clear();
                    load_school();
                    load_subdiv();
                    load_class();
                    load_grid();
                    load_dist();
                }
            }
        }

        protected void schgrid_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void schgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void schgrid_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void schgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        //protected void btnupdate_Click(object sender, EventArgs e)
        //{
        //    int c = 0;
        //    try
        //    {
        //        if (ddlschool.Text == "-Select-" || txtvacancy.Text == "" || ddldist.Text == "-Select-" || ddlsub.Text == "-Select-" || ddlclass.Text == "-Select-")
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter all the fields')", true);
        //        }
        //        else
        //        {
                    
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex);
        //    }
        //}
    }
}