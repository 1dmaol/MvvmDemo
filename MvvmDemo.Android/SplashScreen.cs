using Android.App;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using Android.Content.PM;

namespace MvvmDemo.Android
{
    [Activity(
       Label = "MvvmDemo"
       , MainLauncher = true
       , NoHistory = true
       , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity<MvxAndroidSetup<Core.App>, Core.App>
    {
        public SplashScreen()
             : base(Resource.Layout.SplashScreen)
        {
        }
    }
}