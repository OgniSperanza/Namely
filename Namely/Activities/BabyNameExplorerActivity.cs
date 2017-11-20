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

namespace Namely
{
    [Activity(Label = "Baby Name Explorer")]
    //[Activity(Label = "Baby Name Explorer", MainLauncher = true)]
    public class BabyNameExplorerActivity : Activity
    {
        private ListView babyNameListView;
        //private Task<List<BabyName>> getNames;
        private List<BabyName> allBabyNames;
        //private BabyNameDataService babyNameDataService;
        //private DbHelper dbHelper;
        private Button editNameButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                SetContentView(Resource.Layout.BabyNameExplorerView);

                babyNameListView = FindViewById<ListView>(Resource.Id.babyNameListView);
                //babyNameDataService = new BabyNameDataService();
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                                         "NamelyDb-DEV.db3");
                //    SQLiteAsyncConnection newDb = new SQLiteAsyncConnection(dbPath);

                //SQLiteAsyncConnection myConn = new SQLiteAsyncConnection(dbPath);
                SQLiteConnection myConn = new SQLiteConnection(dbPath);                
                var dbHelper = new DbHelper(myConn);
                //allBabyNames = babyNameDataService.GetAllBabyNames();
                //getNames = dbHelper.GetNamesAsync();

                allBabyNames = dbHelper.GetAllNames();

                babyNameListView.Adapter = new BabyNameListAdapter(this, allBabyNames);

                //babyNameListView.FastScrollEnabled = true;
                babyNameListView.ItemClick -= BabyNameListView_ItemClick;
                babyNameListView.ItemClick += BabyNameListView_ItemClick;

                editNameButton = FindViewById<Button>(Resource.Id.editNameButton);

            }
            catch (System.Exception ex) 
            {
                var debug = ex.Message + ex.InnerException;
                throw;
            }
        }

        //private void AssignTags()
        //{
        //    foreach (var listViewItem in babyNameListView)
        //    {

        //    }
        //}

        private void FindViews()
        {
            //babyNameTextView = FindViewById<TextView>(Resource.Id.babyNameTextView);
            //nickNameTextView = FindViewById<TextView>(Resource.Id.nickNamesTextView);
            //pronunciationTextView = FindViewById<TextView>(Resource.Id.pronunciationTextView);
        }
        private void BabyNameListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var babyName = allBabyNames[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(BabyNameDetailActivity));
            Intent.PutExtra("selectedBabyName", babyName.Name);
        }
    }
}