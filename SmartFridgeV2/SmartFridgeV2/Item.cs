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
    public class Item
    {
        private string name;
        private int count;
        private string merna_jedinica;
        public Item()
        {
            name = "N/D";
            count = 0;
            merna_jedinica = "N/D";
        }
        public Item(string n,int c,string m)
        {
            name = n;
            count = c;
            merna_jedinica = m;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public string Merna_jedinica
        {
            get { return merna_jedinica; }
            set { merna_jedinica = value; }
        }

    }
}