using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;

namespace ListViewCheckBoxTest
{
    public class DBHelper
    {
       public static SQLiteAsyncConnection db;
        public static string createPath()
        {
            string databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "database.db");

            Log.Error("lv===", databasePath);
            return databasePath;
        }

        public  static void getConnect()
        {
             db =  new SQLiteAsyncConnection(createPath());
        }

        public async static void createTable()
        {
            isNull();
            await db.CreateTableAsync<Dao>();
        }

        public static void instertData(List<Dao> dao)
        {
            isNull();

            db.InsertAllAsync(dao);
        }

        public static void updateData(List<Dao> dao)
        {
            isNull();

            db.UpdateAllAsync(dao);
        }

        public  static List<Dao> getData()
        {
            SQLiteConnection db = new SQLiteConnection(createPath());
            List<Dao> list=null;
            try
            {
                list = db.Query<Dao>("select * from Dao");
            }
            catch (Exception e)
            {

            }
           
            return list;

        }

        public static void isNull()
        {
            if (db == null)
            {
                getConnect();
            }
        }



    }
}