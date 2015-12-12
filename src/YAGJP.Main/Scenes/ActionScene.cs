using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGJP.Main
{
    class ActionScene : Scene
    {
        internal ActionScene() : base()
        {
            // The path to the level to be loaded.
            var pathLevel = @"Resources\Levels\lvl1.oel";
            // The path to the Ogmo Project to use when loading the level.
            var pathProject = @"Resources\Levels\levels.oep";

            // Create a new OgmoProject using the .oep file.
            var OgmoProject = new OgmoProject(pathProject);

            // Ensure that the grid layer named "Solids" gets the Solid collision tag when loading.
            //OgmoProject.RegisterTag(Tags.Solid, "Solids");

            // Load the level into the Scene.
            OgmoProject.Layers["grid_2"].Color = Color.Cyan;
            OgmoProject.LoadLevelFromFile(pathLevel, this);

        }


    }

    // Collision tags to use in the game.
    enum Tags
    {
        Solid,
        Player,
        Coin,
        Exit
    }
}
