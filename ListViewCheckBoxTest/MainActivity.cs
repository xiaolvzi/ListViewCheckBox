using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using System;

namespace ListViewCheckBoxTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ListView mListView;
        MyAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            mListView = FindViewById<ListView>(Resource.Id.listview);
            List<TableList> list = new List<TableList>();

            list.Add(new TableList("Germany",false));
            list.Add(new TableList("France", false));
            list.Add(new TableList("Finland", false));
            list.Add(new TableList("Germany", false));
            list.Add(new TableList("France", false));
            list.Add(new TableList("Finland", false));
            list.Add(new TableList("Germany", false));
            list.Add(new TableList("France", false));
            list.Add(new TableList("Finland", false));
            list.Add(new TableList("Germany", false));
            list.Add(new TableList("France", false));
            list.Add(new TableList("Finland", false));
            list.Add(new TableList("Germany", false));
            list.Add(new TableList("France", false));
            list.Add(new TableList("Finland", false));
            list.Add(new TableList("Germany", false));
            list.Add(new TableList("France", false));
            list.Add(new TableList("Finland", false));

            adapter = new MyAdapter(this, list);
            mListView.Adapter = adapter;
            mListView.ItemClick += MListView_ItemClick;
        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var ll = e.View as LinearLayout;
            var cb = ll.GetChildAt(2) as CheckBox;
            if (cb.Checked)
            {
                cb.Checked = false;
                adapter.changeState((int)cb.Tag, false);
            }
            else
            {
                cb.Checked = true;
                adapter.changeState((int)cb.Tag, true);
            }
        }

        class MyAdapter : BaseAdapter
        {
            Context mContext;
            List<TableList> mitems;
            public MyAdapter(Context context, List<TableList> list)
            {
                this.mContext = context;
                this.mitems = list;

            }
            public override int Count
            {
                get
                {
                    return mitems.Count;
                }
            }

            public override Java.Lang.Object GetItem(int position)
            {
                return mitems[position];
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                DataViewHolder holder = null;
                if (convertView == null)
                {
                    convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.CoinList, null, false);
                    holder = new DataViewHolder();
                    holder.tv = convertView.FindViewById<TextView>(Resource.Id.CoinName);
                    holder.iv = convertView.FindViewById<ImageView>(Resource.Id.imageView1);
                    holder.cb = convertView.FindViewById<CheckBox>(Resource.Id.checkBox1);
                    convertView.Tag = holder;
                }
                else
                {
                    holder = convertView.Tag as DataViewHolder;

                }
                holder.cb.Tag = position;

                holder.tv.Text = mitems[position].Name;
                holder.cb.Focusable = false;
                holder.cb.Checked = mitems[position].bl;
                holder.iv.SetImageResource(Resource.Drawable.dapao);
                holder.cb.CheckedChange += Cb_CheckedChange;
                return convertView;

            }

            private void Cb_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
            {
                var cb = sender as CheckBox;
                if (e.IsChecked && !mitems[(int)cb.Tag].bl)
                {
                    mitems[(int)cb.Tag].bl = true;
                    this.NotifyDataSetChanged();
                }
                else if (!e.IsChecked && mitems[(int)cb.Tag].bl)
                {
                    mitems[(int)cb.Tag].bl = false;
                    this.NotifyDataSetChanged();
                }
            }

            internal void changeState(int tag, bool v)
            {
                mitems[tag].bl = v;
                this.NotifyDataSetChanged();
            }
        }

        public class DataViewHolder : Java.Lang.Object
        {
            public ImageView iv { get; set; }
            public TextView tv { get; set; }
            public CheckBox cb { get; set; }

        }
        public class TableList : Java.Lang.Object
        {
            private string v;



            public TableList(string name, bool b)
            {
                this.Name = name;
                this.bl = b;
            }
            public string Name { get; set; }
            public bool bl { get; set; }
        }


    }
}

