using Android.App;
using Android.Widget;
using Android.OS;

namespace Namely
{
    [Activity(Label = "Namely", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Button testAppButton = FindViewById<Button>(Resource.Id.TestAppButton);
            //TextView testAppEditText = FindViewById<EditText>(Resource.Id.TestAppEditText);

            //testAppButton.Click += delegate { testAppEditText.Text = "testing"; };
        }
    }
}

