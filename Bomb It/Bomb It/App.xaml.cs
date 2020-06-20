using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bomb_It
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Bomb_It.MainPage();
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
