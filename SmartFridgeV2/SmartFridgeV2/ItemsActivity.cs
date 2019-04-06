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
    [Activity(Label = "ItemsActivity")]
    public class ItemsActivity : Activity
    {
        public static List<Item> namirnice=new List<Item>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_items);
            var namirnice = FindViewById<Button>(Resource.Id.namirniceBtn);
            var dodaj = FindViewById<Button>(Resource.Id.dodajBtn);
            namirnice.Click += NamirniceClick;
            dodaj.Click += Dodaj_Click;

        }
        private void Dodaj_Click(object sender, EventArgs e)
        {
            var intent=new Intent(this,typeof(DodajAcivity));
           StartActivity(intent);
        }

        private void NamirniceClick(object sender, EventArgs e)
        {
            var intent=new Intent(this,typeof(ListaNamirnicaActivity));
            StartActivity(intent);
        }
        
    }
}