using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// TODO: organise code to be more modular, add a retry button, 
    /// change background colour of winning row, make the AI better.
    public partial class MainWindow : Window
    {
        List<XOButton> tiles = new List<XOButton>();
        List<XOButton> crosses = new List<XOButton>();
        List<XOButton> noughts = new List<XOButton>();      
        
        int x = 0;
        int o = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            tiles.Add(topLeft);
            tiles.Add(topMiddle);
            tiles.Add(topRight);
            tiles.Add(middleLeft);
            tiles.Add(centre);
            tiles.Add(middleRight);
            tiles.Add(bottomLeft);
            tiles.Add(bottomMiddle);
            tiles.Add(bottomRight);
        }

        public void BtnClick(XOButton btn)
        {
            Image imgX = new Image();
            imgX.Source = new BitmapImage(new Uri("C://Users/Jason/Documents/Games/TicTacToe/TicTacToe/TicTacToeX.png"));
            btn.Content = imgX;
            btn.IsEnabled = false;
            btn.Cross = true;
            bool cont = true;
            crosses.Add(btn);
            tiles.Remove(btn);
            x++;
            int btnsRemaining = 0;
            foreach (XOButton item in tiles)
            {
                btnsRemaining++;
            }
            myTxt.Text = btnsRemaining.ToString();
            if (x >= 3)
            {
                cont = winCondition(crosses, btn, btnsRemaining);
            }
            
            if (cont)
            {
                playerAI();
            }
        }

        public void playerAI()
        {
            Random rnd = new Random();
            int btnsRemaining = 0;
            foreach (XOButton item in tiles)
            {
                btnsRemaining++;
            }
            int buttonIndex = rnd.Next(btnsRemaining);
            Image imgO = new Image();
            imgO.Source = new BitmapImage(new Uri("C://Users/Jason/Documents/Games/TicTacToe/TicTacToe/TicTacToeO.png"));
            tiles[buttonIndex].Content = imgO;
            tiles[buttonIndex].IsEnabled = false;
            tiles[buttonIndex].Nought = true;
            noughts.Add(tiles[buttonIndex]);
            o++;
            myTxt.Text = btnsRemaining.ToString();
            if (o >= 3)
            {
                winCondition(noughts, tiles[buttonIndex], btnsRemaining);
            }
            tiles.Remove(tiles[buttonIndex]);
        }



        public bool winCondition(List<XOButton> btnList, XOButton btn, int btnsRemaining)
        {
            bool winner = false;

            if ( btnList.Contains(topLeft) && btnList.Contains(topMiddle) && btnList.Contains(topRight))
            {
                winner = true; 
            }
            else if ( btnList.Contains(middleLeft) && btnList.Contains(centre) && btnList.Contains(middleRight))
            {
                winner = true;
            }
            else if (btnList.Contains(bottomLeft) && btnList.Contains(bottomMiddle) && btnList.Contains(bottomRight))
            {
                winner = true;
            }
            else if (btnList.Contains(topLeft) && btnList.Contains(middleLeft) && btnList.Contains(bottomLeft))
            {
                winner = true;
            }
            else if (btnList.Contains(topMiddle) && btnList.Contains(centre) && btnList.Contains(bottomMiddle))
            {
                winner = true;
            }
            else if (btnList.Contains(topRight) && btnList.Contains(middleRight) && btnList.Contains(bottomRight))
            {
                winner = true;
            }
            else if (btnList.Contains(topLeft) && btnList.Contains(centre) && btnList.Contains(bottomRight))
            {
                winner = true;
            }
            else if (btnList.Contains(topRight) && btnList.Contains(centre) && btnList.Contains(bottomLeft))
            {
                winner = true;
            }
            if (winner)
            {
                if (btn.Cross)
                {
                    foreach (XOButton item in tiles)
                    {
                        item.IsEnabled = false;
                    }
                    myTxt.Text = "Congratulation! You are the Winner!";
                    return false;
                }
                else if (btn.Nought)
                {
                    foreach (XOButton item in tiles)
                    {
                        item.IsEnabled = false;
                    }
                    myTxt.Text = "Ooooo, you lose!";
                    return false;
                }
            }
            else if ((btn.Cross && btnsRemaining == 0) || (btn.Nought && btnsRemaining == 1))
            {
                myTxt.Text = "Meh, draw.";
                return false;
            }
            return true;
        }

        private void topLeft_Click(object sender, RoutedEventArgs e)
        {
            XOButton topLeft = (XOButton)sender;
            BtnClick(topLeft);
        }

        private void topMiddle_Click(object sender, RoutedEventArgs e)
        {
            XOButton topMiddle = (XOButton)sender;
            BtnClick(topMiddle);
        }

        private void topRight_Click(object sender, RoutedEventArgs e)
        {
            XOButton topRight = (XOButton)sender;
            BtnClick(topRight);
        }

        private void middleLeft_Click(object sender, RoutedEventArgs e)
        {
            XOButton middleLeft = (XOButton)sender;
            BtnClick(middleLeft);
        }

        private void centre_Click(object sender, RoutedEventArgs e)
        {
            XOButton centre = (XOButton)sender;
            BtnClick(centre);
        }

        private void middleRight_Click(object sender, RoutedEventArgs e)
        {
            XOButton middleRight = (XOButton)sender;
            BtnClick(middleRight);
        }

        private void bottomLeft_Click(object sender, RoutedEventArgs e)
        {
            XOButton bottomLeft = (XOButton)sender;
            BtnClick(bottomLeft);
        }

        private void bottomMiddle_Click(object sender, RoutedEventArgs e)
        {
            XOButton bottomMiddle = (XOButton)sender;
            BtnClick(bottomMiddle);
        }

        private void bottomRight_Click(object sender, RoutedEventArgs e)
        {
            XOButton bottomRight = (XOButton)sender;
            BtnClick(bottomRight);
        }
    }
}
