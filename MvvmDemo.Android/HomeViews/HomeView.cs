using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using MvvmDemo.Core.Models;
using MvvmDemo.Core.ViewModels;
using System.Collections.Generic;

namespace MvvmDemo.Android.HomeViews
{
    [MvxActivityPresentation]
    [Activity(Label = "Marvel Comics")]
    public class HomeView : MvxActivity
    {
        private ListView comiclistview;
        private List<Comic> mlist;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);
            MvxListView comiclistview = FindViewById<MvxListView>(Resource.Id.mvx_list);
            comiclistview.ItemTemplateId = Resource.Layout.ListItem;

            /*
            comiclistview = FindViewById<ListView>(Resource.Id.list_view_marvel);
           // ComicService comicService = new ComicService();
            //mlist = await comicService.GetComics();
            //adapter = new ComicAdapter(this, mlist);
            //comiclistview.Adapter = adapter;
            //comiclistview.ItemClick += ComicistView_ItemClick;

            if (mlist.Count > 0)
            {
                FindViewById<ProgressBar>(Resource.Id.progress_bar_comic_list).Visibility = ViewStates.Gone;
            }
            */
        }

        private void ComicistView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var select = mlist[e.Position].id;
            Intent i = new Intent(this, typeof(ComicView));
           // i.PutExtra("Comic", mlist[e.Position]);
            StartActivity(i);
        }

    }

}
