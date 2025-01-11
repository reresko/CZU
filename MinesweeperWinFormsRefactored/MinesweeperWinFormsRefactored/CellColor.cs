using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    /// <summary>
    /// Provides color-coding for mine counts displayed on the Minesweeper grid.
    /// </summary>
    internal class CellColor
    {
        /// <summary>
        /// Determines the color associated with a given mine count.
        /// </summary>
        /// <param name="count">The number of mines adjacent to a cell.</param>
        /// <returns>A <see cref="Color"/> representing the mine count.</returns>
        public Color GetMineCountColor(int count)
        {
            return count switch
            {
                1 => Color.Blue,
                2 => Color.Green,
                3 => Color.Red,
                4 => Color.DarkBlue,
                5 => Color.DarkRed,
                6 => Color.Cyan,
                7 => Color.Black,
                _ => Color.Gray,
            };
        }
    }
}
