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

    // Основная логика игры (Rules: чередование ходов)
    static void PlayGame() 
    {
        bool gameOver = false;  // Пока победитель или ничья не обнаружены, игра продолжается

        while (!gameOver) 
        {
            PrintBoard(); // Печать текущего состояния доски

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
                    board[row, col] = currentPlayer; // Устанавливаем символ текущего игрока в выбранную ячейку
                    validMove = true;  // Завершаем цикл корректного ввода
                } 
                else 
                {
                    Console.WriteLine("Некорректный ход. Попробуйте снова.");  // Выводим сообщение об ошибке
                }
            }

            // Логика смены игрока (ветка Rules)
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';  // Меняем игрока после успешного хода
        }

        // Пока игра не завершена, основная логика будет продолжаться.
        // Логика победы, ничьей и перезапуска еще не добавлена.
    }
}
