using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using MvvmDemo.Core.Models;
using Newtonsoft.Json;

namespace MvvmDemo.Android.HomeViews
{
    [Activity (Label = "ComicView")]			
	public class ComicView : MvxActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ComicView);
            Comic comic = JsonConvert.DeserializeObject<Comic>(Intent.GetStringExtra("Comic"));

            FindViewById<ImageView>(Resource.Id.comic_image).SetImageBitmap(Helpers.Helper.GetImageBitmapFromUrl(comic.thumbnailUrl));
            FindViewById<TextView>(Resource.Id.comic_name).SetText(comic.title, TextView.BufferType.Normal);
            FindViewById<TextView>(Resource.Id.comic_description).SetText(comic.description, TextView.BufferType.Normal);

            FindViewById<Button>(Resource.Id.back_button).Click += delegate
            {
                Finish();
            };
        }
    }
}

