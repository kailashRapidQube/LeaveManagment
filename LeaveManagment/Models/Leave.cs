using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LeaveManagment.Models
{
    public class leave
    {
        public int id { get; set; }

        public int Year { get; set; }

        public int Employeeid { get; set; }

        public string Employee { get; set; }

        public string Sex { get; set; }
        
        public DataTable Getleave()
        {
            DataTable dt = new DataTable();
            string strConString = "Data Source=DESKTOP-3A8JNRK;Initial Catalog=leavedb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select outputtbl.Months ,\r\ncase when leavedetailstbl.Months <=15 then '2'\r\nwhen leavedetailstbl.Months <=20 then '1' \r\nelse '0'\r\nend as leaveremain\r\nfrom outputtbl,leavedetailstbl where Employeeid=@id\r\n", con);

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
            
        }
        public DataTable GetLeaves()
        {
            DataTable dt = new DataTable();
            string strConString = "Data Source=DESKTOP-3A8JNRK;Initial Catalog=leavedb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                List<leave> EmpList = new List<leave>();
                con.Open();
                SqlCommand cmd = new SqlCommand("select Employee from Employeetbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                
                return dt;
            }
        }

    }
}