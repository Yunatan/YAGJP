﻿using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGJP.Main.Entities;

namespace YAGJP.Main
{
    class ActionScene : Scene
    {
        //int i = 1;
        OgmoProject proj;

        internal ActionScene() : base()
        {


            // The path to the level to be loaded.
            var pathLevel = @"Resources\Levels\lvl1.oel";
            // The path to the Ogmo Project to use when loading the level.
            var pathProject = @"levels.oep";

            // Create a new OgmoProject using the .oep file.
            proj = new OgmoProject(pathProject);

            //Ensure that the grid layer named "Solids" gets the Solid collision tag when loading.
            //proj.RegisterTag(Tags.Solid, "Walls");
            //proj.RegisterTag(Tags.Solid, "Walls_1");
            //proj.RegisterTag(Tags.Solid, "Walls_2");

            // Load the level into the Scene.
            proj.LoadLevelFromFile(pathLevel, this);

            var player = new Player(100, 100);
            this.Add(player);

            var obj = new Entity(110, 10, Image.CreateRectangle(32, 32, Color.Blue));
            this.Add(obj);
        }

        //public override void Update()
        //{
        //    if (Input.KeyPressed(Key.A))
        //    {
        //        //proj.LoadNexLayer(@"Resources\Levels\lvl1.oel", this, proj.GetLayerNames()[i]);
        //        i++;
        //    }
        //    base.Update();
        //}

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
