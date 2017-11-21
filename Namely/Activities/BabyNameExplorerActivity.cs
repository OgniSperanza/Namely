using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Namely.Core.Model;
using Namely.Core.Service;
using Namely.Adapters;
using Android.Content;
using Namely.Core.Repository;
using System.IO;
using SQLite;
using System.Threading.Tasks;
using System;
using Android.Views;

namespace Namely
{
    [Activity(Label = "Baby Name Explorer")]
    //[Activity(Label = "Baby Name Explorer", MainLauncher = true)]
    public class BabyNameExplorerActivity : Activity
    {
        private ListView babyNameListView;
        private List<BabyName> allBabyNames;
        private Button editNameButton;
        //private Button deleteNameButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                SetContentView(Resource.Layout.BabyNameExplorerView);

                babyNameListView = FindViewById<ListView>(Resource.Id.babyNameListView);

                GetData();

                BindData();

                FindViews();

                HandleEvents();

                ConfigureControls();


            }
            catch (System.Exception ex) 
            {
                var debug = ex.Message + ex.InnerException;
                throw;
            }
        }

        private void ConfigureControls()
        {
            babyNameListView.FastScrollEnabled = true;
        }

        private void BindData()
        {
            babyNameListView.Adapter = new BabyNameListAdapter(this, allBabyNames);
        }


        private void FindViews()
        {
            //babyNameListView = FindViewById<ListView>(Resource.Id.babyNameListView);

            editNameButton = FindViewById<Button>(Resource.Id.editNameButton);
           // deleteNameButton = FindViewById<Button>(Resource.Id.deleteNameButton);
        }

        private void HandleEvents()
        {
            babyNameListView.ItemClick += BabyNameListView_ItemClick; //REFACTOR: Currently EditButton opens detail view. 
            
            //This throws an error, I need to loop through all rows and add the event, somehow
            //editNameButton.Click += EditNameButton_Click;
        }

        private void EditNameButton_Click(object sender, System.EventArgs e)
        {
            var babyName = allBabyNames[(int)((Button)sender).Tag];

            var intent = new Intent();
            intent.SetClass(this, typeof(BabyNameDetailActivity));
            Intent.PutExtra("selectedBabyName", babyName.Name);
        }

        private void GetData()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                                     "NamelyDb-DEV.db3");

            SQLiteConnection myConn = new SQLiteConnection(dbPath);
            var dbHelper = new DbHelper(myConn);

            allBabyNames = dbHelper.GetAllNames();
        }

        private void BabyNameListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //REFACTOR: Figure out why this event is ignored and how to fix it.
            var babyName = allBabyNames[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(BabyNameDetailActivity));
            intent.PutExtra("selectedBabyName", babyName.Name);

            StartActivity(intent);
        }
    }
}

#region Old Code
//babyNameDataService = new BabyNameDataService();
//    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

//SQLiteAsyncConnection myConn = new SQLiteAsyncConnection(dbPath);
//allBabyNames = babyNameDataService.GetAllBabyNames();
//getNames = dbHelper.GetNamesAsync();
//private Task<List<BabyName>> getNames;
//private BabyNameDataService babyNameDataService;
//private DbHelper dbHelper;
//private void AssignTags()
//{
//    foreach (var listViewItem in babyNameListView)
//    {

//    }
//}
//babyNameTextView = FindViewById<TextView>(Resource.Id.babyNameTextView);
//nickNameTextView = FindViewById<TextView>(Resource.Id.nickNamesTextView);
//pronunciationTextView = FindViewById<TextView>(Resource.Id.pronunciationTextView);
#endregion