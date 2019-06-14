using Prism.Mvvm;
using Prism.Navigation;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace TaskT6.ViewModels
{
    public class PageUser2ViewModel : BindableBase
    {
        INavigationService _navigationService;
        private ObservableCollection<Photo> _photolist;
     
        public ObservableCollection<Photo> Photolist
        {
            get { return _photolist; }
            set { SetProperty(ref _photolist, value); }
        }
        private ObservableCollection<User> _namelist;
        public ObservableCollection<User> Namelist
        {
            get { return _namelist; }
            set { SetProperty(ref _namelist, value); }
        }
        private List<string> _listuser;
        public List<string> Listuser
        {
            get { return _listuser; }
            set { SetProperty(ref _listuser, value); }
        }

        private User usertemp;

        private string _countimg;
        public string Countimg
        {
            get { return _countimg; }
            set { SetProperty(ref _countimg, value); }
        }
        private string _username;
        private string _uriavatar;


        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }
        private string _website;
        public string Website
        {
            get { return _website; }
            set { SetProperty(ref _website, value); }
        }
        public string Uriimage
        {
            get { return _uriavatar; }
            set { SetProperty(ref _uriavatar, value); }
        }

        public User Usertemp { get => usertemp; set => usertemp = value; }
        private User _selectavatar { get; set; }
        public User SelectedAvatar
        {
            get { return _selectavatar; }
            set
            {
                if (_selectavatar != value)
                {
                    _selectavatar = value;
                    HandleSelectedItem();
                }
            }
        }

        private void HandleSelectedItem()
        {
            var naviparams = new NavigationParameters
            {
                { "Selectedavatar", SelectedAvatar }
            };
            _navigationService.NavigateAsync("PageInforAvatar", naviparams);
        }

        public PageUser2ViewModel(INavigationService navigationService)
        {
            _navigationService= navigationService;
            GetUserApiAsync();
            GetnamelistAsync();
      


        }
      
        public async void GetnamelistAsync()
        {
            var apiResponse = RestService.For<IGetDataApi>("https://jsonplaceholder.typicode.com");
            var apiuser = await apiResponse.GetUserName();
            for (int i = 0; i <= 9; i++)
            {
                apiuser[i].Avatar = $"iconhuman{i}";
              
            }
            for (int i = 0; i < apiuser.Count; i++)
            {
                if(apiuser[i].Email==UserInfo.Email)
                {
                    apiuser.Remove(apiuser[i]);
                }
            }
            Namelist = apiuser;
           
        }

        public async void GetUserApiAsync()
        {

            var apiResponse = RestService.For<IGetDataApi>("https://jsonplaceholder.typicode.com");
            var apiuser = await apiResponse.GetUserEmail(UserInfo.Email);
            var usertemp = apiuser[0].Username;
            var id = apiuser[0].Id;
            Username = usertemp;
            UserInfo.Userid = "" + id;
            UserInfo.Name = Username;
            Phone = apiuser[0].Phone;
            Website = apiuser[0].Website;
            Email = UserInfo.Email;
            Username = UserInfo.Name;
            Uriimage = "iconlogin.jpg";
           
            GetDataAsync();

        }



        private async void GetDataAsync()
        {
           
            var apiResponse = RestService.For<IGetDataApi>("https://jsonplaceholder.typicode.com");
            var imageslist = await apiResponse.GetImages(UserInfo.Userid);
            Photolist = imageslist;
            Countimg = Photolist.Count.ToString();
        }



    }
}
