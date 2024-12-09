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
        

        //makes a constructor that references the constructor of the base component class
        public RotationComponent(Actor owner) : base(owner)
        {         }

            
        public override void Start()
        {
            base.Start();

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            float rotationScalar = 1.0f;
            if (Raylib.IsKeyDown(KeyboardKey.Q))
            {
                Console.WriteLine(Owner);
                Owner.Transform.Rotate(rotationScalar * (float)deltaTime);                              
            }

            if (Raylib.IsKeyDown(KeyboardKey.E))
            {
                Owner.Transform.Rotate(-(rotationScalar * (float)deltaTime));
            }

            return;
        }

        public override void End()
        {
            base.End();
        }

    }
}
