using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Namely.Core.Model;
using Namely.Core.Service;
using Namely.Adapters;
using Android.Content;

namespace Namely
{
    [Activity(Label = "Baby Name Explorer")]
    //[Activity(Label = "Baby Name Explorer", MainLauncher = true)]
    public class BabyNameExplorerActivity : Activity
    {
        private ListView babyNameListView;
        private List<BabyName> allBabyNames;
        private BabyNameDataService babyNameDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.BabyNameExplorerView);

            babyNameListView = FindViewById<ListView>(Resource.Id.babyNameListView);
            babyNameDataService = new BabyNameDataService();

            allBabyNames = babyNameDataService.GetAllBabyNames();

            babyNameListView.Adapter = new BabyNameListAdapter(this, allBabyNames);

            babyNameListView.FastScrollEnabled = true;

            babyNameListView.ItemClick += BabyNameListView_ItemClick;
        }

        private void BabyNameListView_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
        {
            var babyName = allBabyNames[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(BabyNameDetailActivity));
            Intent.PutExtra("selectedBabyName", babyName.Name);
        }
    }
}