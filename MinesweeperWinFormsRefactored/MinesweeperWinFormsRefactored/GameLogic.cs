using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    internal class GameLogic
    {
        // kolik bude sloupcu (osa x) - ziskam kliknutim na tlacitko obtiznosti
        public int ColumnsCount { get; set; }
        // kolik bude radku (osa y) - ziskam kliknutim na tlacitko obtiznosti
        public int RowsCount { get; set; }
        // kolik bude min - ziskam kliknutim na tlacitko obtiznosti
        public int MinesCount { get; set; }
        // pozice jednotlivych bunek
        public int[,] Positions { get; set; }
        public int TotalCells => RowsCount * ColumnsCount;
        public int RevealedCellsCount { get; set; } = 0;

        Random random = new Random();

        public void ResetRevealedCellsCount()
        {
            RevealedCellsCount = 0;
        }

        // zavolá se při každém spuštění hry
        public void InitializeBoardDimensions()
        {
            if (ColumnsCount <= 0 || RowsCount <= 0)
                throw new InvalidOperationException("Rozměry hrací desky musí být větší než 0!");

            Positions = new int[ColumnsCount, RowsCount];
        }

        public void GenerateBombs()
        {
            if (Positions == null)
                throw new InvalidOperationException("Hrací plocha nebyla inicializována!");

            int bombs = 0;

            while (bombs < MinesCount)
            {
                int x = random.Next(0, ColumnsCount);
                int y = random.Next(0, RowsCount);

                // kdyz v bunce neni mina
                if (Positions[x, y] == 0)
                {
                    // 10 znamená mina
                    Positions[x, y] = 10;
                    bombs++;
                }
            }
        }

        public void CalculateAdjacentMines()
        {
            for (int y = 0; y < RowsCount; y++)
            {
                for (int x = 0; x < ColumnsCount; x++)
                {
                    byte bombCount = 0;

                    //2 for loopy pocitajici kolik bomb je na kazdem sousedovi
                    for (int counterX = -1; counterX <= 1; counterX++)
                    {
                        for (int counterY = -1; counterY <= 1; ++counterY)
                        {
                            if (counterX == 0 && counterY == 0)
                                continue;

                            int neighborX = x + counterX;
                            int neighborY = y + counterY;

                            if (neighborX >= 0 && neighborX < ColumnsCount && neighborY >= 0 && neighborY < RowsCount)
                            {
                                if (Positions[neighborX, neighborY] == 10)
                                    bombCount++;
                            }
                        }
                    }

                    if (Positions[x, y] != 10)
                    {
                        Positions[x, y] = bombCount;
                    }
                }
            }
        }
        public void IncrementRevealedCells()
        {
            RevealedCellsCount++;
        }

        public bool CheckWin()
        {
            // Výhra nastane, pokud jsou odhaleny všechny buňky kromě těch s minami
            return RevealedCellsCount == TotalCells - MinesCount;
        }
    }
}
