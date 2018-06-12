using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace ListViewCheckBoxTest
{
     public class Dao 
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string name { get; set; }

        public bool isCheck { get; set; }

        public Dao() { }
        public Dao(string language,bool isCheck) {
            this.name = language;
            this.isCheck = isCheck;
        }
        public Dao(int id,string language, bool isCheck)
        {
            this.id = id;
            this.name = language;
            this.isCheck = isCheck;
        }
    }
}