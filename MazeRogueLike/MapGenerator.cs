using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MazeRogueLike.Entities;

namespace MazeRogueLike
{
    public class MapGenerator
    {
        private int width;
        private int height;
        private char[,] maze;
        private Random random = new Random();

        private Player player;
        private MeleeEnemy meleeEnemy;
        private ArcherEnemy archerEnemy;
        private List<Arrow> arrows;

        public MapGenerator(int width, int height)
        {
            this.width = width;
            this.height = height;
            player = new Player();
            meleeEnemy = new MeleeEnemy();
            archerEnemy = new ArcherEnemy();
            arrows = new List<Arrow>();
        }

        public void StartGame()
        {
            do
            {
                GenerateMaze();
                PrintMaze();
                PlacePlayer();
                PlaceMeleeEnemy();
                PlaceArcherEnemy();
                RunGame();
                Console.WriteLine("Do you want to play again? (y/n)");
            } while (Console.ReadKey(true).Key == ConsoleKey.Y);
        }

        private void GenerateMaze()
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

        private void PlacePlayer()
        {
            player.X = 0;
            player.Y = 1;
            maze[player.X, player.Y] = 'P';
        }

        private void PlaceMeleeEnemy()
        {
            meleeEnemy.X = width - 3; // Помещаем врага близко к выходу
            meleeEnemy.Y = height - 2;
            maze[meleeEnemy.X, meleeEnemy.Y] = 'E';
        }

        private void PlaceArcherEnemy()
        {
            archerEnemy.X = width - 5; // Помещаем лучника ближе к выходу
            archerEnemy.Y = height - 2;
            maze[archerEnemy.X, archerEnemy.Y] = 'A';
        }

        private void RunGame()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        TryMove(player, 0, -1);
                        break;
                    case ConsoleKey.S:
                        TryMove(player, 0, 1);
                        break;
                    case ConsoleKey.A:
                        TryMove(player, -1, 0);
                        break;
                    case ConsoleKey.D:
                        TryMove(player, 1, 0);
                        break;
                }

                if (!IsPlayerCaught())
                {
                    MeleeEnemyMove();
                    ArcherEnemyMove();
                }

                UpdateArrows();
                PrintMaze();
            } while (key.Key != ConsoleKey.Escape && !(player.X == width - 1 && player.Y == height - 2) && !player.IsDead);
        }

        private void TryMove(Entity entity, int deltaX, int deltaY)
        {
            int newX = entity.X + deltaX;
            int newY = entity.Y + deltaY;

            if (IsInBounds(newX, newY) && maze[newX, newY] != '#')
            {
                maze[entity.X, entity.Y] = ' '; // Освобождаем текущую клетку
                entity.X = newX;
                entity.Y = newY;
                maze[entity.X, entity.Y] = entity.Symbol; // Помещаем сущность в новую клетку
            }
        }

        private void MeleeEnemyMove()
        {
            // Вероятность случайного движения
            int randomMoveProbability = 20; // Например, 20%

            if (random.Next(1, 101) <= randomMoveProbability)
            {
                // Случайное движение врага
                int randomDirection = random.Next(0, 4); // 0 - вверх, 1 - вправо, 2 - вниз, 3 - влево

                switch (randomDirection)
                {
                    case 0:
                        TryMove(meleeEnemy, 0, -1);
                        break;
                    case 1:
                        TryMove(meleeEnemy, 1, 0);
                        break;
                    case 2:
                        TryMove(meleeEnemy, 0, 1);
                        break;
                    case 3:
                        TryMove(meleeEnemy, -1, 0);
                        break;
                }
            }
            else
            {
                // Движение врага в сторону игрока
                int playerDeltaX = player.X - meleeEnemy.X;
                int playerDeltaY = player.Y - meleeEnemy.Y;

                if (Math.Abs(playerDeltaX) > Math.Abs(playerDeltaY))
                {
                    TryMove(meleeEnemy, Math.Sign(playerDeltaX), 0);
                }
                else
                {
                    TryMove(meleeEnemy, 0, Math.Sign(playerDeltaY));
                }
            }

            if (IsPlayerCaught())
            {
                player.IsDead = true;
                Console.WriteLine("Player is dead!");
            }
        }

        private void ArcherEnemyMove()
        {
            // Вероятность случайного движения
            int randomMoveProbability = 20; // Например, 50%

            if (random.Next(1, 101) <= randomMoveProbability)
            {
                // Случайное движение врага
                int randomDirection = random.Next(0, 4); // 0 - вверх, 1 - вправо, 2 - вниз, 3 - влево

                switch (randomDirection)
                {
                    case 0:
                        TryMove(archerEnemy, 0, -1);
                        break;
                    case 1:
                        TryMove(archerEnemy, 1, 0);
                        break;
                    case 2:
                        TryMove(archerEnemy, 0, 1);
                        break;
                    case 3:
                        TryMove(archerEnemy, -1, 0);
                        break;
                }
            }
            else
            {
                // Движение врага в сторону игрока
                int playerDeltaX = player.X - archerEnemy.X;
                int playerDeltaY = player.Y - archerEnemy.Y;

                if (Math.Abs(playerDeltaX) > Math.Abs(playerDeltaY))
                {
                    TryMove(archerEnemy, Math.Sign(playerDeltaX), 0);
                }
                else
                {
                    TryMove(archerEnemy, 0, Math.Sign(playerDeltaY));
                }

                // Проверяем дистанцию и атакуем игрока, если он в радиусе
                if (Math.Abs(playerDeltaX) <= archerEnemy.AttackRange && Math.Abs(playerDeltaY) <= archerEnemy.AttackRange)
                {
                    AttackPlayer(archerEnemy);
                }
            }

            if (IsPlayerCaught())
            {
                player.IsDead = true;
                Console.WriteLine("Player is dead!");
            }
        }

        private void UpdateArrows()
        {
            foreach (var arrow in arrows.ToList())
            {
                arrow.Move();

                if (arrow.X == player.X && arrow.Y == player.Y)
                {
                    player.IsDead = true;
                    Console.WriteLine("Player is dead!");
                }

                if (!IsInBounds(arrow.X, arrow.Y) || maze[arrow.X, arrow.Y] == '#')
                {
                    arrows.Remove(arrow);
                }
            }
        }

        private void AttackPlayer(Enemy enemy)
        {
            // Создаем стрелу и направляем ее к игроку
            arrows.Add(new Arrow(enemy.X, enemy.Y, player.X, player.Y));
        }

        private bool IsPlayerCaught()
        {
            return Math.Abs(player.X - meleeEnemy.X) <= 1 && Math.Abs(player.Y - meleeEnemy.Y) <= 1;
        }

        private void PrintMaze()
        {
            Console.Clear();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    // Отображаем стрелы
                    var arrow = arrows.FirstOrDefault(a => a.X == j && a.Y == i);
                    if (arrow != null)
                    {
                        Console.Write(arrow.Symbol + " ");
                    }
                    else
                    {
                        Console.Write(maze[j, i] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Use arrow keys to move. Press Esc to exit.");
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