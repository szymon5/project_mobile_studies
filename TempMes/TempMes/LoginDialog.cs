using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
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
    public class OnLoginDialogEventArgs : EventArgs
    {
        public string login;
        public string password;

        public OnLoginDialogEventArgs() { }
        public OnLoginDialogEventArgs(string login,string password)
        {
            this.login = login;
            this.password = password;
        }
    }
    public class LoginDialog : DialogFragment
    {
        private EditText etlogin;
        private EditText etpassword;
        private Button btnlogin;
        private List<StatusReader> statusReader;

        public event EventHandler<OnLoginDialogEventArgs> OnLoginComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.LoginDialog, container, false);

            etlogin = view.FindViewById<EditText>(Resource.Id.etDialogLogin);
            etpassword = view.FindViewById<EditText>(Resource.Id.etDialogPassword);
            btnlogin = view.FindViewById<Button>(Resource.Id.btnDialogLogin);

            btnlogin.Click += Btnlogin_Click;
            return view;
        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            Uri uri = new Uri(URLAddresses.LOGIN_PHP);
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("Login", etlogin.Text);
            parameters.Add("Password", etpassword.Text);

            byte[] response = webClient.UploadValues(uri, parameters);
            string userStatus = Encoding.UTF8.GetString(response);
            if (userStatus.Contains(Help.TRUE)) UserAuthority.isLogged = true;
            else UserAuthority.isLogged = false;

            if(UserAuthority.isLogged)
            {
                string id = "";
                int index = userStatus.IndexOf(Help.TRUE);
                int bracket = userStatus.IndexOf(Help.SQUARE_BRACKET);

                for(int i=0;i<index;i++)
                {
                    UserAuthority.nick += userStatus[i];
                }
                for(int i=index + Help.TRUE.Length;i<bracket;i++)
                {
                    id += userStatus[i];
                }
                UserAuthority.id = Convert.ToInt16(id);
                Help.JSON = userStatus.Remove(0, 12);
            }
            OnLoginComplete.Invoke(this, new OnLoginDialogEventArgs());
            this.Dismiss();
        }
    }
}