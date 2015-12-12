using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGJP.Main.Entities
{
    class Player : Entity
    {
        //Player player;
        Image img = Image.CreateRectangle(32, 32, Color.Red);

        public Player(float x, float y) : base(x, y)
        {
            //this.player = player;
            AddGraphic(img);
            SetHitbox(32, 32, Tags.Player);
        }
    }
}