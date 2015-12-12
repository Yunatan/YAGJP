using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGJP.Main
{
    class GameWindow : Game
    {
        const string windowTitle = "YAGJP";
        const int width = 640;
        const int height = 480;

        public GameWindow() : base(windowTitle, width, height)
        {
            
        }
    }
}
