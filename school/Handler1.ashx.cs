using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace school
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        //Admission_Form cls = new Admission_Form();
        //public void ProcessRequest(HttpContext context)
        //{

        //    string displayimgid = context.Request.QueryString["Image"].ToString();
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConn"].ConnectionString);
        //    //retrieving the images on the basis of id of uploaded  
        //    // images, by using the query sting values which comes from Defaut.aspx page  
        //    cls.query = "select Image from ImageToDB where id=" + displayimgid;
        //    SqlCommand com = new SqlCommand(cls.query, cls.conn);
        //    SqlDataReader dr = com.ExecuteReader();
        //    dr.Read();
        //    context.Response.BinaryWrite((Byte[])dr[0]);
        //    context.Response.End();
        //}

        //public bool IsReusable
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}
        public bool IsReusable
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}