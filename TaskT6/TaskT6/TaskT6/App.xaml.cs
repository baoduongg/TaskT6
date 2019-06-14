using Prism;
using Prism.Ioc;
using TaskT6.ViewModels;
using TaskT6.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Diagnostics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TaskT6
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("PageLogin");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PageMaster,PageMasterViewModel>();
           
            containerRegistry.RegisterForNavigation<PageLogin, PageLoginViewModel>();
        
            containerRegistry.RegisterForNavigation<PageListImage, PageListImageViewModel>();
            containerRegistry.RegisterForNavigation<PageAbout,PageAboutViewModel>();
            containerRegistry.RegisterForNavigation<PageInforUser,PageInforUserViewModel>();
            containerRegistry.RegisterForNavigation<PageUser2,PageUser2ViewModel>();
            containerRegistry.RegisterForNavigation<PageInforAvatar,PageInforAvatarViewModel>();
           
        }
       

    }
}
