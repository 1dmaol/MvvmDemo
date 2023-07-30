using System;
using MvvmDemo.Core.Models;
using MvvmDemo.IOS.Helpers;
using UIKit;
using Xamarin.Essentials;

namespace MvvmDemo.IOS.Views
{
	public partial class ComicView : UIViewController
	{
		private Comic comic;

        public override string Title { get => base.Title; set => base.Title = value; }

        public ComicView(Comic comic) : base ("ComicView", null)
		{
			this.comic = comic;
		}

        public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            var comicImageView = new UIImageView();
            var imageData = IOSHelper.DownloadImageFromUrl(comic.thumbnailUrl).AsJPEG(0.0f);
            comicImageView.Image = UIImage.LoadFromData(imageData);
            comicImageView.Frame = new CoreGraphics.CGRect(0, 100, IOSHelper.TransformCoordinates(DeviceDisplay.MainDisplayInfo.Width, 432, 100), IOSHelper.TransformCoordinates(DeviceDisplay.MainDisplayInfo.Height, 300, 100));
            comicImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            View.Add(comicImageView);

            var nameLabel = new UILabel();
            nameLabel.Text = comic.title;
            nameLabel.Frame = new CoreGraphics.CGRect(20, 115 + IOSHelper.TransformCoordinates(DeviceDisplay.MainDisplayInfo.Height, 300, 100), IOSHelper.TransformCoordinates(DeviceDisplay.MainDisplayInfo.Width, 382, 100), 25);
            nameLabel.Font = UIFont.BoldSystemFontOfSize(16);
            nameLabel.TextAlignment = UITextAlignment.Center;
            nameLabel.LineBreakMode = UILineBreakMode.WordWrap;
            nameLabel.Lines = 0;
            View.Add(nameLabel);

            var descriptionLabel = new UILabel();
            descriptionLabel.Text = comic.description;
            descriptionLabel.Frame = new CoreGraphics.CGRect(20, 100 + IOSHelper.TransformCoordinates(DeviceDisplay.MainDisplayInfo.Height, 300, 100) + 45, IOSHelper.TransformCoordinates(DeviceDisplay.MainDisplayInfo.Width, 382, 100), 200);
            descriptionLabel.TextAlignment = UITextAlignment.Center;
            descriptionLabel.LineBreakMode = UILineBreakMode.WordWrap;
            descriptionLabel.Lines = 0;
            View.Add(descriptionLabel);

        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


