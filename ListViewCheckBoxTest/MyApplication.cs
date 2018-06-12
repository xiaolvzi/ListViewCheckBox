using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ListViewCheckBoxTest
{
    [Application]
    public class MyApplication : Application
    {
        public static List<TableList> useritems = new List<TableList>();
        public static List<Dao> daoList;
        public MyApplication(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
           
            getDataFromDB();



        
        }

        private  void getDataFromDB()
        {
            daoList =  DBHelper.getData();
            if (daoList == null)
            {
                initData();
            }
            else
            {
                fillData();
            }

        }

        private void fillData()
        {
            for (int i = 0; i < daoList.Count; i++)
            {
                useritems.Add(new TableList(daoList[i].name, daoList[i].isCheck));
            }
        }

        private void initData()
        {
            
            TableList t1 = new TableList("Germany", false);
            TableList t2 = new TableList("France", false);
            TableList t3 = new TableList("Finland", false);
            TableList t4 = new TableList("Germany", false);
            TableList t5 = new TableList("France", false);
            TableList t6 = new TableList("Finland", false);

            TableList t7 = new TableList("Germany", false);
            TableList t8 = new TableList("France", false);
            TableList t9 = new TableList("Finland", false);
            TableList t10 = new TableList("Germany", false);
            TableList t11 = new TableList("France", false);
            TableList t12 = new TableList("Finland", false);

            TableList t13 = new TableList("Germany", false);
            TableList t14 = new TableList("France", false);
            TableList t15 = new TableList("Finland", false);
            TableList t16 = new TableList("Germany", false);
            TableList t17 = new TableList("France", false);
            TableList t18 = new TableList("Finland", false);

            useritems.Add(t1);
            useritems.Add(t2);
            useritems.Add(t3);
            useritems.Add(t4);
            useritems.Add(t5);
            useritems.Add(t6);
            useritems.Add(t7);
            useritems.Add(t8);
            useritems.Add(t9);
            useritems.Add(t10);
            useritems.Add(t11);
            useritems.Add(t12);
            useritems.Add(t13);
            useritems.Add(t14);
            useritems.Add(t15);
            useritems.Add(t16);
            useritems.Add(t17);
            useritems.Add(t18);

            //database
            DBHelper.createTable();

            daoList = new List<Dao>();
            daoList.Add(new Dao("Germany", false));
            daoList.Add(new Dao("France", false));
            daoList.Add(new Dao("Finland", false));
            daoList.Add(new Dao("Germany", false));
            daoList.Add(new Dao("France", false));
            daoList.Add(new Dao("Finland", false));
            daoList.Add(new Dao("Germany", false));
            daoList.Add(new Dao("France", false));
            daoList.Add(new Dao("Finland", false));
            daoList.Add(new Dao("Germany", false));
            daoList.Add(new Dao("France", false));
            daoList.Add(new Dao("Finland", false));
            daoList.Add(new Dao("Germany", false));
            daoList.Add(new Dao("France", false));
            daoList.Add(new Dao("Finland", false));
            daoList.Add(new Dao("Germany", false));
            daoList.Add(new Dao("France", false));
            daoList.Add(new Dao("Finland", false));

            DBHelper.instertData(daoList);
        }
    }
}