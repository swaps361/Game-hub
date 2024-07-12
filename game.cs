using System;
using System.Linq;

namespace GameHub
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Game Hub");
                Console.WriteLine("1. Tic-tac-toe game");
                Console.WriteLine("2. Sudoku game");
                Console.WriteLine("3. Word guess game");
                Console.WriteLine("4. DSA quiz game");
                Console.WriteLine("5. Find the odd one out game");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        PlayTicTacToe();
                        break;
                    case "2":
                        PlaySudoku();
                        break;
                    case "3":
                        PlayWordGuess();
                        break;
                    case "4":
                        PlayDSAQuiz();
                        break;
                    case "5":
                        PlayFindTheOddOneOut();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void PlayTicTacToe()
        {
            char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char currentPlayer = 'X';
            int moves = 0;

            while (true)
            {
                Console.Clear();
                DrawBoard(board);
                Console.WriteLine($"Player {currentPlayer}, choose your move (1-9): ");
                int choice = int.Parse(Console.ReadLine());

                if (board[choice - 1] != 'X' && board[choice - 1] != 'O')
                {
                    board[choice - 1] = currentPlayer;
                    moves++;
                    if (CheckWin(board))
                    {
                        Console.Clear();
                        DrawBoard(board);
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        break;
                    }
                    if (moves == 9)
                    {
                        Console.Clear();
                        DrawBoard(board);
                        Console.WriteLine("It's a draw!");
                        break;
                    }
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
                else
                {
                    Console.WriteLine("Invalid move, try again.");
                }
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        static void DrawBoard(char[] board)
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        }

        static bool CheckWin(char[] board)
        {
            int[,] winPositions = {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
                { 0, 4, 8 }, { 2, 4, 6 }             
            };

            for (int i = 0; i < winPositions.GetLength(0); i++)
            {
                if (board[winPositions[i, 0]] == board[winPositions[i, 1]] &&
                    board[winPositions[i, 1]] == board[winPositions[i, 2]])
                {
                    return true;
                }
            }
            return false;
        }

        static void PlaySudoku()
        {
            int[,] board = {
                { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
            };

            Console.Clear();
            DrawSudokuBoard(board);
            Console.WriteLine("Sudoku game is under development. Please solve the puzzle by hand.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        static void DrawSudokuBoard(int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 3 || j == 6) Console.Write("| ");
                    Console.Write(board[i, j] + " ");
                }
                if (i == 2 || i == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("---------------------");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        static void PlayWordGuess()
        {
            string[] words = { "apple", "banana", "cherry", "date", "elderberry" };
            Random rand = new Random();
            string wordToGuess = words[rand.Next(words.Length)];
            char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
            int attempts = 6;

            while (attempts > 0)
            {
                Console.Clear();
                Console.WriteLine("Word Guess Game");
                Console.WriteLine("Guess the word: " + new string(guessedWord));
                Console.WriteLine($"Attempts remaining: {attempts}");
                Console.Write("Enter a letter: ");
                char guess = Console.ReadLine()[0];

                bool correctGuess = false;
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                    {
                        guessedWord[i] = guess;
                        correctGuess = true;
                    }
                }

                if (!correctGuess) attempts--;

                if (new string(guessedWord) == wordToGuess)
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations! You've guessed the word: " + wordToGuess);
                    break;
                }
            }

            if (attempts == 0)
            {
                Console.Clear();
                Console.WriteLine("Game over! The word was: " + wordToGuess);
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        static void PlayDSAQuiz()
        {
            var questions = new[]
            {
                new { Question = "What is the time complexity of binary search?", Options = new[] { "O(n)", "O(log n)", "O(n^2)" }, Answer = "O(log n)" },
                new { Question = "Which data structure uses LIFO?", Options = new[] { "Queue", "Stack", "Tree" }, Answer = "Stack" }
            };

            int score = 0;

            foreach (var q in questions)
            {
                Console.Clear();
                Console.WriteLine(q.Question);
                for (int i = 0; i < q.Options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {q.Options[i]}");
                }
                Console.Write("Choose the correct option (1-3): ");
                int choice = int.Parse(Console.ReadLine());

                if (q.Options[choice - 1] == q.Answer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine($"Your score: {score}/{questions.Length}");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        static void PlayFindTheOddOneOut()
        {
            var sets = new[]
            {
                new { Items = new[] { "cat", "dog", "fish", "car" }, OddOneOut = "car" },
                new { Items = new[] { "rose", "tulip", "oak", "daisy" }, OddOneOut = "oak" }
            };

            Random rand = new Random();
            var set = sets[rand.Next(sets.Length)];

            Console.Clear();
            Console.WriteLine("Find the Odd One Out Game");
            Console.WriteLine("Which one is the odd one out?");
            for (int i = 0; i < set.Items.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {set.Items[i]}");
            }
            Console.Write("Choose the odd one out (1-4): ");
            int choice = int.Parse(Console.ReadLine());

            if (set.Items[choice - 1] == set.OddOneOut)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
