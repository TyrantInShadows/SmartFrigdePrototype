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
    [Activity(Label = "DodajAcivity")]
    public class DodajAcivity : Activity
    {
        private EditText Ime;
        private EditText kolicina;
        private Spinner spinner;
        private bool flag = false;
        private List<string> arraySpinner;
        private string itemText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_dodaj);
            arraySpinner = new List<string>();
            dodaj();
            spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            ArrayAdapter<string> adapter=new ArrayAdapter<string>(this,Resource.Layout.support_simple_spinner_dropdown_item,arraySpinner);
            adapter.SetDropDownViewResource(Resource.Layout.support_simple_spinner_dropdown_item);
            spinner.Adapter = adapter;
            Ime = FindViewById<EditText>(Resource.Id.imeNamirnice);
            kolicina = FindViewById<EditText>(Resource.Id.kolicinaNamirnice);
           
            spinner.ItemSelected += Spinner_ItemSelected;
            var dodajBtn = FindViewById<Button>(Resource.Id.dodajNamBtn);
            var cancelBtn = FindViewById<Button>(Resource.Id.cancelBtn);
            dodajBtn.Click += DodajBtn_Click;
            cancelBtn.Click += CancelBtn_Click;
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            itemText = spinner.GetItemAtPosition(e.Position).ToString();
            string item = itemText;
            switch (itemText)
            {
                case "l": item = "Litar";
                    break;
                case "ml":
                    item = "Mililitar";
                    break;
                case "kg":
                    item = "Kilogram";
                    break;
                case "g":
                    item = "Gram";
                    break;
                default: itemText= spinner.GetItemAtPosition(e.Position).ToString();break;
            }
            string toast =
                string.Format("Merna jedinica koju ste izabrali je: " + item);
            if(flag==true)
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            flag = true;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void DodajBtn_Click(object sender, EventArgs e)
        {
            ItemsActivity.namirnice.Add(new Item(Ime.Text, Int32.Parse(kolicina.Text), itemText));
            Ime.Text = "";
            kolicina.Text = "";
        }

        public void dodaj()
        {
            arraySpinner.Add("Komada");
            arraySpinner.Add("kg");
            arraySpinner.Add("g");
            arraySpinner.Add("l");
            arraySpinner.Add("ml");
        }
}
}