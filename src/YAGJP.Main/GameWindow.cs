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
        const int width = 1600;
        const int height = 800;

        internal GameWindow() : base(windowTitle, width, height)
        {
         //   WindowResize = false;
            MouseVisible = true;
            Color = Color.Gray;
        }
        
    }
}
