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
using Namely.Core.Model;

namespace Namely.Adapters
{
    class BabyNameListAdapter : BaseAdapter<BabyName>
    {
        List<BabyName> items;
        Activity context;

        public BabyNameListAdapter(Activity context, List<BabyName> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override BabyName this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        //public override View GetView(int position, View convertView, ViewGroup parent)
        //{
        //    var item = items[position];

        //    if (convertView == null)  
        //    {
        //        convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
        //    }

        //    convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;

        //    return convertView;
        //}
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;

            return convertView;
        }
    }
}