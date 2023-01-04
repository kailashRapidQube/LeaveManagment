using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace LeaveManagment.Models
{
    public class Class2
    {
        public int Employeeid { get; set; }
        public string Leaveid { get; set; }
        public string Year  { get; set; }
            
        public string Months { get; set; }
        public int noofleaves { get; set; }

        public int InsertLeave(int Employeeid,int Leaveid,string Year, string Months,int noofleaves)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3A8JNRK;Initial Catalog=leavedb;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("spinsertleave", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Employeeid", Employeeid);
            cmd.Parameters.AddWithValue("@Leaveid", Leaveid);
            cmd.Parameters.AddWithValue("@year", Year);
            cmd.Parameters.AddWithValue("@Months", Months);
            cmd.Parameters.AddWithValue("@noofleaves", noofleaves);
            con.Open();
            return cmd.ExecuteNonQuery();

        }
    }
}