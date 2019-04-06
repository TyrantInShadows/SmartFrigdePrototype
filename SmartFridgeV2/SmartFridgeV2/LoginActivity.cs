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
    [Activity(Label = "LoginActivity",NoHistory = true)]
    public class LoginActivity : Activity
    {
        public static List<User> users;
        private Button create;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            users=new List<User>();
            users.Add(new User("admin","admin"));
            SetContentView(Resource.Layout.activity_login);
            var login = FindViewById<Button>(Resource.Id.loginBnt);
            login.Click += Login_Click;
            //var username = FindViewById<EditText>(Resource.Id.username);
            //username.Touch += Username_Touch;
            //var password = FindViewById<EditText>(Resource.Id.password);
            //password.Touch += Password_Touch;
            create = FindViewById<Button>(Resource.Id.btnCreate);
            create.Click += Create_Click;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_create_acc dialogCreate=new dialog_create_acc();
            dialogCreate.Show(transaction, "Create Acc Dialog");
        }

        //private void Password_Touch(object sender, View.TouchEventArgs e)
        //{
        //    var password = FindViewById<EditText>(Resource.Id.password);
        //    password.Text = "";
        //    password.RequestFocus();
        //    password.Touch -= Password_Touch;
        //}

        //private void Username_Touch(object sender, View.TouchEventArgs e)
        //{
        //    var username = FindViewById<EditText>(Resource.Id.username);
        //    username.Text = "";
        //    username.RequestFocus();
        //    username.Touch -= Username_Touch;
        //}

        private void Login_Click(object sender, EventArgs e)
        {
            var username = FindViewById<EditText>(Resource.Id.username);
            var password = FindViewById<EditText>(Resource.Id.password);
            int count = 0;

            foreach (User u in users)
            {
                if (username.Text == u.UserName && password.Text == u.Password)
                {
                    var intent = new Intent(this, typeof(ItemsActivity));
                    StartActivity(intent);
                    count++;
                }
                if (count > 0)
                {
                    break;
                }
            }
            if (count == 0)
            {
                Toast.MakeText(this, "Ne postoji korisnik", ToastLength.Long).Show();
            }

        }
    }
}