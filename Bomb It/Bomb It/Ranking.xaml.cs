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
    public partial class Ranking : ContentPage
    {
        public Ranking(dynamic data)
        {
            InitializeComponent();
            nick1.Text = data[0];
            country1.Text = data[1];
            score1.Text = data[2];

            nick2.Text = data[3];
            country2.Text = data[4];
            score2.Text = data[5];

            nick3.Text = data[6];
            country3.Text = data[7];
            score3.Text = data[8];

            nick4.Text = data[9];
            country4.Text = data[10];
            score4.Text = data[11];

            nick5.Text = data[12];
            country5.Text = data[13];
            score5.Text = data[14];

            nick6.Text = data[15];
            country6.Text = data[16];
            score6.Text = data[17];

            nick7.Text = data[18];
            country7.Text = data[19];
            score7.Text = data[20];

            nick8.Text = data[21];
            country8.Text = data[22];
            score8.Text = data[23];

            nick9.Text = data[24];
            country9.Text = data[25];
            score9.Text = data[26];

            nick10.Text = data[27];
            country10.Text = data[28];
            score10.Text = data[29];
            
        }

    }
}
