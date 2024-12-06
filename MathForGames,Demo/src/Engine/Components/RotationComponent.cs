using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGames_Demo
{
    internal class RotationComponent : Component
    {
        //creates the actor that will function as the owner of the transform object
        public static Actor componentOwner = new Actor();
        
        //creates the transform object and sets componentOwner as the owner
        public static Transform2D rotationTransform = new Transform2D(componentOwner);

        //makes a constructor that references the constructor of the base component class
        public RotationComponent(Actor owner) : base(owner)
        {         }

        public static float rotationAngle;
            
        static Matrix3 rotationMatrix = rotationTransform.LocalRotation;
        Vector2 rotationVector = rotationTransform.LocalPosition;
        public override void Start()
        {
            base.Start();

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            float rotationScalar = 10.0f;
            if (Raylib.IsKeyPressed(KeyboardKey.Q))
            {
                
                rotationTransform.Rotate(rotationScalar);
                rotationAngle = rotationTransform.GlobalRotationAngle;

                               
            }

            if (Raylib.IsKeyPressed(KeyboardKey.E))
            {
                rotationTransform.Rotate(-(rotationScalar));
                rotationAngle = rotationTransform.GlobalRotationAngle;
            }
            
            
        }

        public override void End()
        {
            base.End();
        }

    }
}
