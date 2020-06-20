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
                await Navigation.PushAsync(new GameOver(Scores),false);
                //await DisplayAlert("Bomba wybuchła", "Koniec gry", "Zagraj jeszcze raz");
                Scores = 0;
                bomb = new Random().Next(1, 5).ToString();
            }
            else
            {
                Scores += 1;
                await DisplayAlert("Bomba rozbrojona", "Wynik: " + Scores, "Kontynuuj");
                bomb = new Random().Next(1, 5).ToString();
            }
        }

        
    }
}
