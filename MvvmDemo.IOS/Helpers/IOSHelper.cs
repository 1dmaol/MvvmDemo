﻿using System;
using Foundation;
using UIKit;
using Xamarin.Essentials;

namespace MvvmDemo.IOS.Helpers
{
	public class IOSHelper
	{
        public static UIImage DownloadImageFromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }

        public static double TransformCoordinates(double baseValue, double supposedValue, double offset)
        {
            return (baseValue * offset) / ((baseValue * offset) / supposedValue);
        }
    }
}

