using System;
using Android.Views;
using Enigma;
using Namespace.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidHasHardwareKeys))]

namespace Namespace.Droid
{
    class AndroidHasHardwareKeys : App.IHasHardwareKeys
    {
        public bool GetHasHardwareKeys()
        {
            return ViewConfiguration.Get(Android.App.Application.Context).HasPermanentMenuKey;
        }
    }
}