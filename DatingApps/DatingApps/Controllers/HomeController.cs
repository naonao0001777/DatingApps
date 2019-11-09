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

        /// <summary>
        /// ユーザーページ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UserPage(string id, string password)
        {
            SqlConnection con = null;
            bool errFlg = false;
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["DatingApps"].ConnectionString;
                con = new SqlConnection(conStr);
                con.Open();
            
                // UserMasterから取得するクエリを取得
                string getUser = ConfigurationManager.AppSettings["GetUserInfo"];
                SqlCommand sqlCommand = new SqlCommand(getUser, con);
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
            catch (Exception e)
            {
                string errorMessage = e.Message;
                Console.WriteLine(errorMessage);
                errFlg = true;
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
            if (errFlg)
            {
                return View("Contact");
            }
            return View();
        }

        /// <summary>
        /// サーチ画面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Search()
        {

            return View();
        }
    }
}