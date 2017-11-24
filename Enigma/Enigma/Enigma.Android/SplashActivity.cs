using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Application = Android.App.Application;

namespace Enigma.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {

        protected override void OnResume()
        {
            base.OnResume();

            Task.Run(() =>
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            });
        }

        public override void OnBackPressed() { }
    }
}