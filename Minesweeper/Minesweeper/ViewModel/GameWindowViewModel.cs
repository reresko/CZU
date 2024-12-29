using Minesweeper.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Minesweeper.ViewModel
{
    internal class GameWindowViewModel
    {
        public GameBoard GameBoard { get; }
        public ObservableCollection<Cell> Cells { get; }

        public ICommand RevealCellCommand { get; }
        public ICommand ToggleFlagCommand { get; }

        public GameWindowViewModel(GameBoard gameBoard)
        {
            GameBoard = gameBoard;

            // Flatten the 2D grid into a single collection for binding
            Cells = new ObservableCollection<Cell>(
                GameBoard.Cells.Cast<Cell>());

            // Initialize commands
            RevealCellCommand = new RelayCommand<Cell>(RevealCell);
            ToggleFlagCommand = new RelayCommand<Cell>(ToggleFlag);
        }

        private void RevealCell(Cell cell)
        {
            // Ensure the cell isn't already revealed or flagged
            if (cell.IsRevealed || cell.IsFlagged)
                return;

            // Reveal the cell using the GameBoard logic
            GameBoard.RevealCell(cell.Row, cell.Column);

            // Refresh the UI by raising property changes on cells (if needed)
            UpdateCellBindings();
        }

        private void ToggleFlag(Cell cell)
        {
            // Only allow toggling if the cell isn't revealed
            if (!cell.IsRevealed)
            {
                GameBoard.ToggleFlag(cell.Row, cell.Column);

                // Refresh the UI by raising property changes on cells (if needed)
                UpdateCellBindings();
            }
        }

        private void UpdateCellBindings()
        {
            // If using INotifyPropertyChanged in `Cell`, this ensures UI updates
            foreach (var cell in Cells)
            {
                // Trigger UI refresh by notifying of property changes
                // For example:
                // RaisePropertyChanged(nameof(cell.IsRevealed));
            }
        }
    }
}
