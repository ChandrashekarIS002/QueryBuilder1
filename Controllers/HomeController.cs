using QueryBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QueryBuilder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new masterEntities())
            {
                var dbNames = context.Database.SqlQuery<string>(
                    "Select name from sys.databases WHERE name NOT IN('master', 'tempdb', 'model', 'msdb');").ToList();
                ViewBag.Data = dbNames;
            }
           
            return View();
        }

        public JsonResult GetTableName(string databaseName)
        {
            using (var context = new masterEntities())
            {
                var Tables = context.Database.SqlQuery<string>(
                "SELECT TABLE_NAME FROM " + databaseName.ToString() + ".INFORMATION_SCHEMA.TABLES").ToList();
                return Json(Tables, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetColumnNames(string TableName,string DatabaseName)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string [] data = js.Deserialize<string[]>(TableName);

               using (var context = new masterEntities())
              {
                  foreach (string a in data)
                 {
                    
                    List<Class1> TbName = new List<Class1>();
                    
                   var b = a.ToString();

                   

                  
                   


                    var Tables = context.Database.SqlQuery<string>(

                    "SELECT COLUMN_NAME FROM " + DatabaseName+".INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME= '"+a+"'").ToList();


                    //    SELECT COLUMN_NAME FROM Newspaper.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'BillMaster'
                   foreach (string Col in Tables)
                    {
                        
                        
                    }
                    
                  }
                return null;

            }
           
        }

    }
}