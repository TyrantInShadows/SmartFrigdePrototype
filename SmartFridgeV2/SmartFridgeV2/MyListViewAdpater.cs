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

namespace SmartFridgeV2
{
    class MyListViewAdpater : BaseAdapter<Item>
    {
        private List<Item> items;
        private Context mContext;

        public MyListViewAdpater(List<Item> items, Context mContext)
        {
            this.items = items;
            this.mContext = mContext;
        }

        public override Item this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
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
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.ListaClan, null, false);
            }

            TextView txtIme = row.FindViewById<TextView>(Resource.Id.txtIme);
            txtIme.Text = items[position].Name;
            TextView txtKol = row.FindViewById<TextView>(Resource.Id.txtkol);
            txtKol.Text = items[position].Count.ToString();
            TextView txtMera = row.FindViewById<TextView>(Resource.Id.txtMera);
            String s = items[position].Merna_jedinica;
            if (s.Contains("kg"))
            {
                txtMera.Text= "Kilogram";
            }
            else if(s.Contains("komada"))
            {
                txtMera.Text = "Komad";
            }
            else if (s.Contains("ml"))
            {
                txtMera.Text = "Mililitar";
            }
            else if (s.Contains("g"))
            {
                txtMera.Text = "Gram";
            }
            else if (s.Contains("l"))
            {
                txtMera.Text = "Litar";
            }
            return row;
        }
    }
}