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
    public partial class MIS : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_dist();
                //load_subdiv();
                load_grid();
                
            }
        }

        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlsub.Items.Clear();

            if (ddldist.Text == "-All-")
            {
                ddlsub.Items.Insert(0, "-All-");
                ddlsub.Text = "-All-";
                load_grid();
            }
            else
            {
                ddlsub.Enabled = true;
                SqlCommand cmd = new SqlCommand("select Dist_Code,Sub_Div_Code,Sub_Div_Name from SMS_Sub_Division where Dist_Code=" + ddldist.SelectedItem.Value, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                ddlsub.DataSource = dt;
                ddlsub.DataBind();
                ddlsub.Items.Insert(0, "-All-");

                grd();
            }
        }

        public void load_grid()
        {
            string sqlgrid = "Select sms_school_master.Dist_Code, Dist_List.Dist_Name, sms_school_master.Sub_Div_Code, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name from ((sms_school_master inner join Dist_List on sms_school_master.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_master.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) order by Dist_Name, Sub_Div_Name, School_Name";
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

        public void load_dist()
        {
            string com = "select Dist_Code,Dist_Name from Dist_List";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddldist.DataSource = dt;
            ddldist.DataBind();
            ddldist.Items.Insert(0, "-All-");
        }

        public void grd()
        {
            string sqlgrid = "Select sms_school_master.Dist_Code, Dist_List.Dist_Name, sms_school_master.Sub_Div_Code, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name from ((sms_school_master inner join Dist_List on sms_school_master.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_master.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) where sms_school_master.Dist_Code='" + ddldist.SelectedItem.Value + "'";
            SqlCommand cmd = new SqlCommand(sqlgrid, con);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable sdt = new DataTable())
                {
                    sda.Fill(sdt);
                    gridsch.DataSource = sdt;
                    gridsch.DataBind();
                }
            }
        }

        protected void ddlsub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsub.Text == "-All-")
            {
                grd();
            }
            else
            {
                string sqlgrid = "Select sms_school_master.Dist_Code, Dist_List.Dist_Name, sms_school_master.Sub_Div_Code, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name from ((sms_school_master inner join Dist_List on sms_school_master.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_master.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) where sms_school_master.Dist_Code='" + ddlsub.SelectedItem.Value + "' and sms_school_master.Sub_Div_Code='" + ddlsub.SelectedItem.Value + "'";
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
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.ContentType = "Application/PDF";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename= MIS_School.pdf");
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            if (ddldist.Text == "-All-")
            {
                string qry1 = "Select Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name from ((sms_school_master inner join Dist_List on sms_school_master.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_master.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) order by Dist_Name, Sub_Div_Name, School_Name";
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

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Paragraph p11;
                        Paragraph p12;
                        Paragraph p13;

                        p11 = new Paragraph(ds.Tables[0].Rows[i]["Dist_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                        p12 = new Paragraph(ds.Tables[0].Rows[i]["Sub_Div_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                        p13 = new Paragraph(ds.Tables[0].Rows[i]["School_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));

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
                pdfDoc.Add(new Paragraph("              District wise Schools"));
                pdfDoc.Add(tb);
                pdfDoc.Close();
                HttpContext.Current.Response.Write(pdfDoc);
                HttpContext.Current.Response.End();
            }
            else
            {
                if (ddlsub.Text == "-All-")
                {
                    string qry1 = "Select sms_school_master.Dist_Code, Dist_List.Dist_Name, sms_school_master.Sub_Div_Code, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name from ((sms_school_master inner join Dist_List on sms_school_master.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_master.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) where sms_school_master.Dist_Code='" + ddldist.SelectedItem.Value + "'";
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

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Paragraph p11;
                            Paragraph p12;
                            Paragraph p13;

                            p11 = new Paragraph(ds.Tables[0].Rows[i]["Dist_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                            p12 = new Paragraph(ds.Tables[0].Rows[i]["Sub_Div_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                            p13 = new Paragraph(ds.Tables[0].Rows[i]["School_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));

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
                    pdfDoc.Add(new Paragraph("             District wise Schools"));
                    pdfDoc.Add(tb);
                    pdfDoc.Close();
                    HttpContext.Current.Response.Write(pdfDoc);
                    HttpContext.Current.Response.End();
                }
                else
                {
                    string qry1 = "Select sms_school_master.Dist_Code, Dist_List.Dist_Name, sms_school_master.Sub_Div_Code, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name from ((sms_school_master inner join Dist_List on sms_school_master.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_master.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) where sms_school_master.Sub_Div_Code='" + ddlsub.SelectedItem.Value + "'";
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

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Paragraph p11;
                            Paragraph p12;
                            Paragraph p13;

                            p11 = new Paragraph(ds.Tables[0].Rows[i]["Dist_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                            p12 = new Paragraph(ds.Tables[0].Rows[i]["Sub_Div_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                            p13 = new Paragraph(ds.Tables[0].Rows[i]["School_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));

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
                    pdfDoc.Add(new Paragraph("              District wise Schools"));
                    pdfDoc.Add(tb);
                    pdfDoc.Close();
                    HttpContext.Current.Response.Write(pdfDoc);
                    HttpContext.Current.Response.End();
                }
            }
        }
    }
}