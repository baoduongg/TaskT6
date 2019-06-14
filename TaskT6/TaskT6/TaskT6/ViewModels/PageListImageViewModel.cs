using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace TaskT6.ViewModels
{
   public class PageListImageViewModel: BindableBase
    {
        private ObservableCollection<Photo> _photolist;

        public ObservableCollection<Photo> Photolist
        {
            get { return _photolist; }
            set { SetProperty(ref _photolist, value); }
        }
     
     
        private INavigationService _navigationService;
        


        public PageListImageViewModel(INavigationService navigationService)
        {
           
            _navigationService = navigationService;
            GetDataAsync();
        }

        private Photo _selectedPhoto { get; set; }
        public Photo SelectedPhoto
        {
            get { return _selectedPhoto; }
            set
            {
                if (_selectedPhoto != value)
                {
                    _selectedPhoto = value;
                    HandleSelectedItem();
                }
            }
        }

    

        private void HandleSelectedItem()
        {

            var naviparams = new NavigationParameters
            {
                { "selectedphoto", SelectedPhoto }
            };
            _navigationService.NavigateAsync("PageAbout", naviparams);
           
        }

        private async void GetDataAsync()
        {
       
                var apiResponse = RestService.For<IGetDataApi>("https://jsonplaceholder.typicode.com");
                var imageslist = await apiResponse.GetImages(UserInfo.Userid);
                Photolist = imageslist;
           
        }
     

       
    }
}
