using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using LeaveManagment.Models;
using Antlr.Runtime.Misc;

namespace LeaveManagment.Controllers
{
    public class EmployeeaddController : Controller
    {
        // GET: Employeeadd
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            string strConString = "Data Source=DESKTOP-3A8JNRK;Initial Catalog=leavedb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                List<leave> EmpList = new List<leave>();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Employeetbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {

                    EmpList.Add(

                        new leave
                        {
                            Employeeid = Convert.ToInt32(dr["Employeeid"]),
                            Employee = Convert.ToString(dr["Employee"]),
                            Sex = Convert.ToString(dr["Sex"]),                         
                        }
                        );
                }
                return View(EmpList);
            }
            
        }

        // GET: Employeeadd/Details/5
        

        // GET: Employeeadd/Create
        public ActionResult Create()
        {
         return View();                       
        }

        // POST: Employeeadd/Create
        [HttpPost]
        public ActionResult Createrecord(FormCollection frm, string action)
        {
           
                if (action == "Submit")
                {
                    Class1 model = new Class1();
                int Employeeid = Convert.ToInt32(frm["txtid"]);
                string Employee = frm["txtName"];
                    string  Sex = frm["txtAge"];                   
                    int status = model.InsertStudent(Employeeid,Employee, Sex);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
        }

        // GET: Employeeadd/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employeeadd/Edit/5
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

        // GET: Employeeadd/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employeeadd/Delete/5
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
