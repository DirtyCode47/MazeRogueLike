using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRogueLike
{
    internal class MazeGenerator
    {
        private int width;
        private int height;
        private char[,] maze;
        private Random random = new Random();
        public MazeGenerator(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void GenerateMaze()
        {
            InitializeMaze();
            GenerateMaze(1, 1);
        }

        private void InitializeMaze()
        {
            maze = new char[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    maze[i, j] = '#'; // Заполняем лабиринт стенами
                }

            }

            // Устанавливаем вход и выход
            maze[0, 1] = 'S'; // Вход
            maze[width - 1, height - 2] = 'E'; // Выход
        }

        private void GenerateMaze(int x, int y)
        {
            List<int[]> directions = new List<int[]>
        {
            new int[] { 0, 2 },
            new int[] { 2, 0 },
            new int[] { 0, -2 },
            new int[] { -2, 0 }
        };

            Shuffle(directions);

            foreach (var direction in directions)
            {
                int newX = x + direction[0];
                int newY = y + direction[1];

                if (IsInBounds(newX, newY) && maze[newX, newY] == '#')
                {
                    maze[x + direction[0] / 2, y + direction[1] / 2] = ' '; // Открываем проход
                    maze[newX, newY] = ' ';
                    GenerateMaze(newX, newY);
                }
            }
        }
        public void PrintMaze()
        {
            Console.Clear();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(maze[j, i] + " "); 
                }
                Console.WriteLine();
            }
            Console.WriteLine("Use WASD keys to move. Press Esc to exit.");
        }

        private void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        private bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }
    }
}