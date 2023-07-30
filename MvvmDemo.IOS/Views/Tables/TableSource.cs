using System;
using System.Threading;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmDemo.Core.Models;
using MvvmDemo.IOS.Helpers;
using UIKit;
using Xamarin.Essentials;

namespace MvvmDemo.IOS.Views.Tables
{
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
            NSString cellIdentifier = null;
            Comic comic = null;

            if (item is Comic)
            {
                cellIdentifier = ComicCellIdentifier;
                comic = (Comic)item;
            }
            UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

            var comicImageView = new UIImageView();
            var imageData = IOSHelper.DownloadImageFromUrl(comic.thumbnailUrl).AsJPEG(0.0f);
            comicImageView.Image = UIImage.LoadFromData(imageData);
            comicImageView.Frame = new CoreGraphics.CGRect(5, 5, 90, 90);
            comicImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            cell.Add(comicImageView);

            var nameLabel = new UILabel();
            nameLabel.Text = comic.title;
            nameLabel.Font = UIFont.BoldSystemFontOfSize(16);
            nameLabel.Frame = new CoreGraphics.CGRect(105, -15, IOSHelper.TransformCoordinates(DeviceDisplay.MainDisplayInfo.Width, 300, 100), 90);
            cell.Add(nameLabel);

            var descriptionLabel = new UILabel();
            descriptionLabel.Text = comic.description;
            descriptionLabel.Frame = new CoreGraphics.CGRect(105, 5, IOSHelper.TransformCoordinates(DeviceDisplay.MainDisplayInfo.Width, 300, 100), 90);
            cell.Add(descriptionLabel);

            nameLabel.LeftAnchor.ConstraintEqualTo(cell.LeftAnchor, 0.0f).Active = true;
            nameLabel.RightAnchor.ConstraintEqualTo(cell.RightAnchor, 0.0f).Active = true;
            descriptionLabel.LeftAnchor.ConstraintEqualTo(cell.LeftAnchor, 0.0f).Active = true;
            descriptionLabel.RightAnchor.ConstraintEqualTo(cell.RightAnchor, 0.0f).Active = true;
            comicImageView.LeftAnchor.ConstraintEqualTo(cell.LeftAnchor, 0.0f).Active = true;
            comicImageView.RightAnchor.ConstraintEqualTo(cell.RightAnchor, 0.0f).Active = true;

            return cell;
        }

    }
}

