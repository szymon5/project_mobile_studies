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
    public static class UserAuthority
    {
        public static int id;
        public static string nick = "";
        public static bool isLogged;
        public static string isAccountCreated;
    }
}