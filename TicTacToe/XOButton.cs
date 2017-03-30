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
            set { Nought = value; }
        }
    }
}
