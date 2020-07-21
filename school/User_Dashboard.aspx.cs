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
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;



namespace school
{
    public partial class User_Dashboard : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
            conn.Open();
            SqlCommand cmnd = new SqlCommand("Select UserId,Name,EMail,Phone,Address,case when Gender='f' or Gender='female' then 'Female' else 'male' end as Gender,DOB from schoolreg where UserId='" + Session["UserId"] + "'", conn);
            SqlDataAdapter dt = new SqlDataAdapter(cmnd);
            DataSet ds2 = new DataSet();
            dt.Fill(ds2);
            int i = ds2.Tables[0].Rows.Count;
            if (i > 0)
            {
                label2.Text = ds2.Tables[0].Rows[0]["UserId"].ToString();

                label4.Text = ds2.Tables[0].Rows[0]["Name"].ToString();

                label6.Text = ds2.Tables[0].Rows[0]["EMail"].ToString();

                label8.Text = ds2.Tables[0].Rows[0]["Phone"].ToString();

                label10.Text = ds2.Tables[0].Rows[0]["Address"].ToString();
                label12.Text = ds2.Tables[0].Rows[0]["Gender"].ToString();
                label14.Text = ds2.Tables[0].Rows[0]["DOB"].ToString();

            }
            conn.Close();
        }
        
    }
}