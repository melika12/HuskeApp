using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HuskeApp.Views;

namespace HuskeApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new login();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
