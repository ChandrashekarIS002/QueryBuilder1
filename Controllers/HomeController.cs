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

        public JsonResult GetColumnNames(string TableName, string DatabaseName)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string[] data = js.Deserialize<string[]>(TableName);
            List<Class1> TbName = new List<Class1>();
            using (var context = new masterEntities())
            {
                foreach (string a in data)
                {
                    List<children> TbCol = new List<children>();
                    Class1 obj = new Class1();
                    obj.text = a;
                    //obj.@checked = false;
                    var Tables = context.Database.SqlQuery<string>(
                    "SELECT COLUMN_NAME FROM " + DatabaseName + ".INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME= '" + a + "'").ToList();
                   
                    foreach (string ColumnName in Tables)
                    {
                        children obj1 = new children();

                        obj1.text = ColumnName;
                        TbCol.Add(obj1);
                     }
                    obj.children = TbCol;
                    TbName.Add(obj);
                }

            }
            return Json(TbName, JsonRequestBehavior.AllowGet);


        }

    }
}