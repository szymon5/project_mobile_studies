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
    public class Temperature
    {
        public double temp1 { get; set; }
        public double temp2 { get; set; }
        public DateTime Mes_date { get; set; }
    }
}