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
    public class TempAdapter : BaseAdapter<Temperature>
    {
        private List<Temperature> temp;
        private Context context;

        public TempAdapter(Context context,List<Temperature> temp)
        {
            this.context = context;
            this.temp = temp;
        }

        public override Temperature this[int position]
        {
            get { return temp[position]; }
        }

        public override int Count
        {
            get { return temp.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null) row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.data_row, null, false);

            TextView sensor1 = row.FindViewById<TextView>(Resource.Id.txtSensor1);
            TextView sensor2 = row.FindViewById<TextView>(Resource.Id.txtSensor2);
            TextView date = row.FindViewById<TextView>(Resource.Id.txtDate);

            sensor1.Text = temp[position].temp1.ToString();
            sensor2.Text = temp[position].temp2.ToString();
            date.Text = temp[position].Mes_date.ToString();

            return row;
        }
    }
}