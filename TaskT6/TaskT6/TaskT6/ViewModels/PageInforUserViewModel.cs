using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Refit;
using Xamarin.Forms;

namespace TaskT6.ViewModels
{
    public class PageInforUserViewModel : BindableBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
       
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
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

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public DelegateCommand Btnback => _btnback ?? (_btnback = new DelegateCommand(ActionBack));

        private void ActionBack()
        {
            _navigationService.NavigateAsync("PageMaster", useModalNavigation: true);
        }

        INavigationService _navigationService;
        private DelegateCommand _btnback;
       
        public PageInforUserViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
               GetUserApiAsync();

        }
        public async void GetUserApiAsync()
        {
          
          
            var apiResponse = RestService.For<IGetDataApi>("https://jsonplaceholder.typicode.com");
            var apiuser = await apiResponse.GetUserEmail(UserInfo.Email);
            var usertemp = apiuser[0].Username;
            var nametemp = apiuser[0].Name;
            var id = apiuser[0].Id;
            string userid = ""+id;
            Phone = apiuser[0].Phone;
            Website = apiuser[0].Website;
            Username = usertemp;
            Name = nametemp;
            Email = apiuser[0].Email;
            Password = UserInfo.Pass;
          

        }
    }
}
