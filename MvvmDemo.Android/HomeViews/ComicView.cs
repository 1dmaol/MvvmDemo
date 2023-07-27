using Android.App;
using Android.OS;

namespace MvvmDemo.Android.HomeViews
{
    [Activity (Label = "ComicView")]			
	public class ComicView : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ComicView);
        }
	}
}

