using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatingApps.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace DatingApps.Controllers
{
    public class HomeController : Controller
    {
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
            ViewBag.Message = "登録をしてください。";

            return View();
        }

        [HttpPost]
        public ActionResult UserPage(string id, string password)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DatingApps"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            try
            {
                string sqlStr = "select*from User";
                SqlCommand sqlCommand = new SqlCommand(sqlStr, con);
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                while (sdr.Read())
                {
                    
                    if (id == sdr["id"].ToString())
                    {
                        ViewData["id"] = id + "を受け取った";
                    }
                }
            }
            catch (Exception)
            {
             
            }
            finally
            {
                con.Close();
            }

            //var users = new User();
            //users.Id = id;
            //users.Password = password;
            //if (id == "aaa")
            //{
            //    ViewData["id"] = id + "を受け取った";
            //}

            return View();
        }
    }
}