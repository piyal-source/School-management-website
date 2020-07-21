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
    public partial class District_Master_1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_dist();
                load_grid();
            }
        }
        public void load_dist()
        {
            string com = "select Dist_Code,Dist_Name from Dist_List";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddl_dist.DataSource = dt;
            ddl_dist.DataBind();

            ddl_dist.Items.Insert(0, "-Select-");
            ddl_dist.Items.Insert(1, "-New-");            
        }

        public void load_grid()
        {
            string sqlgrid = "Select Dist_Code,Dist_Name from Dist_List order by Dist_Name";
            SqlCommand cmd = new SqlCommand(sqlgrid, con);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    grid_deg.DataSource = dt;
                    grid_deg.DataBind();
                }
            }
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            int c = 0;
            try
            {
                if (ddl_dist.Text == "-Select-" || txt_dist_name.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter all the fields')", true);
                }
                else
                {
                    if (ddl_dist.SelectedValue == "-New-")
                    {
                        string insert = "insert into Dist_List (Dist_Name) values(@name)";
                        SqlCommand cmd = new SqlCommand(insert, con);
                        //cmd.Parameters.AddWithValue("@code", ddl_dist.SelectedValue);
                        cmd.Parameters.AddWithValue("@name", txt_dist_name.Text);
                        con.Open();
                        c = cmd.ExecuteNonQuery();
                        if (c > 0)
                        {
                            con.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data inserted successfully')", true);
                            ddl_dist.Items.Clear();
                            load_dist();
                            load_grid();
                            txt_dist_name.Text = null;
                        }
                        else
                        {
                            con.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Opps Server error')", true);
                        }

                    }
                    else
                    {

                        string updatesql = "UPDATE Dist_List SET Dist_Name = @name WHERE Dist_Code = @code";
                        SqlCommand cmd = new SqlCommand(updatesql, con);

                        con.Open();


                        cmd.Parameters.AddWithValue("@code", ddl_dist.SelectedValue);
                        cmd.Parameters.AddWithValue("@name", txt_dist_name.Text);
                        cmd.ExecuteNonQuery();
                        c = cmd.ExecuteNonQuery();
                        if (c > 0)
                        {
                            con.Close();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data updated successfully')", true);
                            ddl_dist.Items.Clear();
                            load_dist();
                            load_grid();
                            txt_dist_name.Text = null;
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
        protected void ddl_dist_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (ddl_dist.SelectedValue == "-New-" || ddl_dist.SelectedValue == "-Select-")
            {
                txt_dist_name.Text = null;
            }
            else
            {
                txt_dist_name.Text = (ddl_dist.SelectedItem.Text).ToString();
            }

        }

        protected void grid_deg_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            load_grid();
        }

        protected void grid_deg_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grid_deg_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void grid_deg_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }



        protected void grid_deg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = "";
            id = e.CommandArgument.ToString().Trim();
            if (e.CommandName == "Edit")
            {
                con.Open();
                string qry_edit = "select Dist_Code,Dist_Name from Dist_List where Dist_Code='" + id + "'";
                SqlCommand cmd = new SqlCommand(qry_edit, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //txt_dist_name.Text = ds.Tables[0].Rows[0][0].ToString();
                ddl_dist.SelectedValue = ds.Tables[0].Rows[0]["Dist_Code"].ToString();
                txt_dist_name.Text = ds.Tables[0].Rows[0]["Dist_Name"].ToString();
                con.Close();
            }
            else if (e.CommandName == "Delete")
            {
                string qrydel = "DELETE FROM Dist_List WHERE Dist_Code='" + id + "'";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(qrydel,con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    
                    cmd.ExecuteNonQuery();
                    
                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data deleted successfully')", true);
                    ddl_dist.Items.Clear();
                    load_grid();
                    load_dist();
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.ContentType = "Application/PDF";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename= District_Master.pdf");
            StringWriter sw = new StringWriter();
            HtmlTextWriter tw = new HtmlTextWriter(sw);

            string qry1 = "select Dist_Code,Dist_Name from Dist_List order by Dist_Name";
            SqlCommand cmd = new SqlCommand(qry1, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            iTextSharp.text.Table tb = new iTextSharp.text.Table(2);
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

                Paragraph p32 = new Paragraph("District Name", new Font(Font.TIMES_ROMAN, 11, Font.BOLD));
                iTextSharp.text.Cell tcell_2 = new iTextSharp.text.Cell(p32);
                tcell_2.Header = true;
                tcell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                tcell_2.BackgroundColor = Color.LIGHT_GRAY;
                tb.AddCell(tcell_2);
                tb.EndHeaders();


                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Paragraph p11;
                    Paragraph p12;

                    p11 = new Paragraph(ds.Tables[0].Rows[i]["Dist_Code"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));
                    p12 = new Paragraph(ds.Tables[0].Rows[i]["Dist_Name"].ToString(), new Font(Font.TIMES_ROMAN, 10, Font.NORMAL));

                    iTextSharp.text.Cell tcell_p111 = new iTextSharp.text.Cell(p11);
                    tcell_p111.HorizontalAlignment = Element.ALIGN_CENTER;
                    tb.AddCell(tcell_p111);

                    iTextSharp.text.Cell tcell_p112 = new iTextSharp.text.Cell(p12);
                    tcell_p112.HorizontalAlignment = Element.ALIGN_LEFT;
                    tb.AddCell(tcell_p112);

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
            pdfDoc.Add(new Paragraph("            DISTRICT MASTER"));
            pdfDoc.Add(tb);
            pdfDoc.Close();
            HttpContext.Current.Response.Write(pdfDoc);
            HttpContext.Current.Response.End();
        }

        
    }
}