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
using static Android.Widget.AdapterView;
using static Namely.Adapters.BabyNameListAdapter;

namespace Namely
{
    [Activity(Label = "Baby Name Explorer")]
    //[Activity(Label = "Baby Name Explorer", MainLauncher = true)]
    public class BabyNameExplorerActivity : Activity, IOnItemClickListener, IRowViewOnClickListener
    {
        private ListView babyNameListView;
        private List<BabyName> allBabyNames;
        private BabyNameListAdapter babyNameListAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                SetContentView(Resource.Layout.BabyNameExplorerView);

                FindViews();

                GetData();

                BindData();

                HandleEvents();

                ConfigureControls();
            }
            catch (System.Exception ex) 
            {
                var debug = ex.Message + ex.InnerException;
            }
        }

        private void ConfigureControls()
        {
            babyNameListView.FastScrollEnabled = true;
        }

        private void BindData()
        {
           //Testing OnClickListener
            babyNameListAdapter = new BabyNameListAdapter(this, allBabyNames);
            babyNameListAdapter.SetRowViewItemOnClickListener(this);        
            babyNameListView.Adapter = babyNameListAdapter;
        }


        private void FindViews()
        {           
            babyNameListView = FindViewById<ListView>(Resource.Id.babyNameListView);
        }

        private void HandleEvents()
        {
            //Testing OnClick Listener
            babyNameListView.OnItemClickListener = this;
        }

        private void GetData()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                                     "NamelyDb-DEV.db3");

            SQLiteConnection myConn = new SQLiteConnection(dbPath);
            var dbHelper = new DbHelper(myConn);

            allBabyNames = dbHelper.GetAllNames();
        }

        private void BabyNameListView_ItemClick(int position)
        {
            var babyName = allBabyNames[position];

            var intent = new Intent();
            intent.SetClass(this, typeof(BabyNameDetailActivity));
            intent.PutExtra("selectedBabyName", babyName.Name);

            StartActivity(intent);
        }

        //Testing OnClick Listener
        public void ItemClick(View v)
        {
            int position;
            position = (int)v.Tag;
            switch (v.Id)
            {
                case Resource.Id.editNameButton:
                    //System.Diagnostics.Debug.Write("editNameButton click" + " position=" + position);
                    EditButton_Click(position);
                    break;
                case Resource.Id.deleteNameButton:
                    //System.Diagnostics.Debug.Write("deleteNameButton click" + " position=" + position);
                    break;
                default:
                    BabyNameListView_ItemClick(position);
                    break;
            }
        }

        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            //System.Diagnostics.Debug.Write("RowView click");
            ItemClick(view);
        }

        public void EditButton_Click(int position)
        {
            var babyName = allBabyNames[position];

            var intent = new Intent();
            intent.SetClass(this, typeof(BabyNameDetailActivity));
            intent.PutExtra("selectedBabyName", babyName.Name);

            StartActivity(intent);
        }
    }
}

#region Old Code
//private void BabyNameListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
//{
//    var babyName = allBabyNames[e.Position];

//    var intent = new Intent();
//    intent.SetClass(this, typeof(BabyNameDetailActivity));
//    intent.PutExtra("selectedBabyName", babyName.Name);

//    StartActivity(intent);
//}
//babyNameListView.Adapter = new BabyNameListAdapter(this, allBabyNames);
//private Button editNameButton;
//private Button deleteNameButton;
//editNameButton = FindViewById<Button>(Resource.Id.editNameButton);
//deleteNameButton = FindViewById<Button>(Resource.Id.deleteNameButton);
//babyNameListView.ItemClick += BabyNameListView_ItemClick; 

//This throws an error, I need to loop through all rows and add the event, somehow
//editNameButton.Click += EditNameButton_Click;
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