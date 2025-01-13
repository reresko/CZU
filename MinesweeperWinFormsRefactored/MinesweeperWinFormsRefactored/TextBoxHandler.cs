using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace MinesweeperWinFormsRefactored
{
    /// <summary>
    /// Provides utility methods for managing the value of a <see cref="TextBox"/> control.
    /// </summary>
    internal class TextBoxHandler
    {
        private TextBox _textBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxHandler"/> class.
        /// </summary>
        /// <param name="textBox">The <see cref="TextBox"/> to manage.</param>
        public TextBoxHandler(TextBox textBox)
        {
            _textBox = textBox;
        }

        /// <summary>
        /// Sets the numeric value of the associated <see cref="TextBox"/>.
        /// </summary>
        /// <param name="value">The integer value to set in the text box.</param>
        public void SetValue(int value)
        {
            _textBox.Text = value.ToString();
        }

        /// <summary>
        /// Gets the numeric value from the associated <see cref="TextBox"/>.
        /// </summary>
        /// <returns>
        /// The integer value parsed from the text box. Returns 0 if the text cannot be parsed as an integer.
        /// </returns>
        public int GetValue()
        {
            //try to parse the text from textbox into an integer
            if (int.TryParse(_textBox.Text, out int result))
            {
                return result;
            }
            //if parsing fails, return 0 as the default value
            return 0;
        }

        /// <summary>
        /// Resets the <see cref="TextBox"/> by printing 0
        /// </summary>
        public void ResetValue()
        {
            _textBox.Text = "0";
        }
    }
}
