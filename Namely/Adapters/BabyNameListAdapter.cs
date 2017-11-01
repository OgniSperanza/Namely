﻿using System;
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
using Namely.Utility;
using SQLite;
using Namely.Core.Repository;
using System.IO;

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

            var imageBitmap = new ImageHelper().GetImageBitmapFromUrl("https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png");

            if (convertView == null)
            {
                //convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
                convertView = context.LayoutInflater.Inflate(Resource.Layout.BabyNameRowView, null);
            }

            //convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.babyNameTextView).Text = item.Name;
            //convertView.FindViewById<TextView>(Resource.Id.nickNamesTextView).Text = String.Join(", ", (item.NickNames is null ? new List<string>{"N/A"} : item.NickNames)); //Refactor
            convertView.FindViewById<TextView>(Resource.Id.pronunciationTextView).Text = item.Pronunciation;
            convertView.FindViewById<ImageView>(Resource.Id.babyNameImageView).SetImageBitmap(imageBitmap);
            Button deleteName;
            deleteName = convertView.FindViewById<Button>(Resource.Id.deleteNameButton);
            deleteName.Click += DeleteName_Click;
            return convertView;
        }

        private void DeleteName_Click(object sender, EventArgs e)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                                         "NamelyDb-DEV.db3");
            //    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

            //SQLiteAsyncConnection myConn = new SQLiteAsyncConnection(dbPath);
            SQLiteConnection myConn = new SQLiteConnection(dbPath);
            var dbHelper = new DbHelper(myConn);

            //dbHelper.DeleteItemByName()
        }
    }
}
