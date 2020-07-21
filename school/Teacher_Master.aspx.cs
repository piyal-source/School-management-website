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
using System.Net;
using System.Net.Security;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace school
{
    public partial class Teacher_Master : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_school();
                load_teacher();
                load_sub();
                load_grid();
            }
        }
        

        protected void ddl_teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_teacher.SelectedValue == "-New-" || ddl_teacher.SelectedValue == "-Select-")
            {
                txt_teacher.Text = null;
            }
            else
            {
                txt_teacher.Text = (ddl_teacher.SelectedItem.Text).ToString();
            }
        }

        public void load_school()
        {
            string com = "select Dist_Code,Sub_Div_Code,School_Code,School_Name from sms_school_master";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddl_school.DataSource = dt;
            ddl_school.DataBind();

            ddl_school.Items.Insert(0, "-Select-");
        }

        public void load_teacher()
        {
            string com = "select School_Code,Teacher_ID,Teacher_Name,Subject_Code from sms_teacher";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddl_teacher.DataSource = dt;
            ddl_teacher.DataBind();

            ddl_teacher.Items.Insert(0, "-Select-");
            ddl_teacher.Items.Insert(1, "-New-");
        }

        public void load_sub()
        {
            string com = "select Subject_ID,Subject_Name from sms_subject_master";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddl_sub.DataSource = dt;
            ddl_sub.DataBind();

            ddl_sub.Items.Insert(0, "-Select-");
        }

        public void load_grid()
        {
            string sqlgrid = "Select sms_school_master.School_Name, sms_teacher.Teacher_ID, sms_teacher.Teacher_Name, sms_subject_master.Subject_Name from ((sms_teacher inner join sms_school_master on sms_teacher.School_Code = sms_school_master.School_Code) inner join sms_subject_master on sms_teacher.Subject_Code = sms_subject_master.Subject_ID) order by School_Name, Subject_Name, Teacher_Name";
            SqlCommand cmd = new SqlCommand(sqlgrid, con);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    gridtech.DataSource = dt;
                    gridtech.DataBind();
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int c = 0;
            try
            {
                if (ddl_school.Text == "-Select-" || txt_teacher.Text == "" || ddl_teacher.Text == "-Select-" || ddl_sub.Text == "-Select-")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter all the fields')", true);
                }
                else
                {
                    if (ddl_teacher.SelectedValue == "-New-")
                    {
                        string insert = "insert into sms_teacher (School_Code,Teacher_Name,Subject_Code) values(@schcode,@teacher,@subcode)";
                        SqlCommand cmd = new SqlCommand(insert, con);
                        cmd.Parameters.AddWithValue("@schcode", ddl_school.SelectedValue);
                        cmd.Parameters.AddWithValue("@teacher", txt_teacher.Text);
                        cmd.Parameters.AddWithValue("@subcode", ddl_sub.SelectedValue);
                        con.Open();
                        c = cmd.ExecuteNonQuery();
                        if (c > 0)
                        {
                            con.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data inserted successfully')", true);
                            ddl_school.Items.Clear();
                            ddl_sub.Items.Clear();
                            ddl_teacher.Items.Clear();
                            load_school();
                            load_teacher();
                            load_sub();
                            load_grid();
                            txt_teacher.Text = null;
                        }
                        else
                        {
                            con.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Opps Server error')", true);
                        }

                    }
                    else
                    {

                        string updatesql = "UPDATE sms_teacher SET Teacher_Name = @name, School_Code = @schcode, Subject_Code = @subcode WHERE Teacher_ID = @code";
                        SqlCommand cmd = new SqlCommand(updatesql, con);

                        con.Open();
                        cmd.Parameters.AddWithValue("@subcode", ddl_sub.SelectedValue);
                        cmd.Parameters.AddWithValue("@schcode", ddl_school.SelectedValue);
                        cmd.Parameters.AddWithValue("@code", ddl_teacher.SelectedValue);
                        cmd.Parameters.AddWithValue("@name", txt_teacher.Text);
                        cmd.ExecuteNonQuery();
                        c = cmd.ExecuteNonQuery();
                        if (c > 0)
                        {
                            con.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data updated successfully')", true);
                            ddl_teacher.Items.Clear();
                            ddl_sub.Items.Clear();
                            ddl_school.Items.Clear();
                            load_school();
                            load_teacher();
                            load_sub();
                            load_grid();
                            txt_teacher.Text = null;
                        }
                        else
                        {
                            con.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Opps Server error')", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void pdfbtn_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.ContentType = "Application/PDF";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename= Teacher_Master.pdf");
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            string qry1 = "Select sms_school_master.School_Name, sms_teacher.Teacher_ID, sms_teacher.Teacher_Name, sms_subject_master.Subject_Name from ((sms_teacher inner join sms_school_master on sms_teacher.School_Code = sms_school_master.School_Code) inner join sms_subject_master on sms_teacher.Subject_Code = sms_subject_master.Subject_ID) order by School_Name, Subject_Name, Teacher_Name";
            SqlCommand cmd = new SqlCommand(qry1, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            iTextSharp.text.Table tb = new iTextSharp.text.Table(4);
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

                Paragraph p31 = new Paragraph("School", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_1 = new iTextSharp.text.Cell(p31);
                tcell_1.Header = true;
                tcell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_1.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_1);
                tb.EndHeaders();

                Paragraph p32 = new Paragraph("Teacher ID", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_2 = new iTextSharp.text.Cell(p32);
                tcell_2.Header = true;
                tcell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_2.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_2);
                tb.EndHeaders();

                Paragraph p33 = new Paragraph("Teacher's Name", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_3 = new iTextSharp.text.Cell(p33);
                tcell_3.Header = true;
                tcell_3.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_3.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_3);
                tb.EndHeaders();

                Paragraph p34 = new Paragraph("Subject", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_4 = new iTextSharp.text.Cell(p34);
                tcell_4.Header = true;
                tcell_4.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_4.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_4);
                tb.EndHeaders();


                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Paragraph p11;
                    Paragraph p12;
                    Paragraph p13;
                    Paragraph p14;

                    p11 = new Paragraph(ds.Tables[0].Rows[i]["School_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                    p12 = new Paragraph(ds.Tables[0].Rows[i]["Teacher_ID"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                    p13 = new Paragraph(ds.Tables[0].Rows[i]["Teacher_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                    p14 = new Paragraph(ds.Tables[0].Rows[i]["Subject_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));

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
                    tcell_p113.HorizontalAlignment = Element.ALIGN_CENTER;
                    tb.AddCell(tcell_p114);

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
            pdfDoc.Add(new Paragraph("              TEACHER MASTER"));
            pdfDoc.Add(tb);
            pdfDoc.Close();
            HttpContext.Current.Response.Write(pdfDoc);
            HttpContext.Current.Response.End();
        }

        protected void gridtech_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = "";
            id = e.CommandArgument.ToString().Trim();
            if (e.CommandName == "Edit")
            {
                con.Open();
                string qry_edit = "select School_Code,Teacher_ID,Teacher_Name,Subject_Code from sms_teacher where Teacher_ID='" + id + "'";
                SqlCommand cmd = new SqlCommand(qry_edit, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //txt_dist_name.Text = ds.Tables[0].Rows[0][0].ToString();
                ddl_school.SelectedValue = ds.Tables[0].Rows[0]["School_Code"].ToString();
                ddl_teacher.SelectedValue = ds.Tables[0].Rows[0]["Teacher_ID"].ToString();
                txt_teacher.Text = ds.Tables[0].Rows[0]["Teacher_Name"].ToString();
                ddl_sub.SelectedValue = ds.Tables[0].Rows[0]["Subject_Code"].ToString();
                con.Close();
            }
            else if (e.CommandName == "Delete")
            {
                string qrydel = "DELETE FROM sms_teacher WHERE Teacher_ID='" + id + "'";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(qrydel, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data deleted successfully')", true);
                    ddl_school.Items.Clear();
                    ddl_teacher.Items.Clear();
                    ddl_sub.Items.Clear();
                    load_school();
                    load_teacher();
                    load_grid();
                    load_sub();
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void gridtech_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gridtech_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gridtech_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void gridtech_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}