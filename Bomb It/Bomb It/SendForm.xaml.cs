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
    public partial class SendForm : ContentPage
    {
        private int Score;
        public SendForm(string score)
        {
            InitializeComponent();
            Score = Int32.Parse(score);
        }

    }

}