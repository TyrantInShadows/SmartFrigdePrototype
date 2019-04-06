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
    [Activity(Label = "ListaNamirnicaActivity")]
    public class ListaNamirnicaActivity : Activity
    {
        private List<Item> proizvodi;
        private EditText search;
        private MyListViewAdpater adapter;
        private ListView lista;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            proizvodi = new List<Item>();
            SetContentView(Resource.Layout.activity_lista_namirnica);
            search = FindViewById<EditText>(Resource.Id.searchEditText);
            search.TextChanged += Search_TextChanged;
            lista = FindViewById<ListView>(Resource.Id.listView1);
            adapter=new MyListViewAdpater(ItemsActivity.namirnice, this);
            lista.Adapter = adapter;
        }

        private void Search_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<Item> searchedItems = (from namirnica in ItemsActivity.namirnice
                                        where namirnica.Name.Contains(search.Text) || namirnica.Merna_jedinica.Contains(search.Text)
                select namirnica).ToList<Item>();
            adapter=new MyListViewAdpater(searchedItems, this);
            lista.Adapter = adapter;
        }
    }
}