using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppKfact_v2.Paginas;
using Xamarin.Forms;

namespace AppKfact_v2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new VentasPg());
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
