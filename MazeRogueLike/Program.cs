namespace MazeRogueLike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MazeGenerator mazeGenerator = new MazeGenerator(23, 23);
            mazeGenerator.GenerateMaze();
            mazeGenerator.PrintMaze();
        }
    }
}
