using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace LeaveManagment.Models
{
    public class Class1
    {
        public int Employeeid { get; set; }

        public string Employee { get; set; }

        public string Sex { get; set; }

        public int InsertStudent(int Employeeid,string Employee,string Sex )
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3A8JNRK;Initial Catalog=leavedb;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("spinsertemployeetbl", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Employeeid", Employeeid);
            cmd.Parameters.AddWithValue("@Employee",Employee);
            cmd.Parameters.AddWithValue("@Sex",Sex);
            con.Open();
            return cmd.ExecuteNonQuery();
            
        }
    }
}