using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    /// <summary>
    /// Custom button inherited from initial <see cref="Button"/> class extended by boolean variables.
    /// </summary>
    internal class CustomButton : Button
    {
        public bool CustomEnabled = true;
        public bool IsFlag = false;
        public bool IsMine = false;
        public CustomButton() : base() { }
    }
}
