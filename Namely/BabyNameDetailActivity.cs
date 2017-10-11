
using Android.App;
using Android.OS;
using Android.Widget;
using Namely.Core.Model;
using Namely.Core.Service;

namespace Namely
{
    [Activity(Label = "Baby Name Detail")]
    //[Activity(Label = "Baby Name Detail", MainLauncher = true)]
    public class BabyNameDetailActivity : Activity
    {
        private TextView babyNameTextView;
        private TextView nickNameTextView;
        private TextView pronunciationTextView;

        private BabyName selectedBabyName;
        private BabyNameDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BabyNameDetailView);

            //BabyNameDataService dataService = new BabyNameDataService();
            dataService = new BabyNameDataService();
            selectedBabyName = dataService.GetBabyNameByName("Jacob");

            FindViews();
            BindData();
            HandleEvents();
        }

        private void FindViews()
        {
            babyNameTextView = FindViewById<TextView>(Resource.Id.babyNameTextView);
            nickNameTextView = FindViewById<TextView>(Resource.Id.nickNamesTextView);
            pronunciationTextView = FindViewById<TextView>(Resource.Id.pronunciationTextView);
        }

        private void BindData()
        {
            babyNameTextView.Text = selectedBabyName.Name;
            nickNameTextView.Text = selectedBabyName.NickNames.ToString();
            pronunciationTextView.Text = selectedBabyName.Pronunciation;

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