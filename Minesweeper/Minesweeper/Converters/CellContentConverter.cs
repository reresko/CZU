using Minesweeper.Model;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Minesweeper.Converters
{
    public class CellContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Cell cell)
            {
                if (cell.IsFlagged)
                    return "🚩"; // Flag icon
                if (!cell.IsRevealed)
                    return ""; // Covered cell
                if (cell.IsMine)
                    return "💣"; // Mine icon
                if (cell.AdjacentMines > 0)
                    return cell.AdjacentMines.ToString(); // Number of adjacent mines
                return ""; // Blank revealed cell
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
