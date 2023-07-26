using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Content;
using Android.Views;
using Android.Widget;
using MvvmDemo.Android;
using MvvmDemo.Android.Helpers;
using MvvmDemo.Core.Models;

namespace MvvmDemo.Core.ViewModels
{

    public class ComicAdapter : BaseAdapter<Comic>
    {
        public List<Comic> sList;
        private Context sContext;
        public ComicAdapter(Context context, List<Comic> list)
        {
            sList = list;
            sContext = context;
        }
        public override Comic this[int position]
        {
            get
            {
                return sList[position];
            }
        }
        public override int Count
        {
            get
            {
                return sList.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            try
            {
                if (row == null)
                {
                    row = LayoutInflater.From(sContext).Inflate(Resource.Layout.ListItem, null, false);
                }
                TextView txtName = row.FindViewById<TextView>(Resource.Id.item_comic_name);
                txtName.Text = sList[position].title;

                TextView txtInfo = row.FindViewById<TextView>(Resource.Id.item_comic_info);
                txtInfo.Text = (sList[position].description==""?"Description unavaliable": sList[position].description);

                ImageView imgView = row.FindViewById<ImageView>(Resource.Id.item_comic_img);
                string url = sList[position].thumbnail.path + "." + sList[position].thumbnail.extension;
                imgView.SetImageBitmap(Helper.GetImageBitmapFromUrl(url));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally {
            }
            return row;
        }

    }

}
