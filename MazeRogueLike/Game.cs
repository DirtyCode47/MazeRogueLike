using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRogueLike
{
    internal class Game
    {
        private Maze maze;

        public Game()
        {
            maze = new Maze(23, 23);
        }
        public void Run()
        {
            do
            {
                MazeManager.CreateMaze(maze);
                GameUpdater.Update(maze);

                Console.WriteLine("Do you want to play again? (y/n)");
            } while (Console.ReadKey(true).Key == ConsoleKey.Y);
            //В случае, когда уровень закончится, можно будет нажать Y для перехода на следующий уровень с новым лабиринтом
        }
    }
}
