using System;
using System.Collections.Generic;
using CoreGraphics;
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

namespace MvvmDemo.IOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class HomeView : MvxViewController<HomeViewModel>
    {
        public override string Title { get => base.Title; set => base.Title = value; }
        public HomeView() : base("HomeView", null) { }

        protected HomeView(IntPtr handle) : base(handle) { }

        protected HomeView(string nibName, NSBundle bundle) : base(nibName, bundle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<HomeView, Core.ViewModels.HomeViewModel>();
            var frame = new CGRect(0, AppDelegate.kNavigationBarOffset, DeviceDisplay.MainDisplayInfo.Width, (DeviceDisplay.MainDisplayInfo.Height * AppDelegate.kNavigationBarOffset) / ((DeviceDisplay.MainDisplayInfo.Height * AppDelegate.kNavigationBarOffset) / 800));

            UIActivityIndicatorView loadingIndicatorView = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);

            var tableList = new UITableView(frame);
            var source = new TableSource(tableList);

            this.AddBindings(new Dictionary<object, string>
            {
                {source, "ItemsSource ComicsCollection"}
            });

            tableList.Source = source;
            tableList.ReloadData();
            View.Add(tableList);

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


        public class TableSource : MvxStandardTableViewSource
        {
            private static readonly NSString ComicCellIdentifier = new NSString("ComicCell");

            public TableSource(UITableView tableView)
                : base(tableView)
            {
                tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
                tableView.RegisterNibForCellReuse(UINib.FromName("ComicCell", NSBundle.MainBundle),
                                                  ComicCellIdentifier);
            }

            protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath,
                                                                  object item)
            {
                NSString cellIdentifier;
                Comic comic = null;
                if (item is Comic)
                {
                    cellIdentifier = ComicCellIdentifier;
                    comic = (Comic)item;
                }
                else
                {
                    throw new ArgumentException("Unknown object of type " + item.GetType().Name);
                }

                UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
                cell.TextLabel.Text = comic.title;

                return cell;
            }
        }
    }



}


