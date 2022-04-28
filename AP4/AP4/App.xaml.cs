using AP4.Vues;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PageMapsEnchereVue();
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
