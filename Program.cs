using System;

class Program
{
    static char[,] board = new char[3, 3]; // Игровое поле 3x3
    static char currentPlayer = 'X'; // Текущий игрок

    static void Main(string[] args)
    {
        InitializeBoard();
        PlayGame();
    }

    // Инициализация пустого игрового поля
    static void InitializeBoard() 
    {
        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                board[i, j] = ' ';
            }
        }
    }

    // Функция печати игрового поля
    static void PrintBoard() 
    {
        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("--|---|--");
        }
    }

    // Функция для проверки корректности хода (Inputcorrectness)
    static bool IsValidMove(int row, int col) 
    {
        return row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ';
    }

    // Функция для проверки победы (Win)
    static bool CheckWin() 
    {
        // Проверка горизонтальных и вертикальных линий
        for (int i = 0; i < 3; i++) 
        {
            if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
            {
                return true;
            }
        }

        // Проверка диагоналей
        if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
            (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
        {
            return true;
        }

        return false;
    }

    // Функция для проверки ничьей (Draw)
    static bool CheckDraw() 
    {
        // Если на доске нет пустых клеток, и никто не выиграл, то ничья
        for (int i = 0; i < 3; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (board[i, j] == ' ') 
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Основная логика игры (Rules, Win, Draw)
    static void PlayGame() 
    {
        bool gameOver = false;

        while (!gameOver) 
        {
            PrintBoard(); // Печать доски

            int row, col;
            bool validMove = false;

            // Проверка корректного ввода
            while (!validMove) 
            {
                Console.WriteLine($"Ход игрока {currentPlayer}. Введите строку и столбец (0, 1 или 2):");
                row = int.Parse(Console.ReadLine());
                col = int.Parse(Console.ReadLine());

                if (IsValidMove(row, col)) 
                {
                    board[row, col] = currentPlayer; // Ввод хода
                    validMove = true;
                } 
                else 
                {
                    Console.WriteLine("Некорректный ход. Попробуйте снова.");
                }
            }

            // Проверка победителя
            if (CheckWin()) 
            {
                PrintBoard();
                Console.WriteLine($"Игрок {currentPlayer} победил!");
                gameOver = true;
            }
            // Проверка ничьей
            else if (CheckDraw()) 
            {
                PrintBoard();
                Console.WriteLine("Ничья!");
                gameOver = true;
            }

            // Смена игрока
            if (!gameOver) 
            {
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
        }
    }
}
