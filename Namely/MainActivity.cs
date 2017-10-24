using Android.App;

using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Namely.Core.Repository;
using SQLite;
using System.IO;
using System.Collections.Generic;
using Namely.Core.Model;

namespace Namely
{
    [Activity(Label = "Namely", MainLauncher = true, Icon = "@drawable/icon")]
    //[Activity(Label = "Namely")]
    public class MainActivity : Activity
    {
        //private TextView babyNameTextView;
        //private TextView nickNameTextView;
        //private TextView pronunciationTextView;

        //private BabyName selectedBabyName;
        //private BabyNameDataService dataService;
        private Button reviewDataButton;
        private Button syncDataButton;
        private Button nameExplorerButton;
        private Button firstNameButton;
        private Button middleNameButton;
        private EditText firstNameEditText;
        private EditText middleNameEditText;
        public static SQLiteConnection connection;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Button testAppButton = FindViewById<Button>(Resource.Id.TestAppButton);
            //TextView testAppEditText = FindViewById<EditText>(Resource.Id.TestAppEditText);

            //testAppButton.Click += delegate { testAppEditText.Text = "testing"; };
            //BabyNameDataService dataService = new BabyNameDataService();
            //dataService = new BabyNameDataService();
            //selectedBabyName = dataService.GetBabyNameByName("Jacob");
            CreateDatabase();
            FindViews();
            BindData();
            HandleEvents();
        }

        private void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "NamelyDb-DEV.db3");
            //string dbPath = "NamelyDb-DEV.db3";

            //bool exists = File.Exists(dbPath);

            //if (!exists)
            //{    
            //connection = new SQLiteConnection(dbPath);
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<BabyName>();
            //}
            //else
            //{
            //    connection = new SQLiteConnection(dbPath);
            //}
        }

        private void FindViews()
        {
            //babyNameTextView = FindViewById<TextView>(Resource.Id.babyNameTextView);
            //nickNameTextView = FindViewById<TextView>(Resource.Id.nickNamesTextView);
            //pronunciationTextView = FindViewById<TextView>(Resource.Id.pronunciationTextView);

            reviewDataButton = FindViewById<Button>(Resource.Id.ReviewDataButton);
            syncDataButton = FindViewById<Button>(Resource.Id.SyncDataButton);
            nameExplorerButton = FindViewById<Button>(Resource.Id.NameExplorerButton);
            firstNameButton = FindViewById<Button>(Resource.Id.AddFNameButton);
            middleNameButton = FindViewById<Button>(Resource.Id.AddMNameButton);
            firstNameEditText = FindViewById<EditText>(Resource.Id.MiddleNameEditText);
            middleNameEditText = FindViewById<EditText>(Resource.Id.FirstNameEditText);
        }

        private void BindData()
        {
            //babyNameTextView.Text = selectedBabyName.Name;
            //nickNameTextView.Text = selectedBabyName.NickNames.ToString();
            //pronunciationTextView.Text = selectedBabyName.Pronunciation;

            //ImageHelper
            //Set ImageView
        }

        //Finish Implementing Below:
        private void HandleEvents()
        {
            //nextbutton.click += nextbutton_click
            //likebutton.click += likebutton_click
            reviewDataButton.Click += ReviewButton_Click;
            syncDataButton.Click += SyncDataButton_Click;
            nameExplorerButton.Click += NameExplorerButton_Click;
            firstNameButton.Click += FirstNameButton_Click;
            middleNameButton.Click += MiddleNameButton_Click;
        }

        private void MiddleNameButton_Click(object sender, EventArgs e)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                             "NamelyDb-DEV.db3");
            //    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

            SQLiteAsyncConnection myConn = new SQLiteAsyncConnection(dbPath);
            //var dbHelper = new DbHelper(myConn);
            var dbHelper = new DbHelper(connection);

            dbHelper.SaveItemAsync(new Core.Model.BabyName
            {
                Name = middleNameEditText.Text,
                History = "",
                Meaning = "",
                NickNames = new List<string>(),
                Pronunciation = ""
            });
        }

        private void FirstNameButton_Click(object sender, EventArgs e)
        {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                                 "NamelyDb-DEV.db3");
            //    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

            SQLiteAsyncConnection myConn = new SQLiteAsyncConnection(dbPath);
            //var dbHelper = new DbHelper(myConn);
            var dbHelper = new DbHelper(connection);

            dbHelper.SaveItemAsync(new Core.Model.BabyName
            {
                Name = firstNameEditText.Text,
                History = "",
                Meaning = "",
                NickNames = new List<string>(),
                Pronunciation = ""
            });
        }

        private void NameExplorerButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BabyNameExplorerActivity));
            StartActivity(intent);
        }

        private void SyncDataButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BabyNameExplorerActivity)); //Create the sync activity and replace here.
            StartActivity(intent);

            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                 "NamelyDb-DEV.db3");
            //    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

            SQLiteConnection myConn = new SQLiteConnection(dbPath);
            var dbHelper = new DbHelper(myConn);
            myConn.CreateTable<BabyName>();
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BabyNameExplorerActivity)); //Create the review activity and replace here.
            StartActivity(intent);
            //StartActivityForResult(); I could pass data back and forth with this
        }

        //private void nextbutton_click(sender, e)
        //{ do something }

        //private void likebutton_click(sender, e)
        //{ do something }
    }
}

