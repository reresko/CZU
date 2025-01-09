using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{

    internal class CustomButton : Button
    {
        public bool CustomEnabled = true;
        public bool IsFlag = false;
        public bool IsMine = false;
        public CustomButton() : base() { }
    }
}
