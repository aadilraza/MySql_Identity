using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspNet_Identity_MySql_Practice2.Controllers
{
    public class HomeController : Controller
    {

        private static string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public ActionResult Index()
        {         
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult List()
        {
            var List = new sakilaEntities().actors.ToList();
            return View(List);
        }

        public void Fetch()
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM sakila.actor"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                        }
                    }
                }
            }
        }

        public void Fetch2()
        {
            using (var ctx = new sakilaEntities())
            {
                var studentList = ctx.actors
                                    .SqlQuery("SELECT * FROM sakila.actor Where last_name = 'CHASE'")
                                    .ToList<actor>();
            }
        }
        public void Fetch3()
        {
            var Dt = fillDataTable("SELECT * FROM sakila.actor");
        }

        private DataTable fillDataTable(string query)
        {
            using (MySqlConnection sqlConn = new MySqlConnection(constr))
            using (MySqlCommand cmd = new MySqlCommand(query, sqlConn))
            {
                sqlConn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }
    }
}