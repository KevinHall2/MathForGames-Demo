using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGames_Demo
{
    internal class PlayerActor : Actor
    {
        public float Speed { get; set; } = 10;

        int _playerSize = 4;
        float _playerRadius = 150.0f;

        public static Actor transformOwner = new Actor();
        public static Transform2D transformObject = new Transform2D(transformOwner);

        public int PlayerSize
        {
            get => _playerSize;
        }

        public static Vector2 PlayerPosition
        {
            get => transformObject.LocalPosition;
        }

        public float PlayerRadius
        {
            get => _playerRadius;
        }

        public float PlayerRotation
        {
            get => RotationComponent.rotationAngle;
        }

        public static Vector2 PlayerForward
        {
            get
            {
                return new Vector2(0, 1).Normalized;
            }
        }

        
        Vector2 movementInput = PlayerPosition;


        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            

            
            if (Raylib.IsKeyDown(KeyboardKey.W)) movementInput.y -= 0.2f;
            if (Raylib.IsKeyDown(KeyboardKey.S)) movementInput.y += 0.2f;
            if (Raylib.IsKeyDown(KeyboardKey.A)) movementInput.x -= 0.2f;
            if (Raylib.IsKeyDown(KeyboardKey.D)) movementInput.x += 0.2f;
            Vector2 deltaMovement = movementInput.Normalized * Speed * (float)deltaTime;
            

            if (deltaMovement.Magnitude != 0)
                Transform.LocalPosition += (deltaMovement);


            //drawing the player
            float scale = 50.0f;
            Rectangle rect = new Rectangle(Transform.GlobalPosition, Transform.GlobalScale * scale);
            Vector2 offSet = new Vector2(scale/2, scale/2);
            Raylib.DrawRectanglePro(rect, new Vector2(0, 0) + offSet, Transform.GlobalRotationAngle, Color.Red);

            Raylib.DrawLineV(Transform.GlobalPosition, Transform.GlobalPosition + (Transform.Forward * 100), Color.Beige);
            //Raylib.DrawPoly(movementInput, PlayerSize, PlayerRadius, PlayerRotation, Color.Red);
            //Raylib.DrawLineV(movementInput, movementInput + (movementInput * 400), Color.Black);


        }

        public override void OnCollision(Actor other)
        {
            return;
        }
    }
}
