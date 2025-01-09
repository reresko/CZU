using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    internal class TextBoxHandler
    {
        private TextBox _textBox;

        public TextBoxHandler(TextBox textBox)
        {
            _textBox = textBox;
        }

        public void SetValue(int value)
        {
            _textBox.Text = value.ToString();
        }

        public int GetValue()
        {
            if (int.TryParse(_textBox.Text, out int result))
            {
                return result;
            }
            return 0;
        }
    }
}
