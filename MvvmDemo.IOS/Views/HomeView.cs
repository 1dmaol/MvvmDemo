using System;
using System.Collections.Generic;
using System.Security.Policy;
using CoreGraphics;
using FFImageLoading;
using FFImageLoading.Cross;
using FFImageLoading.Work;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Combiners;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmDemo.Core.Models;
using MvvmDemo.Core.ViewModels;
using UIKit;
using Xamarin.Essentials;
using FFImageLoading.Transformations;
using AssetsLibrary;
using MvvmCross.Views;
using MvvmDemo.IOS.Views.Tables;
using MvvmCross.Commands;
using System.Windows.Input;
using MvvmDemo.IOS.Helpers;

namespace MvvmDemo.IOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class HomeView : MvxViewController<HomeViewModel>
    {

        public event EventHandler<EventArgs> SelectedItemChanged;

        public override string Title { get => base.Title; set => base.Title = value; }

        public HomeView() : base("HomeView", null) { }

        protected HomeView(IntPtr handle) : base(handle) { }

        protected HomeView(string nibName, NSBundle bundle) : base(nibName, bundle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<HomeView, Core.ViewModels.HomeViewModel>();
            var frame = new CGRect(0, AppDelegate.kNavigationBarOffset, DeviceDisplay.MainDisplayInfo.Width, IOSHelper.TransformCoordinates(DeviceDisplay.MainDisplayInfo.Height, 800, AppDelegate.kNavigationBarOffset));

            UIActivityIndicatorView loadingIndicatorView = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);

            var tableList = new UITableView(frame);
            var source = new TableSource(tableList);

            this.AddBindings(new Dictionary<object, string>
            {
                {source, "ItemsSource ComicsCollection"}
            });

            tableList.Source = source;

            tableList.ReloadData();
            tableList.RowHeight = AppDelegate.kItemListHeight;
            View.Add(tableList);

            source.SelectedItemChanged += (sender, e) =>
            {
                NavigationController.PushViewController(new ComicView((Comic)source.SelectedItem), true);
            };

            set.Bind(this).For(v => v.Title).To(vm => vm.Title).WithConversion("Visibility");
            set.Bind(loadingIndicatorView).For(s => s.Hidden).ByCombining(new MvxInvertedValueCombiner(), vm => vm.IsLoading);
            set.Apply();

            View.Add(loadingIndicatorView);

            loadingIndicatorView.Color = UIColor.Gray;
            loadingIndicatorView.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor, 0.0f).Active = true;
            loadingIndicatorView.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor, 0.0f).Active = true;
            loadingIndicatorView.TranslatesAutoresizingMaskIntoConstraints = false;
            loadingIndicatorView.StartAnimating();
        }

    }

}


