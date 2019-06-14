using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskT6.ViewModels
{
    class PageInforAvatarViewModel : BindableBase, INavigationAware
    {
       
        private User _usertemp;
        public User Usertemp
        {
            get { return _usertemp; }
            set { SetProperty(ref _usertemp, value); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
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
        private string _avatar;
        public string Avatar
        {
            get { return _avatar; }
            set { SetProperty(ref _avatar, value); }
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

        public DelegateCommand Btnback => _btnback ?? (_btnback = new DelegateCommand(ActionBack));

        private void ActionBack()
        {
            _navigationService.GoBackAsync();
        }

        private DelegateCommand _btnback;
        INavigationService _navigationService;
        public PageInforAvatarViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;


        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
          
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Usertemp = parameters.GetValue<User>("Selectedavatar");
            Name = Usertemp.Name;
            Avatar = Usertemp.Avatar;
            Email = Usertemp.Email;
            Phone = Usertemp.Phone;
            Website = Usertemp.Website;
            Username = Usertemp.Username;
            
        }
    }
}
