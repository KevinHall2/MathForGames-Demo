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
        public float Speed { get; set; } = 100;

        Vector2 _positiveTranslationX = new Vector2(0.5f, 0.0f);
        Vector2 _positiveTranslationY = new Vector2(0.0f, 0.5f);
        Vector2 _negativeTranslationX = new Vector2(-0.5f, 0.0f);
        Vector2 _negativeTranslationY = new Vector2(0.0f, -0.5f);

        public static Actor transformOwner = new Actor();
        public static Transform2D transformObject = new Transform2D(transformOwner);

        public static Vector2 PlayerPosition
        {
            get => transformOwner.Transform.GlobalPosition;
        }

        Vector2 movementInput = PlayerPosition;

        public Vector2 PositiveTranslationX
        {
            get => _positiveTranslationX;
        }

        public Vector2 PositiveTranslationY
        {
            get => _positiveTranslationY;
        }

        public Vector2 NegativeTranslationX
        {
            get => _negativeTranslationX;
        }

        public Vector2 NegativeTranslationY
        {
            get => _negativeTranslationY;
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);




            if (Raylib.IsKeyDown(KeyboardKey.W))
            {               
                Transform.Translate(NegativeTranslationY);
            }

            if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                Transform.Translate(PositiveTranslationY);
            }
                
            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                Transform.Translate(NegativeTranslationX);
            }
               
            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                Transform.Translate(PositiveTranslationX);
            }
                

            Vector2 deltaMovement = movementInput.Normalized * Speed * (float)deltaTime;
            

            if (deltaMovement.Magnitude != 0)
                Transform.LocalPosition += (deltaMovement);


            //drawing the player
            float scale = 100.0f;
            Rectangle rect = new Rectangle(Transform.LocalPosition, Transform.GlobalScale * scale);
            Vector2 offSet = new Vector2(scale/2, scale/2);

            Raylib.DrawRectanglePro(rect, Transform.LocalScale + offSet, Transform.LocalRotationAngle * (180/3.14f), Color.Red);
            Raylib.DrawLineV(Transform.GlobalPosition, Transform.GlobalPosition + (Transform.Forward * 100), Color.Beige);


        }

        public override void OnCollision(Actor other)
        {
            return;
        }
    }
}
