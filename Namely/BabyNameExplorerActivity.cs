using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Namely.Core.Model;
using Namely.Core.Service;

namespace Namely
{
    [Activity(Label = "Baby Name Explorer")]
    public class BabyNameExplorerActivity : Activity
    {
        private ListView babyNameListView;
        private List<BabyName> allBabyNames;
        private BabyNameDataService BabyNameDataService;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}