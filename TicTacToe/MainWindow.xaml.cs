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
        bool cont = true;
        
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
            crosses.Add(btn);
            tiles.Remove(btn);
            x++;
            int btnsRemaining = 0;
            foreach (XOButton item in tiles)
            {
                btnsRemaining++;
            }
            //myTxt.Text = btnsRemaining.ToString();
            if (x >= 3)
            {
                cont = winCondition(crosses, btn, btnsRemaining);
            }        
            if (!cont || btnsRemaining == 0)
            {
                gameResult(btn, btnsRemaining, !cont);
            }
            else
            {
                minmaxAlgorithm();
            }
        }

        //public void playerAI()
        //{
        //    //Random rnd = new Random();
        //    //int buttonIndex = rnd.Next(btnsRemaining);
        //    //Image imgO = new Image();
        //    //imgO.Source = new BitmapImage(new Uri("C://Users/Jason/Documents/Games/TicTacToe/TicTacToe/TicTacToeO.png"));
        //    //tiles[buttonIndex].Content = imgO;
        //    //tiles[buttonIndex].IsEnabled = false;
        //    //tiles[buttonIndex].Nought = true;
        //    //noughts.Add(tiles[buttonIndex]);
        //    //o++;
        //    //myTxt.Text = btnsRemaining.ToString();
        //    //if (o >= 3)
        //    //{
        //    //    cont = winCondition(noughts, tiles[buttonIndex], btnsRemaining);
        //    //    if (!cont)
        //    //    {
        //    //        gameResult(tiles[buttonIndex], btnsRemaining, !cont);
        //    //    }
        //    //}
        //    //tiles.Remove(tiles[buttonIndex]);
        //}

        public bool winCondition(List<XOButton> btnList, XOButton btn, int btnsRemaining)
        {
            if (btnList.Contains(topLeft) && btnList.Contains(topMiddle) && btnList.Contains(topRight))
            {
                return false;
            }
            else if (btnList.Contains(middleLeft) && btnList.Contains(centre) && btnList.Contains(middleRight))
            {
                return false;
            }
            else if (btnList.Contains(bottomLeft) && btnList.Contains(bottomMiddle) && btnList.Contains(bottomRight))
            {
                return false;
            }
            else if (btnList.Contains(topLeft) && btnList.Contains(middleLeft) && btnList.Contains(bottomLeft))
            {
                return false;
            }
            else if (btnList.Contains(topMiddle) && btnList.Contains(centre) && btnList.Contains(bottomMiddle))
            {
                return false;
            }
            else if (btnList.Contains(topRight) && btnList.Contains(middleRight) && btnList.Contains(bottomRight))
            {
                return false;
            }
            else if (btnList.Contains(topLeft) && btnList.Contains(centre) && btnList.Contains(bottomRight))
            {
                return false;
            }
            else if (btnList.Contains(topRight) && btnList.Contains(centre) && btnList.Contains(bottomLeft))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void gameResult(XOButton btn, int btnsRemaining, bool winner)
        {
        if (btn.Cross && winner)
            {
                foreach (XOButton item in tiles)
                {
                    item.IsEnabled = false;
                }
                myTxt.Text = "Congratulation! You are the Winner!";
            }
            else if (btn.Nought && winner)
            {
                foreach (XOButton item in tiles)
                {
                    item.IsEnabled = false;
                }
                myTxt.Text = "Ooooo, you lose!";
            }
            else if ((btn.Cross && btnsRemaining == 0 && !winner) || (btn.Nought && btnsRemaining == 1 && !winner))
            {
                myTxt.Text = "Meh, draw.";
            }
        }

        public void minmaxAlgorithm()
        {
            int btnsRemaining;
            string currentPlayer = "x";
            foreach (XOButton btn in tiles.ToList())
            {
                List<XOButton> mmTiles = tiles.ToList();
                List<XOButton> mmCrosses = crosses.ToList();
                List<XOButton> mmNoughts = noughts.ToList();
                mmTiles.Remove(btn);
                mmNoughts.Add(btn);
                int depth = 0;
                
                foreach (XOButton item in mmTiles.ToList())
                {
                    btnsRemaining = 0;
                    foreach (XOButton remaining in mmTiles.ToList())
                    {
                        btnsRemaining++;
                        myTxt.Text = btnsRemaining.ToString();
                    }
                    while (btnsRemaining >= 0)
                    {
                        if (currentPlayer == "o")
                        {
                            mmTiles.Remove(item);
                            mmNoughts.Add(item);
                            btnsRemaining--;
                            depth++;
                            if (!winCondition(mmNoughts, item, btnsRemaining))
                            {
                                btn.Score = 10 - depth;
                                break;
                            }
                            else
                            {
                                currentPlayer = "x";
                            }
                        }
                        if (currentPlayer == "x")
                        {
                            mmTiles.Remove(item);
                            mmCrosses.Add(item);
                            btnsRemaining--;
                            if (!winCondition(mmCrosses, item, btnsRemaining))
                            {
                                btn.Score = -10 + depth;
                                break;
                            }
                            else
                            {
                                currentPlayer = "o";
                            }
                        }                    
                    }
                }
            }
            btnsRemaining = 0;
            foreach (XOButton item in tiles)
            {
                btnsRemaining++;
            }
            tiles[0].TopScore = true;
            XOButton optimum = tiles[0];
            foreach (XOButton item in tiles)
            {
                if (item.Score > optimum.Score)
                {
                    foreach (XOButton btn in tiles)
                    {
                        btn.TopScore = false;
                    }
                    item.TopScore = true;
                    optimum = item;
                }
            }
            foreach (XOButton item in tiles.ToList())
            {
                if (item.TopScore)
                {
                    Image imgO = new Image();
                    imgO.Source = new BitmapImage(new Uri("C://Users/Jason/Documents/Games/TicTacToe/TicTacToe/TicTacToeO.png"));
                    item.Content = imgO;
                    item.IsEnabled = false;
                    item.Nought = true;
                    noughts.Add(item);
                    tiles.Remove(item);
                    cont = winCondition(noughts, item, btnsRemaining);
                    if (!cont)
                    {
                        gameResult(item, btnsRemaining, !cont);
                    }
                }
            }
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
