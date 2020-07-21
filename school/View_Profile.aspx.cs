using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;

namespace school
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select SNo, Name,UserId,EMail,Phone,Address,case when Gender='f' or Gender='female' then 'Female' else 'male' end as Gender,convert(varchar(10),DOB,103) as DOB from schoolreg"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int sno = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string userid = (row.FindControl("t2") as TextBox).Text;
            string name = (row.FindControl("t3") as TextBox).Text;
            string email = (row.FindControl("t4") as TextBox).Text;
            string phone = (row.FindControl("t5") as TextBox).Text;
            string address = (row.FindControl("t6") as TextBox).Text;
            string gender = (row.FindControl("t7") as TextBox).Text;
            string dob = (row.FindControl("t8") as TextBox).Text;
            
            string query = "UPDATE schoolreg SET UserId=@userid, Name=@name, EMail=@email, Phone=@phone, Address=@address, Gender=@gender, DOB=@dob WHERE SNo=@sno";
            string constr = ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand c2 = new SqlCommand(query))
                {
                    c2.Parameters.AddWithValue("@sno", sno);
                    c2.Parameters.AddWithValue("@userid", userid);
                    c2.Parameters.AddWithValue("@name", name);
                    c2.Parameters.AddWithValue("@email", email);
                    c2.Parameters.AddWithValue("@phone", phone);
                    c2.Parameters.AddWithValue("@address", address);
                    c2.Parameters.AddWithValue("@gender", gender);
                    c2.Parameters.AddWithValue("@dob", dob);
                    c2.Connection = con;
                    con.Open();
                    c2.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int sno = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM schoolreg WHERE SNo=@sno";
            string constr = ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@sno", sno);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Employees.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
#pragma warning disable CS0612 // Type or member is obsolete  
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
#pragma warning restore CS0612 // Type or member is obsolete  
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            GridView1.AllowPaging = true;
            GridView1.DataBind();
        }
        
    }
   
}  
    
