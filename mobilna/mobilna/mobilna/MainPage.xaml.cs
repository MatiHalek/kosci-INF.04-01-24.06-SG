using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobilna
{
    public partial class MainPage : ContentPage
    {
        int totalScore = 0;
        List<Image> diceImages; 
        public MainPage()
        {
            InitializeComponent();
            diceImages = new List<Image> { dice1Image, dice2Image, dice3Image, dice4Image, dice5Image };
        }

        void DiceButton_Clicked(System.Object sender, System.EventArgs e)
        {
            int[] rollResults = new int[5];
            Random randomNumberGenerator = new Random();
            for(int i = 0; i < rollResults.Length; i++)
            {
                rollResults[i] = randomNumberGenerator.Next(1, 7);
                diceImages[i].Source = ImageSource.FromFile("k6_" + rollResults[i] + ".png");
            }
            int roundScore = 0;
            for(int dots = 1; dots <= 6; dots++)
            {
                int count = 0;
                for(int diceIndex = 0; diceIndex < rollResults.Length; diceIndex++)
                {
                    if (rollResults[diceIndex] == dots)
                    {
                        count++;
                    }
                }
                if(count > 1)
                {
                    roundScore += count * dots;
                }

            }
            totalScore += roundScore;
            roundScoreLabel.Text = "Wynik tego losowania: " + roundScore;
            totalScoreLabel.Text = "Wynik gry: " + totalScore;
        }

        void ResetButton_Clicked(System.Object sender, System.EventArgs e)
        {
            foreach (Image diceImage in diceImages)
            {
                diceImage.Source = ImageSource.FromFile("k6_0.png");
            }              
            totalScore = 0;
            roundScoreLabel.Text = "Wynik tego losowania: 0";
            totalScoreLabel.Text = "Wynik gry: 0";
        }
    }
}

