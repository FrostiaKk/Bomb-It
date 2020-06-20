using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Bomb_It
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        static string bomb = new Random().Next(1, 5).ToString();
        static int Scores = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text == bomb)
            {
                Vibration.Vibrate();
                await DisplayAlert("Bomba wybuchła", "Koniec gry", "Zagraj jeszcze raz");
                bomb = new Random().Next(1, 4).ToString();
            }
            else
            {
                Scores += 1;
                await DisplayAlert("Bomba rozbrojona", "Wynik: " + Scores, "Kontynuuj");
                bomb = new Random().Next(1, 4).ToString();
            }
        }
    }
}
