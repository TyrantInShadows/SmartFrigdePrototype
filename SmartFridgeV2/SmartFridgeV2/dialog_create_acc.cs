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
    class dialog_create_acc:DialogFragment
    {
        private EditText user;
        private EditText password;
        private Button Create;
        private Button cancel;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var mView = inflater.Inflate(Resource.Layout.dialog_create_acc, container,false);
            
            user = mView.FindViewById<EditText>(Resource.Id.txtDialogUser);
            password = mView.FindViewById<EditText>(Resource.Id.txtDialogPass);
            Create = mView.FindViewById<Button>(Resource.Id.btnDialogCreateAccount);
            cancel = mView.FindViewById<Button>(Resource.Id.btnDialogCancel);
            Create.Click += Create_Click;
            cancel.Click += Cancel_Click;
            return mView;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dismiss();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            LoginActivity.users.Add(new User(user.Text,password.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }
    }
}