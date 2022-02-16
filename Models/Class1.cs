using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueryBuilder.Models
{
    public class Class1
    {
        public string text { get; set; } //tableName
        public List<children> children { get; set; } //ColumnName
        //public bool @checked  {get;set;}

        //public string ColumnName { get; set; }  

    }
    public class children
    {
        public string text { get; set; } //ColumnName
    }
}