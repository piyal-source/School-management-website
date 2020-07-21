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
    public partial class MIS_Subject_public : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_sub();
                load_grid();
                load_dist();
            }
        }

        public void load_sub()
        {

            string com = "select Subject_ID,Subject_Name from sms_subject_master";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlsub.DataSource = dt;
            ddlsub.DataBind();
            ddlsub.Items.Insert(0, "-All-");
        }

        public void load_dist()
        {
            ddldist.Items.Clear();
            string com = "select Dist_Code,Dist_Name from Dist_List";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddldist.DataSource = dt;
            ddldist.DataBind();

            ddldist.Items.Insert(0, "-All-");
        }

        public void load_grid()
        {
            string sqlgrid = "select sms_subject_master.Subject_Name, sms_teacher.Subject_Code, sms_teacher.School_Code, sms_school_master.School_Name, sms_school_master.Dist_Code, Dist_List.Dist_Name from (((sms_teacher inner join sms_subject_master on sms_teacher.Subject_Code=sms_subject_master.Subject_ID) inner join sms_school_master on sms_teacher.School_Code=sms_school_master.School_Code) inner join Dist_List on sms_school_master.Dist_Code=Dist_List.Dist_Code) order by sms_subject_master.Subject_Name, sms_school_master.School_Name";
            SqlCommand cmd = new SqlCommand(sqlgrid, con);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    gridsch.DataSource = dt;
                    gridsch.DataBind();
                }
            }
        }

        protected void ddlsub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsub.Text == "-All-")
            {
                if (ddldist.Text != "-All-")
                {
                    string sqlgrid = "select sms_subject_master.Subject_Name, sms_teacher.Subject_Code, sms_teacher.School_Code, sms_school_master.School_Name, sms_school_master.Dist_Code, Dist_List.Dist_Name from (((sms_teacher inner join sms_subject_master on sms_teacher.Subject_Code=sms_subject_master.Subject_ID) inner join sms_school_master on sms_teacher.School_Code=sms_school_master.School_Code) inner join Dist_List on sms_school_master.Dist_Code=Dist_List.Dist_Code) where sms_school_master.Dist_Code='" + ddldist.SelectedItem.Value + "'";
                    SqlCommand cmd = new SqlCommand(sqlgrid, con);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gridsch.DataSource = dt;
                            gridsch.DataBind();
                        }
                    }
                }
                else
                {
                    load_grid();
                }
            }
            else
            {
                if (ddldist.Text == "-All-")
                {
                    string sqlgrid = "select sms_subject_master.Subject_Name, sms_teacher.Subject_Code, sms_teacher.School_Code, sms_school_master.School_Name, sms_school_master.Dist_Code, Dist_List.Dist_Name from (((sms_teacher inner join sms_subject_master on sms_teacher.Subject_Code=sms_subject_master.Subject_ID) inner join sms_school_master on sms_teacher.School_Code=sms_school_master.School_Code) inner join Dist_List on sms_school_master.Dist_Code=Dist_List.Dist_Code) where sms_teacher.Subject_Code='" + ddlsub.SelectedItem.Value + "'";
                    SqlCommand cmd = new SqlCommand(sqlgrid, con);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gridsch.DataSource = dt;
                            gridsch.DataBind();
                        }
                    }
                }
                else
                {
                    gridnotall();
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.ContentType = "Application/PDF";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename= MIS_Subject.pdf");
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            if (ddlsub.Text == "-All-" && ddldist.Text == "-All-")
            {
                string qry1 = "select sms_subject_master.Subject_Name, sms_school_master.School_Name, Dist_List.Dist_Name from (((sms_teacher inner join sms_subject_master on sms_teacher.Subject_Code=sms_subject_master.Subject_ID) inner join sms_school_master on sms_teacher.School_Code=sms_school_master.School_Code) inner join Dist_List on sms_school_master.Dist_Code=Dist_List.Dist_Code) order by sms_subject_master.Subject_Name, sms_school_master.School_Name";
                SqlCommand cmd = new SqlCommand(qry1, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                iTextSharp.text.Table tb = new iTextSharp.text.Table(3);
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

                    Paragraph p31 = new Paragraph("Subject", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_1 = new iTextSharp.text.Cell(p31);
                    tcell_1.Header = true;
                    tcell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_1.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_1);
                    tb.EndHeaders();

                    Paragraph p32 = new Paragraph("School", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_2 = new iTextSharp.text.Cell(p32);
                    tcell_2.Header = true;
                    tcell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_2.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_2);
                    tb.EndHeaders();

                    Paragraph p33 = new Paragraph("District", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_3 = new iTextSharp.text.Cell(p33);
                    tcell_3.Header = true;
                    tcell_3.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_3.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_3);
                    tb.EndHeaders();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Paragraph p11;
                        Paragraph p12;
                        Paragraph p13;

                        p11 = new Paragraph(ds.Tables[0].Rows[i]["Subject_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                        p12 = new Paragraph(ds.Tables[0].Rows[i]["School_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                        p13 = new Paragraph(ds.Tables[0].Rows[i]["Dist_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));

                        iTextSharp.text.Cell tcell_p111 = new iTextSharp.text.Cell(p11);
                        tcell_p111.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p111);

                        iTextSharp.text.Cell tcell_p112 = new iTextSharp.text.Cell(p12);
                        tcell_p112.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p112);

                        iTextSharp.text.Cell tcell_p113 = new iTextSharp.text.Cell(p13);
                        tcell_p113.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p113);

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
                pdfDoc.Add(new Paragraph("            Subject wise Schools"));
                pdfDoc.Add(tb);
                pdfDoc.Close();
                HttpContext.Current.Response.Write(pdfDoc);
                HttpContext.Current.Response.End();
            }

            else if (ddlsub.Text == "-All-" && ddldist.Text != "-All-")
            {
                string qry1 = "select sms_subject_master.Subject_Name, sms_school_master.School_Name, Dist_List.Dist_Name from (((sms_teacher inner join sms_subject_master on sms_teacher.Subject_Code=sms_subject_master.Subject_ID) inner join sms_school_master on sms_teacher.School_Code=sms_school_master.School_Code) inner join Dist_List on sms_school_master.Dist_Code=Dist_List.Dist_Code) where sms_school_master.Dist_Code = '" + ddldist.SelectedItem.Value + "' order by sms_subject_master.Subject_Name, sms_school_master.School_Name";
                SqlCommand cmd = new SqlCommand(qry1, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                iTextSharp.text.Table tb = new iTextSharp.text.Table(3);
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

                    Paragraph p31 = new Paragraph("Subject", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_1 = new iTextSharp.text.Cell(p31);
                    tcell_1.Header = true;
                    tcell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_1.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_1);
                    tb.EndHeaders();

                    Paragraph p32 = new Paragraph("School", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_2 = new iTextSharp.text.Cell(p32);
                    tcell_2.Header = true;
                    tcell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_2.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_2);
                    tb.EndHeaders();

                    Paragraph p33 = new Paragraph("District", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_3 = new iTextSharp.text.Cell(p33);
                    tcell_3.Header = true;
                    tcell_3.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_3.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_3);
                    tb.EndHeaders();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Paragraph p11;
                        Paragraph p12;
                        Paragraph p13;

                        p11 = new Paragraph(ds.Tables[0].Rows[i]["Subject_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                        p12 = new Paragraph(ds.Tables[0].Rows[i]["School_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                        p13 = new Paragraph(ds.Tables[0].Rows[i]["Dist_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));

                        iTextSharp.text.Cell tcell_p111 = new iTextSharp.text.Cell(p11);
                        tcell_p111.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p111);

                        iTextSharp.text.Cell tcell_p112 = new iTextSharp.text.Cell(p12);
                        tcell_p112.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p112);

                        iTextSharp.text.Cell tcell_p113 = new iTextSharp.text.Cell(p13);
                        tcell_p113.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p113);

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
                pdfDoc.Add(new Paragraph("              Subject wise Schools"));
                pdfDoc.Add(tb);
                pdfDoc.Close();
                HttpContext.Current.Response.Write(pdfDoc);
                HttpContext.Current.Response.End();
            }

            else if (ddlsub.Text != "-All-" && ddldist.Text == "-All-")
            {
                string qry1 = "select sms_subject_master.Subject_Name, sms_school_master.School_Name, Dist_List.Dist_Name from (((sms_teacher inner join sms_subject_master on sms_teacher.Subject_Code=sms_subject_master.Subject_ID) inner join sms_school_master on sms_teacher.School_Code=sms_school_master.School_Code) inner join Dist_List on sms_school_master.Dist_Code=Dist_List.Dist_Code) where sms_teacher.Subject_Code = '" + ddlsub.SelectedItem.Value + "' order by sms_subject_master.Subject_Name, sms_school_master.School_Name";
                SqlCommand cmd = new SqlCommand(qry1, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                iTextSharp.text.Table tb = new iTextSharp.text.Table(3);
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

                    Paragraph p31 = new Paragraph("Subject", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_1 = new iTextSharp.text.Cell(p31);
                    tcell_1.Header = true;
                    tcell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_1.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_1);
                    tb.EndHeaders();

                    Paragraph p32 = new Paragraph("School", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_2 = new iTextSharp.text.Cell(p32);
                    tcell_2.Header = true;
                    tcell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_2.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_2);
                    tb.EndHeaders();

                    Paragraph p33 = new Paragraph("District", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_3 = new iTextSharp.text.Cell(p33);
                    tcell_3.Header = true;
                    tcell_3.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_3.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_3);
                    tb.EndHeaders();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Paragraph p11;
                        Paragraph p12;
                        Paragraph p13;

                        p11 = new Paragraph(ds.Tables[0].Rows[i]["Subject_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                        p12 = new Paragraph(ds.Tables[0].Rows[i]["School_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                        p13 = new Paragraph(ds.Tables[0].Rows[i]["Dist_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));

                        iTextSharp.text.Cell tcell_p111 = new iTextSharp.text.Cell(p11);
                        tcell_p111.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p111);

                        iTextSharp.text.Cell tcell_p112 = new iTextSharp.text.Cell(p12);
                        tcell_p112.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p112);

                        iTextSharp.text.Cell tcell_p113 = new iTextSharp.text.Cell(p13);
                        tcell_p113.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p113);

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
                pdfDoc.Add(new Paragraph("              Subject wise Schools"));
                pdfDoc.Add(tb);
                pdfDoc.Close();
                HttpContext.Current.Response.Write(pdfDoc);
                HttpContext.Current.Response.End();
            }

            else
            {
                string qry1 = "select sms_subject_master.Subject_Name, sms_school_master.School_Name, Dist_List.Dist_Name from (((sms_teacher inner join sms_subject_master on sms_teacher.Subject_Code=sms_subject_master.Subject_ID) inner join sms_school_master on sms_teacher.School_Code=sms_school_master.School_Code) inner join Dist_List on sms_school_master.Dist_Code=Dist_List.Dist_Code) where sms_school_master.Dist_Code = '" + ddldist.SelectedItem.Value + "' and sms_teacher.Subject_Code = '" + ddlsub.SelectedItem.Value + "' order by sms_subject_master.Subject_Name, sms_school_master.School_Name";
                SqlCommand cmd = new SqlCommand(qry1, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                iTextSharp.text.Table tb = new iTextSharp.text.Table(3);
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

                    Paragraph p31 = new Paragraph("Subject", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_1 = new iTextSharp.text.Cell(p31);
                    tcell_1.Header = true;
                    tcell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_1.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_1);
                    tb.EndHeaders();

                    Paragraph p32 = new Paragraph("School", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_2 = new iTextSharp.text.Cell(p32);
                    tcell_2.Header = true;
                    tcell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_2.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_2);
                    tb.EndHeaders();

                    Paragraph p33 = new Paragraph("District", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                    iTextSharp.text.Cell tcell_3 = new iTextSharp.text.Cell(p33);
                    tcell_3.Header = true;
                    tcell_3.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcell_3.BackgroundColor = Color.LIGHT_GRAY;
                    tb.AddCell(tcell_3);
                    tb.EndHeaders();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Paragraph p11;
                        Paragraph p12;
                        Paragraph p13;

                        p11 = new Paragraph(ds.Tables[0].Rows[i]["Subject_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                        p12 = new Paragraph(ds.Tables[0].Rows[i]["School_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                        p13 = new Paragraph(ds.Tables[0].Rows[i]["Dist_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));

                        iTextSharp.text.Cell tcell_p111 = new iTextSharp.text.Cell(p11);
                        tcell_p111.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p111);

                        iTextSharp.text.Cell tcell_p112 = new iTextSharp.text.Cell(p12);
                        tcell_p112.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p112);

                        iTextSharp.text.Cell tcell_p113 = new iTextSharp.text.Cell(p13);
                        tcell_p113.HorizontalAlignment = Element.ALIGN_CENTER;
                        tb.AddCell(tcell_p113);

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
                pdfDoc.Add(new Paragraph("              Subject wise Schools"));
                pdfDoc.Add(tb);
                pdfDoc.Close();
                HttpContext.Current.Response.Write(pdfDoc);
                HttpContext.Current.Response.End();
            }
        }

        public void gridnotall()
        {
            string sqlgrid = "select sms_subject_master.Subject_Name, sms_teacher.Subject_Code, sms_teacher.School_Code, sms_school_master.School_Name, sms_school_master.Dist_Code, Dist_List.Dist_Name from (((sms_teacher inner join sms_subject_master on sms_teacher.Subject_Code = sms_subject_master.Subject_ID) inner join sms_school_master on sms_teacher.School_Code = sms_school_master.School_Code) inner join Dist_List on sms_school_master.Dist_Code = Dist_List.Dist_Code) where sms_school_master.Dist_Code = '" + ddldist.SelectedItem.Value + "' and sms_teacher.Subject_Code = '" + ddlsub.SelectedItem.Value + "'";
            SqlCommand cmd = new SqlCommand(sqlgrid, con);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    gridsch.DataSource = dt;
                    gridsch.DataBind();
                }
            }
        }

        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddldist.Text == "-All-")
            {
                if (ddlsub.Text != "-All-")
                {
                    string sqlgrid = "select sms_subject_master.Subject_Name, sms_teacher.Subject_Code, sms_teacher.School_Code, sms_school_master.School_Name, sms_school_master.Dist_Code, Dist_List.Dist_Name from (((sms_teacher inner join sms_subject_master on sms_teacher.Subject_Code=sms_subject_master.Subject_ID) inner join sms_school_master on sms_teacher.School_Code=sms_school_master.School_Code) inner join Dist_List on sms_school_master.Dist_Code=Dist_List.Dist_Code) where sms_teacher.Subject_Code='" + ddlsub.SelectedItem.Value + "'";
                    SqlCommand cmd = new SqlCommand(sqlgrid, con);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gridsch.DataSource = dt;
                            gridsch.DataBind();
                        }
                    }
                }
                else
                {
                    load_grid();
                }
            }
            else
            {
                if (ddlsub.Text == "-All-")
                {
                    string sqlgrid = "select sms_subject_master.Subject_Name, sms_teacher.Subject_Code, sms_teacher.School_Code, sms_school_master.School_Name, sms_school_master.Dist_Code, Dist_List.Dist_Name from (((sms_teacher inner join sms_subject_master on sms_teacher.Subject_Code=sms_subject_master.Subject_ID) inner join sms_school_master on sms_teacher.School_Code=sms_school_master.School_Code) inner join Dist_List on sms_school_master.Dist_Code=Dist_List.Dist_Code) where sms_school_master.Dist_Code = '" + ddldist.SelectedItem.Value + "' ";
                    SqlCommand cmd = new SqlCommand(sqlgrid, con);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gridsch.DataSource = dt;
                            gridsch.DataBind();
                        }
                    }
                }
                else
                {
                    gridnotall();
                }
            }
        }
    }
}