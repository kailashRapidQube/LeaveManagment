﻿using LeaveManagment.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;

namespace LeaveManagment.Controllers
{
    public class LeaveaddController : Controller
    {
        // GET: Leaveadd
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            string strConString = "Data Source=DESKTOP-3A8JNRK;Initial Catalog=leavedb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                List<Class2> EmpList = new List<Class2>();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from leavedetailstbl ORDER BY Employeeid,\r\nCASE \r\n     WHEN Months = 'January' THEN 1\r\n     WHEN Months = 'February' THEN 2\r\n     WHEN Months = 'March' THEN 3\r\n     WHEN Months = 'April' THEN 4\r\n     WHEN Months = 'May' THEN 5\r\n     WHEN Months = 'June' THEN 6\r\n\t WHEN Months = 'July' THEN 7\r\n     WHEN Months = 'August' THEN 8\r\n     WHEN Months = 'September' THEN 9\r\n     WHEN Months = 'October' THEN 10\r\n     WHEN Months = 'November' THEN 11\r\n     WHEN Months = 'December' THEN 12\r\n     ELSE 13 \r\n     END ASC", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {

                    EmpList.Add(

                        new Class2
                        {
                            Employeeid = Convert.ToInt32(dr["Employeeid"]),
                            Leaveid = Convert.ToString(dr["Leaveid"]),
                            Year = Convert.ToString(dr["Year"]),
                            Months = Convert.ToString(dr["Months"]),
                            noofleaves = Convert.ToInt32(dr["noofleaves"])
                        }
                        );
                }
                return View(EmpList);
            }
            
        }

        // GET: Leaveadd/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Leaveadd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leaveadd/Create
        [HttpPost]
        public ActionResult Createrecord(FormCollection frm,string action )
        {
            if (action == "Submit")
            {
                Class2 model = new Class2();
                int Employeeid = Convert.ToInt32(frm["txtid"]);
                int Leaveid = Convert.ToInt32(frm["txtid2"]);
                string Year = frm["txtYear"];
                string Months = frm["txtMonth"];
                int noofleaves  = Convert.ToInt32(frm["txtLeaves"]);
                int status = model.InsertLeave(Employeeid,Leaveid, Year, Months,noofleaves);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Leaveadd/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Leaveadd/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Leaveadd/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Leaveadd/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
