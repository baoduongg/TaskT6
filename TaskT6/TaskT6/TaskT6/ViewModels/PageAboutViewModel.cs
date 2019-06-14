using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TaskT6.ViewModels
{
    public class PageAboutViewModel : BindableBase, INavigationAware
    {
        private Photo _phototemp;
        public Photo Phototemp
        {
            get { return _phototemp; }
            set { SetProperty(ref _phototemp, value); }
        }
     

        private string _albumname;
        public string Albumname
        {
            get { return _albumname; }
            set { SetProperty(ref _albumname, value); }
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        INavigationService _navigationService;
        public DelegateCommand Btnback => _btnback ?? (_btnback = new DelegateCommand(ActionBack));

        private void ActionBack()
        {
            _navigationService.GoBackAsync();
        }

        private string _albumid;
        private DelegateCommand _btnback;
          
        public PageAboutViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;


        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Phototemp = parameters.GetValue<Photo>("selectedphoto");
            var titletemp = Phototemp.Title;
            var urltemp = Phototemp.Url;
            var albumidtemp = Phototemp.AlbumId;
            Title = titletemp;
            Url = urltemp;
           _albumid = ""+albumidtemp;
            GetAlbums();
             GetUserName();
           
        }
        private async void GetAlbums()
        {
            var apiResponse = RestService.For<IGetDataApi>("https://jsonplaceholder.typicode.com");
            var albumtemp = await apiResponse.GetAlbum(_albumid);
            Albumname = albumtemp[0].Title;
   
        }
        private async void GetUserName()
        {
            var apiResponse = RestService.For<IGetDataApi>("https://jsonplaceholder.typicode.com");
            var usertemp = await apiResponse.GetUser(_albumid);

            Username = usertemp[0].Username;
            Email = usertemp[0].Email;

        }
        
        
        
    }
}
