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
        const int width = 960;
        const int height = 600;

        internal GameWindow() : base(windowTitle, width, height)
        {
            WindowResize = false;
            Color = Color.Black;
        }
        
    }
}
