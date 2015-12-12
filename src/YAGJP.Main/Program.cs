using Otter;

namespace YAGJP.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameWindow();
            game.FirstScene = new ActionScene();
            // Set the background color to see stuff a little better.
            game.Color = Color.Cyan;
            game.Start();
        }
    }
}
