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
    public partial class GameOver : ContentPage
    {
        public GameOver(int score)
        {
            InitializeComponent();
            ScoreName.Text = score.ToString();
        }

        async void SaveClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SendForm(ScoreName.Text), false);
        }
    }

}