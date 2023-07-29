using Android.App;
using Android.Content;
using Android.OS;
using MvvmCross.Commands;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using MvvmDemo.Core.Models;
using Newtonsoft.Json;
using System.Windows.Input;

namespace MvvmDemo.Android.HomeViews
{
    [MvxActivityPresentation]
    [Activity(Label = "Marvel Comics")]
    public class HomeView : MvxActivity
    {
        private MvxCommand<Comic> _clickCommand;

        public ICommand ClickCommand
            => _clickCommand = _clickCommand ?? new MvxCommand<Comic>(OnClick);

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);
            MvxListView comiclistview = FindViewById<MvxListView>(Resource.Id.mvx_list);
            comiclistview.ItemTemplateId = Resource.Layout.ListItem;
            comiclistview.ItemClick = ClickCommand;
        }


        private void OnClick(Comic item)
        {
            Intent i = new Intent(this, typeof(ComicView));
            i.PutExtra("Comic", JsonConvert.SerializeObject(item));
            StartActivityForResult(i, 0);
        }

    }

}
