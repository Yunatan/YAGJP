using Otter;

namespace YAGJP.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameWindow();
            game.FirstScene = new ActionScene();
            game.FirstScene.CameraZoom = 2;
            game.Start();
        }
    }
}
