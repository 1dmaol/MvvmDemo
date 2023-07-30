﻿using FFImageLoading.Work;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmDemo.Core.Models;
using MvvmDemo.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MvvmDemo.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private string _title = "Marvel Comics";

        public string Title
        {
            
            get { return _title; }
            set { _title = value; RaisePropertyChanged(() => Title); }
        }

        private bool _isLoading = false;

        public bool IsLoading
        {

            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
        }

        private Comic selectedItem;
        public virtual Comic SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        private ObservableCollection<Comic> _comicsCollection;
        public ObservableCollection<Comic> ComicsCollection
        {
            get { return _comicsCollection; }
            set { _comicsCollection = value; RaisePropertyChanged(() => ComicsCollection); }
        }

        public IMvxCommand ItemClickCommand { get; }

        public HomeViewModel()
        {
            LoadData();
        }

        public async void LoadData()
        {
            IsLoading = true;
            IComicService comicService = new ComicService();
            ComicsCollection = new ObservableCollection<Comic>(await comicService.GetComics());
            IsLoading = false;
        }

    }
}
