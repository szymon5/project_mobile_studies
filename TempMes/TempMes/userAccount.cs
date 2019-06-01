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
using Newtonsoft.Json;

namespace TempMes
{
    [Activity(Label = "userAccount")]
    public class userAccount : Activity
    {
        private TextView txtWelcome;
        private ListView Temp_data;
        private Button show_data, settings, logout;
        private BaseAdapter<Temperature> adapter;
        private List<Temperature> temps;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.userAccount);
            // Create your application here

            txtWelcome = FindViewById<TextView>(Resource.Id.txtWelcomeUser);
            Temp_data = FindViewById<ListView>(Resource.Id.lvMess_data);
            show_data = FindViewById<Button>(Resource.Id.btnShowData);
            settings = FindViewById<Button>(Resource.Id.btnSettings);
            logout = FindViewById<Button>(Resource.Id.btnLogout);

            txtWelcome.Text += UserAuthority.nick;

            show_data.Click += (s, e) =>
            {
                temps = JsonConvert.DeserializeObject<List<Temperature>>(Help.JSON);
                adapter = new TempAdapter(this, temps);
                Temp_data.Adapter = adapter;
            };

        }
    }
}