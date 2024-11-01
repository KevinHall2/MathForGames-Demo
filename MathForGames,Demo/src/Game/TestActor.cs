using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGames_Demo
{
    internal class TestActor : Actor
    {
        public float Speed { get; set; } = 50;

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            Vector2 movementInput = new Vector2();
            movementInput.y -= Raylib.IsKeyDown(KeyboardKey.W);
            movementInput.y += Raylib.IsKeyDown(KeyboardKey.A);
            movementInput.x -= Raylib.IsKeyDown(KeyboardKey.S);
            movementInput.x += Raylib.IsKeyDown(KeyboardKey.D);
            Vector2 deltaMovement = movementInput.Normalized * Speed * (float)deltaTime;

            if (deltaMovement.Magnitude != 0)
                Transform.LocalPosiiton += (deltaMovement);

            Raylib.DrawCircleV(Transform.GlobalPosition, Transform.GlobalScale.x / 2 * 100, Color.Blue);
        }

        public override void OnCollision(Actor other)
        {
            _color = Color.Red;
        }
    }
}
