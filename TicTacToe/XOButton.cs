using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class XOButton : Button
    {
        private bool cross = false;
        public bool Cross
        {
            get { return cross; }
            set { cross = value; }
        }
        private bool nought = false;
        public bool Nought
        {
            get { return nought; }
            set { nought = value; }
        }
        private bool topScore = false;
        public bool TopScore
        {
            get { return topScore; }
            set { topScore = value; }
        }
        private int score = 0;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
