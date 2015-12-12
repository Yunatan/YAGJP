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
        int i = 1;
        OgmoProject proj;

        internal ActionScene() : base()
        {
           // The path to the level to be loaded.
            var pathLevel = @"Resources\Levels\lvl1_new.oel";
            // The path to the Ogmo Project to use when loading the level.
            var pathProject = @"Resources\Levels\levels.oep";

            // Create a new OgmoProject using the .oep file.
            proj = new OgmoProject(pathProject);

            // Ensure that the grid layer named "Solids" gets the Solid collision tag when loading.
            //OgmoProject.RegisterTag(Tags.Solid, "Solids");

            // Load the level into the Scene.
            proj.LoadLevelFromFile(pathLevel, this);

        }

        public override void Update()
        {
            if (Input.KeyPressed(Key.A))
            {
                //proj.LoadNexLayer(@"Resources\Levels\lvl1_new.oel", this, proj.GetLayerNames()[i]);
                i++;
            }
            base.Update();
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
