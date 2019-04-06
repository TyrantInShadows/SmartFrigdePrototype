using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace SmartFridgeV2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true,NoHistory = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource

            ItemsActivity.namirnice.Add(new Item("Jaja", 13,"komada"));
            ItemsActivity.namirnice.Add(new Item("Mleko", 2,"l"));
            ItemsActivity.namirnice.Add(new Item("Brasno", 37,"kg"));
            SetContentView(Resource.Layout.activity_main);
            FindViewById<ImageButton>(Resource.Id.imageButton1).Click += ImageButtonClick;
        }

        void ImageButtonClick(object sender, EventArgs e)
        {
            if (sender is ImageButton)
            {
                StartActivity(typeof(LoginActivity));
            }
        }
    }
}