using MvvmCross.ViewModels;
using MvvmDemo.Core.Models;
using MvvmDemo.Core.Services;
using System;
using System.Collections.ObjectModel;

namespace MvvmDemo.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private string _title = "ComicsList";

        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(() => Title); }
        }

        private ObservableCollection<Comic> _comicsCollection;
        public ObservableCollection<Comic> ComicsCollection
        {
            get { return _comicsCollection; }
            set { _comicsCollection = value; RaisePropertyChanged(() => ComicsCollection); }
        }


        private ObservableCollection<string> _titlesCollection;
        public ObservableCollection<string> TitlesCollection
        {
            get { return _titlesCollection; }
            set { _titlesCollection = value; RaisePropertyChanged(() => TitlesCollection); }
        }

        public HomeViewModel()
        {
            LoadData();
        }

        public async void LoadData()
        {
            IComicService comicService = new ComicService();
            ComicsCollection = new ObservableCollection<Comic>(await comicService.GetComics());
        }
    }
}
