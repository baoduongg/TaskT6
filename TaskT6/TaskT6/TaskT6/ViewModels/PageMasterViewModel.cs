using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskT6.ViewModels
{
   public class PageMasterViewModel : BindableBase
    {
        INavigationService _navigationService;
        private DelegateCommand _btninfor;
        private DelegateCommand _btnlistimg;
        private DelegateCommand _btnlogout;
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public PageMasterViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Email = UserInfo.Email;
        }

        public DelegateCommand Btninfor => _btninfor ?? (_btninfor = new DelegateCommand(MovePageInfor));

        public DelegateCommand Btnlistimg => _btnlistimg ?? (_btnlistimg = new DelegateCommand(MovePageListImg));

        public DelegateCommand Btnlogout => _btnlogout ?? (_btnlogout = new DelegateCommand(BtnLogout));

        private void BtnLogout()
        {
            _navigationService.NavigateAsync("PageLogin",useModalNavigation:true);
        }

        private void MovePageListImg()
        {
            _navigationService.NavigateAsync("PageListImage");
        }

        private void MovePageInfor()
        {
            _navigationService.NavigateAsync("PageInforUser");
        }
    }
}
