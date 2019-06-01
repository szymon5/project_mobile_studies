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

namespace TempMes
{
    [Activity(Label = "Settings")]
    public class Settings : Activity
    {
        private Button change_pass, clear, delete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Settings);
            // Create your application here

            change_pass = FindViewById<Button>(Resource.Id.btnChange_pass);
            clear = FindViewById<Button>(Resource.Id.btnClearMes);
            delete = FindViewById<Button>(Resource.Id.btnDeleteAcc);




        }
    }
}