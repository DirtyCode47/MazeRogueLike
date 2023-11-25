namespace MazeRogueLike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MapGenerator mapGenerator = new MapGenerator(23, 23);
            mapGenerator.StartGame();

        }
    }
}
