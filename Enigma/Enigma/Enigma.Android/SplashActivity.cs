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
        private bool _started = false;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistantState)
        {
            base.OnCreate(savedInstanceState, persistantState);
        }

        protected override void OnStart()
        {
            base.OnStart();
            if (!_started)
            {
                _started = true;
                Task startupWork = new Task(() => { SimulateStartup(); });
                startupWork.Start();
            }
            else
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }
        }

        async void SimulateStartup()
        {

            await Task.Delay(3000); 
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public override void OnBackPressed() { }
    }
}