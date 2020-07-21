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
    public partial class Schools_public : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            ddldist.Enabled = true;
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
            
            ddldist.Items.Insert(0, "-All-");
        }

        public void load_subdiv()
        {
            string com = "select * from SMS_Sub_Division";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlsub.DataSource = dt;
            ddlsub.DataBind();
            
            ddlsub.Items.Insert(0, "-All-");
        }

        public void load_class()
        {
            ddlclass.Items.Insert(0, "-All-");
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

        public void load_board()
        {
            string com = "select Board_ID,Board from sms_school_board";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlboard.DataSource = dt;
            ddlboard.DataBind();
            
            ddlboard.Items.Insert(0, "-All-");
        }

        protected void schgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string school = "";
            school = e.CommandArgument.ToString().Trim();
            if (e.CommandName == "Apply")
            {
                Session["School_Code"] = school;
                Response.Redirect("Admission_Form.aspx");
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

        protected void ddlsub_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlboard.Items.Clear();
            if (ddlsub.Text == "-All-")
            {
                ddlboard.Items.Insert(0, "-All-");
                ddlboard.Text = "-All-";
                grd();
            }
            else
            {
                ddlboard.Enabled = true;
                SqlCommand cmd = new SqlCommand("select sms_school_master.Board_ID, sms_school_board.Board from (sms_school_master inner join sms_school_board on sms_school_master.Board_ID = sms_school_board.Board_ID) where sms_school_master.Dist_Code='" + ddldist.SelectedItem.Value + "' and sms_school_master.Sub_Div_Code = '" + ddlsub.SelectedValue + "' ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                ddlboard.DataSource = dt;
                ddlboard.DataBind();
                ddlboard.Items.Insert(0, "-All-");

                grid_board();
            }
        }

        protected void ddlboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlclass.Items.Clear();
            if (ddlboard.Text == "-All-")
            {
                ddlclass.Items.Insert(0, "-All-");
                ddlclass.Text = "-All-";
                grid_board();
            }
            else
            {
                ddlclass.Enabled = true;
                SqlCommand cmd = new SqlCommand("select Class from (sms_school_vacancy inner join sms_school_master on sms_school_vacancy.School_Code = sms_school_master.School_Code) where sms_school_vacancy.Dist_Code='" + ddldist.SelectedItem.Value + "' and sms_school_vacancy.Sub_Div_Code = '" + ddlsub.SelectedValue + "' and sms_school_master.Board_ID = '" + ddlboard.SelectedValue + "' ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                ddlclass.DataSource = dt;
                ddlclass.DataBind();
                ddlclass.Items.Insert(0, "-All-");

                grid_class();
            }
        }

        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlclass.Text == "-All-")
            {
                grid_class();
            }
            else
            {
                string sqlgrid = "Select Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_board.Board, sms_school_vacancy.School_Code, sms_school_master.School_Name, sms_school_vacancy.Class, sms_school_vacancy.Vacancy from ((((sms_school_vacancy inner join Dist_List on sms_school_vacancy.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_vacancy.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) inner join sms_school_master on sms_school_vacancy.School_Code=sms_school_master.School_Code) inner join sms_school_board on sms_school_master.Board_ID=sms_school_board.Board_ID) where sms_school_vacancy.Dist_Code='" + ddldist.SelectedItem.Value + "' and sms_school_vacancy.Sub_Div_Code='" + ddlsub.SelectedItem.Value + "' and sms_school_master.Board_ID='" + ddlboard.SelectedItem.Value + "' and sms_school_vacancy.Class='" + ddlclass.SelectedItem.Value + "' order by Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name, sms_school_vacancy.Class";
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
        }

        public void load_grid()
        {
            string sqlgrid = "Select Dist_List.Dist_Name , SMS_Sub_Division.Sub_Div_Name, sms_school_board.Board, sms_school_vacancy.School_Code as School_Code, sms_school_master.School_Name, sms_school_vacancy.Class, sms_school_vacancy.Vacancy from ((((sms_school_vacancy inner join Dist_List on sms_school_vacancy.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_vacancy.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) inner join sms_school_master on sms_school_vacancy.School_Code=sms_school_master.School_Code) inner join sms_school_board on sms_school_master.Board_ID=sms_school_board.Board_ID) order by Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name, sms_school_vacancy.Class";
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

        public void grd()
        {
            string sqlgrid = "Select Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_board.Board, sms_school_vacancy.School_Code, sms_school_master.School_Name, sms_school_vacancy.Class, sms_school_vacancy.Vacancy from ((((sms_school_vacancy inner join Dist_List on sms_school_vacancy.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_vacancy.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) inner join sms_school_master on sms_school_vacancy.School_Code=sms_school_master.School_Code) inner join sms_school_board on sms_school_master.Board_ID=sms_school_board.Board_ID) where sms_school_vacancy.Dist_Code='" + ddldist.SelectedItem.Value + "' order by Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name, sms_school_vacancy.Class";
            SqlCommand cmd = new SqlCommand(sqlgrid, con);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable sdt = new DataTable())
                {
                    sda.Fill(sdt);
                    schgrid.DataSource = sdt;
                    schgrid.DataBind();
                }
            }
        }

        public void grid_board()
        {
            string sqlgrid = "Select Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_board.Board, sms_school_vacancy.School_Code, sms_school_master.School_Name, sms_school_vacancy.Class, sms_school_vacancy.Vacancy from ((((sms_school_vacancy inner join Dist_List on sms_school_vacancy.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_vacancy.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) inner join sms_school_master on sms_school_vacancy.School_Code=sms_school_master.School_Code) inner join sms_school_board on sms_school_master.Board_ID=sms_school_board.Board_ID) where sms_school_vacancy.Dist_Code='" + ddldist.SelectedItem.Value + "' and sms_school_vacancy.Sub_Div_Code='" + ddlsub.SelectedItem.Value + "' order by Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name, sms_school_vacancy.Class";
            SqlCommand cmd = new SqlCommand(sqlgrid, con);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable sdt = new DataTable())
                {
                    sda.Fill(sdt);
                    schgrid.DataSource = sdt;
                    schgrid.DataBind();
                }
            }
        }

        public void grid_class()
        {
            string sqlgrid = "Select Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_board.Board, sms_school_vacancy.School_Code, sms_school_master.School_Name, sms_school_vacancy.Class, sms_school_vacancy.Vacancy from ((((sms_school_vacancy inner join Dist_List on sms_school_vacancy.Dist_Code = Dist_List.Dist_Code) inner join SMS_Sub_Division on sms_school_vacancy.Sub_Div_Code = SMS_Sub_Division.Sub_Div_Code) inner join sms_school_master on sms_school_vacancy.School_Code=sms_school_master.School_Code) inner join sms_school_board on sms_school_master.Board_ID=sms_school_board.Board_ID) where sms_school_vacancy.Dist_Code='" + ddldist.SelectedItem.Value + "' and sms_school_vacancy.Sub_Div_Code='" + ddlsub.SelectedItem.Value + "' and sms_school_master.Board_ID='" + ddlboard.SelectedItem.Value + "' order by Dist_List.Dist_Name, SMS_Sub_Division.Sub_Div_Name, sms_school_master.School_Name, sms_school_vacancy.Class";
            SqlCommand cmd = new SqlCommand(sqlgrid, con);
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable sdt = new DataTable())
                {
                    sda.Fill(sdt);
                    schgrid.DataSource = sdt;
                    schgrid.DataBind();
                }
            }
        }
    }
}