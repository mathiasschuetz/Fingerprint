using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Plugin.Fingerprint;

namespace Fingerprint
{
    [Activity(Label = "Fingerprint", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            this.SetContentView(Resource.Layout.Main);
        }

        protected override async void OnResume()
        {
            base.OnResume();

            var result = await CrossFingerprint.Current.AuthenticateAsync("Prove you have fingers!");
            if (result.Authenticated)
            {
                // do secret stuff :)
            }
            else
            {
                // not allowed to do secret stuff :(
            }
        }
    }
}