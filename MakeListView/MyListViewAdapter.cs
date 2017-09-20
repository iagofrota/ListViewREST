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

namespace MakeListView {
    class MyListViewAdapter: BaseAdapter<Pessoa>
    {
        private List<Pessoa> mItems;
        private Context mContext;

        public MyListViewAdapter(Context context, List<Pessoa> items)
        {
            mItems = items;
            mContext = context;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);
            }
            TextView razaoSocial = row.FindViewById<TextView>(Resource.Id.razaoSocial);
            razaoSocial.Text = mItems[position].razaoSocial;

            TextView nomeFantasia = row.FindViewById<TextView>(Resource.Id.nomeFantasia);
            nomeFantasia.Text = mItems[position].nomeFantasia;

            TextView cpf = row.FindViewById<TextView>(Resource.Id.cpf);
            cpf.Text = mItems[position].cpfCnpj;

            return row;
        }

        public override int Count
        {
            get { return mItems.Count; }
        }

        public override Pessoa this[int position]
        {
            get { return mItems[position]; }
        }
    }
}