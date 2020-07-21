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
    public partial class Sub_Div_Master : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            ddldist.Enabled = true;
            if (!IsPostBack)
            {
                load_dist();
                load_subdiv();
                load_grid();
            }
        }

        protected void ddlsub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsub.SelectedValue == "-New-" || ddlsub.SelectedValue == "-Select-")
            {
                txtsub.Text = null;
            }
            else
            {
                txtsub.Text = (ddlsub.SelectedItem.Text).ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int c = 0;
            try
            {
                if (ddlsub.Text == "-Select-" || txtsub.Text == "" || ddldist.Text == "-Select-")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter all the fields')", true);
                }
                else
                {
                    if (ddlsub.SelectedValue == "-New-")
                    {
                        string insert = "insert into SMS_Sub_Division (Dist_Code,Sub_Div_Name) values(@distcode,@name)";
                        SqlCommand cmd = new SqlCommand(insert, con);
                        cmd.Parameters.AddWithValue("@distcode", ddldist.SelectedValue);
                        cmd.Parameters.AddWithValue("@name", txtsub.Text);
                        con.Open();
                        c = cmd.ExecuteNonQuery();
                        if (c > 0)
                        {
                            con.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data inserted successfully')", true);
                            ddlsub.Items.Clear();
                            ddldist.Items.Clear();
                            load_dist();
                            load_subdiv();
                            load_grid();
                            txtsub.Text = null;
                        }
                        else
                        {
                            con.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Opps Server error')", true);
                        }

                    }
                    else
                    {
                        string updatesql = "UPDATE SMS_Sub_Division SET Sub_Div_Name = @name WHERE Sub_Div_Code = @code";
                        SqlCommand cmd = new SqlCommand(updatesql, con);

                        con.Open();


                        cmd.Parameters.AddWithValue("@code", ddlsub.SelectedValue);
                        cmd.Parameters.AddWithValue("@name", txtsub.Text);
                        cmd.ExecuteNonQuery();
                        c = cmd.ExecuteNonQuery();
                        if (c > 0)
                        {
                            con.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data updated successfully')", true);
                            ddlsub.Items.Clear();
                            ddldist.Items.Clear();
                            load_dist();
                            load_subdiv();
                            load_grid();
                            txtsub.Text = null;
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

        public void load_subdiv()
        {
            SqlCommand com = new SqlCommand("select Dist_Code,Sub_Div_Code,Sub_Div_Name from SMS_Sub_Division", con);
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlsub.DataSource = dt;
            ddlsub.DataBind();

            ddlsub.Items.Insert(0, "-Select-");
            ddlsub.Items.Insert(1, "-New-");
        }

        public void load_dist()
        {
            string com = "select Dist_Code,Dist_Name from Dist_List";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddldist.DataSource = dt;
            ddldist.DataBind();

            ddldist.Items.Insert(0, "-Select-");
        }

        public void load_grid()
        {
            string sqlgrid = "Select Dist_Name,Sub_Div_Code,Sub_Div_Name from SMS_Sub_Division inner join Dist_List on SMS_Sub_Division.Dist_Code = Dist_List.Dist_Code order by Dist_Name, Sub_Div_Name";
            SqlCommand cmd = new SqlCommand(sqlgrid, con);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    subgrid.DataSource = dt;
                    subgrid.DataBind();
                }
            }
        }

        protected void subgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = "";
            id = e.CommandArgument.ToString().Trim();
            if (e.CommandName == "Edit")
            {
                con.Open();
                string qry_edit = "select Dist_Code,Sub_Div_Code,Sub_Div_Name from SMS_Sub_Division where Sub_Div_Code='" + id + "'";
                SqlCommand cmd = new SqlCommand(qry_edit, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ddldist.Enabled = false;
                //txt_dist_name.Text = ds.Tables[0].Rows[0][0].ToString();
                ddldist.SelectedValue = ds.Tables[0].Rows[0]["Dist_Code"].ToString();
                ddlsub.SelectedValue = ds.Tables[0].Rows[0]["Sub_Div_Code"].ToString();
                txtsub.Text = ds.Tables[0].Rows[0]["Sub_Div_Name"].ToString();
                con.Close();
            }
            else if (e.CommandName == "Delete")
            {
                string qrydel = "DELETE FROM SMS_Sub_Division WHERE Sub_Div_Code='" + id + "'";
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
                    load_subdiv();
                    load_grid();
                    load_dist();
                }
            }
        }

        protected void subgrid_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void subgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void subgrid_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void subgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.ContentType = "Application/PDF";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename= Sub_Division_Master.pdf");
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            string qry1 = "Select Dist_Name,Sub_Div_Code,Sub_Div_Name from SMS_Sub_Division inner join Dist_List on SMS_Sub_Division.Dist_Code = Dist_List.Dist_Code order by Dist_Name, Sub_Div_Name";
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

                Paragraph p31 = new Paragraph("District Code", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_1 = new iTextSharp.text.Cell(p31);
                tcell_1.Header = true;
                tcell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_1.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_1);
                tb.EndHeaders();

                Paragraph p32 = new Paragraph("Sub Division Code", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_2 = new iTextSharp.text.Cell(p32);
                tcell_2.Header = true;
                tcell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_2.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_2);
                tb.EndHeaders();

                Paragraph p33 = new Paragraph("District Name", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
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
                    p12 = new Paragraph(ds.Tables[0].Rows[i]["Sub_Div_Code"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                    p13 = new Paragraph(ds.Tables[0].Rows[i]["Sub_Div_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));

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
            pdfDoc.Add(new Paragraph("            SUB DIVISION MASTER"));
            pdfDoc.Add(tb);
            pdfDoc.Close();
            HttpContext.Current.Response.Write(pdfDoc);
            HttpContext.Current.Response.End();
        }

        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlsub.Items.Clear();
            txtsub.Text = "";
            if (ddldist.Text == "-Select-")
            {
                ddlsub.Enabled = false;
                txtsub.Enabled = false;
            }
            else
            {
                ddlsub.Enabled = true;
                txtsub.Enabled = true;
                SqlCommand cmd = new SqlCommand("select Dist_Code,Sub_Div_Code,Sub_Div_Name from SMS_Sub_Division where Dist_Code=" + ddldist.SelectedItem.Value, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                ddlsub.DataSource = dt;
                ddlsub.DataBind();
                ddlsub.Items.Insert(0, "-Select-");
                ddlsub.Items.Insert(1, "-New-");
            }
        }
    }
}