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
        BoxCollider collider = new BoxCollider(32, 32, Tags.Player);
        Image img = Image.CreateRectangle(32, 32, Color.Red);

        public Player(float x, float y) : base(x, y)
        {
            AddGraphic(img);
            img.CenterOrigin();
           // SetHitbox(32, 32, Tags.Player);
           //AddCollider(collider);
           //collider.CenterOrigin();
        }

        public float MoveSpeed = 5;

        public override void UpdateLast()
        {
            base.UpdateLast();

            Scene.CenterCamera(X, Y);
        }

        public override void Update()
        {
            base.Update();
            // Every update check for input and react accordingly.

            // If the W key is down,
            if (Input.KeyDown(Key.W))
            {
                // Move up by the move speed.
                Y -= MoveSpeed;
            }
            // If the S key is down,
            if (Input.KeyDown(Key.S))
            {
                // Move down by the move speed.
                Y += MoveSpeed;
            }
            // If the A key is down,
            if (Input.KeyDown(Key.A))
            {
                // Move left by the move speed.
                X -= MoveSpeed;
            }
            // If the D key is down,
            if (Input.KeyDown(Key.D))
            {
                // Move right by the move speed.
                X += MoveSpeed;
            }
        }
    }
}