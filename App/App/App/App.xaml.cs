using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.ViewModels;
using App.View;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Lands = new NombresViewModel();

            this.MainPage = new NavigationPage(new NombresPage());
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
