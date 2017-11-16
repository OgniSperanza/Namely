
using Android.App;
using Android.OS;
using Android.Widget;
using Namely.Core.Model;
using Namely.Core.Service;

namespace Namely
{
    [Activity(Label = "Baby Name Data Analysis")]
    //[Activity(Label = "Baby Name Detail", MainLauncher = true)]
    public class BabyNameDataAnalysisActivity : Activity
    {
        //REFACTOR: The database schema needs to change for this class to work
        private TextView totalNameCountTextView;
        private TextView firstNameCountTextView;
        private TextView middleNameCountTextView;

        private BabyNameDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BabyNameDataAnalysisView);

            //BabyNameDataService dataService = new BabyNameDataService();
            dataService = new BabyNameDataService();


            FindViews();
            BindData();
            HandleEvents();
        }

        private void FindViews()
        {
            totalNameCountTextView = FindViewById<TextView>(Resource.Id.TotalNameCountTextView);
            firstNameCountTextView = FindViewById<TextView>(Resource.Id.FirstNameCountTextView);
            middleNameCountTextView = FindViewById<TextView>(Resource.Id.MiddleNameCountTextView);
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
        }

        //private void nextbutton_click(sender, e)
        //{ do something }

        //private void likebutton_click(sender, e)
        //{ do something }
    }
}