using System;
using System.Collections.Generic;
using System.Text;

namespace 特性
{
    //1.声明
     public  class TableNameAttribute:Attribute
     {
         private string _name = null;
         //初始化构造函数
        public  TableNameAttribute(string tablename)
        {
            this._name = tablename;
        }

        public string GetTableName()
        {
            return this._name;
        }
     }
}
