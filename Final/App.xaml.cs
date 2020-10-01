using Final.Models;
using Final.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Final
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public Contents contexto;
        public App()
        {
            InitializeComponent();

            contexto = new Contents();

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new Login());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
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
