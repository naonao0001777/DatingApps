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
                // UserMasterから取得するクエリを取得
                string sqlStr = ConfigurationManager.ConnectionStrings["GetUserInfo"].ConnectionString;
                SqlCommand sqlCommand = new SqlCommand(sqlStr, con);
                SqlDataReader dtReader = sqlCommand.ExecuteReader();
                while (dtReader.Read())
                {
                    // idとpasswordが一致していた場合はプロフィール画面へ遷移
                    if (id == dtReader["id"].ToString() && password == dtReader["password"].ToString())
                    {
                        User user = new User();
                        user.Id = dtReader["id"].ToString();
                        user.Name = dtReader["name"].ToString();
                        user.Sex = dtReader["sex"].ToString();
                        user.BirthDay = dtReader["birthday"].ToString();
                        user.Comment = dtReader["comment"].ToString();
                        

                        ViewData["id"] = id + "を受け取った";
                        return View(user);
                       
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