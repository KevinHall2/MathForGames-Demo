﻿using System;
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

        Vector2 _playerSize = new Vector2(150, 90);
        Vector2 _playerPosition = new Vector2();

        public static Actor transformOwner = new Actor();
        public static Transform2D transformObject = new Transform2D(transformOwner);

        public Vector2 PlayerSize
        {
            get => _playerSize;
        }

        public static Vector2 PlayerPosition
        {
            get => transformObject.LocalPosition;
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
            Raylib.DrawRectangleV(movementInput, PlayerSize, Color.Red);
            Raylib.DrawLineV(transformObject.GlobalPosition, transformObject.GlobalPosition + (transformObject.Forward * 400), Color.Black);


        }

        public override void OnCollision(Actor other)
        {
            return;
        }
    }
}
