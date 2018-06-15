using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Util;
using Java.Lang;
using Android.Text;

namespace ListViewCheckBoxTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity,Android.Text.ITextWatcher
    {
        ListView mListView;
        static List<Button> list = new List<Button>();
        MyAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            list.Add(new Button(this));
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            mListView = FindViewById<ListView>(Resource.Id.listview);

            EditText et = FindViewById<EditText>(Resource.Id.et);
            et.AddTextChangedListener(this);

            adapter = new MyAdapter(this, MyApplication.useritems);
            mListView.Adapter = adapter;
            mListView.ItemClick += MListView_ItemClick;
        }

        //click the item to change the CheckBox's state by Adapter's changeState method
        //And, at the same time, we need to record the CheckBox's state by our Data source -- mitems
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

        //if the acitivty is destroyed, you need to update the database.
        protected override void OnDestroy()
        {
            base.OnDestroy();

            for (int i=0;i<MyApplication.useritems.Count;i++)
            {
                MyApplication.daoList[i].isCheck = MyApplication.useritems[i].bl;

            }
            DBHelper.updateData(MyApplication.daoList);
        }


        // Text watch start --------------------------------------------------
        public void AfterTextChanged(IEditable s)
        {
           
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
           
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            adapter.Filter.InvokeFilter(s);
        }

        // Text watch end --------------------------------------------------
        class MyAdapter : BaseAdapter, IFilterable
        {
            Context mContext;
            List<TableList> mitems { get; set; }
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


            public Filter Filter { get { return new MyFilter(mitems,this); } }

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
               // holder.tv.SetTextColor(mContext.GetColorStateList(Resource.Color.filename));
                //Add CheckedChange event to detect the CheckBox's click event and change the mitems's CheckBox's state.
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

               // DBHelper.updateData(new Dao((int)cb.Tag + 1, mitems[(int)cb.Tag].Name, mitems[(int)cb.Tag].bl));
            }

            internal void changeState(int tag, bool v)
            {
                mitems[tag].bl = v;
                this.NotifyDataSetChanged();
               // DBHelper.updateData(new Dao(tag + 1, mitems[tag].Name, mitems[tag].bl));
            }

            public class MyFilter : Filter
            {
                List<TableList> originData;
                List<TableList> tempData;
                MyAdapter adapter;
                public MyFilter(List<TableList> data,MyAdapter adapter)
                {
                    this.originData = data;
                    this.tempData = MyApplication.useritems;
                    this.adapter = adapter;

                }
                protected override FilterResults PerformFiltering(ICharSequence constraint)
                {
                    FilterResults results = new FilterResults();
                    if (constraint==null||constraint.Length()==0)
                    {
                        TableList[] resultsValues = new TableList[tempData.Count];
                        for (int i = 0; i < tempData.Count; i++)
                        {
                            resultsValues[i] = tempData[i];
                        }
                        results.Values = resultsValues;
                        results.Count = tempData.Count;
                    }
                    else
                    {

                        List<TableList> mitemsFilter = new List<TableList>();
                        var s = constraint.ToString().ToLower();

                        for (int i = 0; i < originData.Count; i++)
                        {
                            string dataNames = originData[i].Name;
                            if (dataNames.ToLower().StartsWith(s.ToString()))
                            {
                                mitemsFilter.Add(originData[i]);
                            }
                        }


                        TableList[] resultsValues = new TableList[mitemsFilter.Count];
                        for (int i = 0; i < mitemsFilter.Count; i++)
                        {
                            resultsValues[i] = mitemsFilter[i];
                        }

                        results.Count = mitemsFilter.Count;
                        results.Values = resultsValues;
                    }
                    return results;

                }

                protected override void PublishResults(ICharSequence constraint, FilterResults results)
                {
                    var arry=results.Values.ToArray<TableList>();
                    List<TableList> filteredList = new List<TableList>();
                    for (int i = 0; i < arry.Length; i++)
                    {
                        filteredList.Add(arry[i]);
                    }
                    this.adapter.mitems= filteredList;

                    if (results.Count > 0)
                    {
                        this.adapter.NotifyDataSetChanged();
                    }
                    else
                    {
                        this.adapter.NotifyDataSetInvalidated();
                   }
                    

                }
            }
        }

        public class DataViewHolder : Java.Lang.Object
        {
            public ImageView iv { get; set; }
            public TextView tv { get; set; }
            public CheckBox cb { get; set; }

        }


        //I add the bool in this class, so you can change the CheckBox's state by your Data Source
        //That means that your CheckBox's state based upon your Data Source.
        


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

