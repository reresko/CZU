using Minesweeper.Model;
using Minesweeper.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Minesweeper.ViewModel
{
    public class MainWindowViewModel
    {
        public ICommand BeginnerCommand { get; }
        public ICommand IntermediateCommand { get; }
        public ICommand ExpertCommand { get; }

        public MainWindowViewModel()
        {
            BeginnerCommand = new RelayCommand(OnBeginnerClicked);
            IntermediateCommand = new RelayCommand(OnIntermediateClicked);
            ExpertCommand = new RelayCommand(OnExpertClicked);
        }

        private void OnBeginnerClicked()
        {
            var beginnerBoard = new GameBoard(10, 10, 10);
            var gameWindow = new GameWindow
            {
                DataContext = new GameWindowViewModel(beginnerBoard)
            };
            gameWindow.Show();
        }

        private void OnIntermediateClicked()
        {
            var gameWindow = new GameWindow();
            gameWindow.Show();
        }

        private void OnExpertClicked()
        {
            var gameWindow = new GameWindow();
            gameWindow.Show();
        }
    }
}
