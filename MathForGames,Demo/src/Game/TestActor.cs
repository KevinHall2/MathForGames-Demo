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

        float _playerRadius = 10;
        Vector2 _playerPosition = new Vector2(400, 225);

        public float PlayerRadius
        {
            get => _playerRadius;
        }

        public Vector2 PlayerPosition
        {
            get => _playerPosition;
        }

        public static Vector2 PlayerForward
        {
            get
            {
                return new Vector2(0, 1).Normalized;
            }
        }
        



        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);



            Vector2 movementInput = new Vector2();
            movementInput.y -= Raylib.IsKeyDown(KeyboardKey.S);
            movementInput.y += Raylib.IsKeyDown(KeyboardKey.W);
            movementInput.x -= Raylib.IsKeyDown(KeyboardKey.A);
            movementInput.x += Raylib.IsKeyDown(KeyboardKey.D);
            Vector2 deltaMovement = movementInput.Normalized * Speed * (float)deltaTime;

            if (deltaMovement.Magnitude != 0)
                Transform.LocalPosition += (deltaMovement);

            //drawing player forward
            Raylib.DrawLineV(PlayerPosition, PlayerPosition - (PlayerForward * 100), Color.Black);

            //drawing the player
            Raylib.DrawCircleV(PlayerPosition, PlayerRadius, Color.Red);


        }

        public override void OnCollision(Actor other)
        {
            return;
        }
    }
}
