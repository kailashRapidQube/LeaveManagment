using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagment.Models;

namespace LeaveManagment.Controllers
{
    public class DefaultController : Controller
    {


        // GET: Default
        public ActionResult Index()
        {
            leave aaaa= new leave();
            return View("index",aaaa.GetLeaves());
                      
        }
        
        public ActionResult output(string a,int c)
        {            

            DataTable dt = new DataTable();
            string strConString = "Data Source=DESKTOP-3A8JNRK;Initial Catalog=leavedb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spleavegained1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a",a);
                cmd.Parameters.AddWithValue("@c", c);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return View("output",dt);
        }
        
    }
}