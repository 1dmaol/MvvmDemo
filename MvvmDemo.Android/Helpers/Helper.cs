using System;
using Android.Graphics;
using System.Net;
using Java.IO;
using static Android.Webkit.WebStorage;
using System.IO;

namespace MvvmDemo.Android.Helpers
{
	public class Helper
	{

        public static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

    }
}

