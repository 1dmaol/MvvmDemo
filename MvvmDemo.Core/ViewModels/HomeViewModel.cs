using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmDemo.Core.Helpers;
using MvvmDemo.Core.Models;
using MvvmDemo.Core.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemo.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel, IMvxNotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public ComicService comicService;
        

        public HomeViewModel()
        {

        }
    }
}
