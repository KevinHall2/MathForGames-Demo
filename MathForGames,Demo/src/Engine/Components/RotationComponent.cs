using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGames_Demo
{
    internal class RotationComponent : Component
    {
        public static Actor componentOwner = new Actor();

       Transform2D rotationTransform = new Transform2D(componentOwner);

        public RotationComponent(Actor owner) : base(owner)
        { }
            

        public override void Start()
        {
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            if (Raylib.IsKeyPressed(KeyboardKey.Q))
            {
                rotationTransform.Rotate(1.0f);
            }

            if (Raylib.IsKeyPressed(KeyboardKey.E))
            {
                rotationTransform.Rotate(-1.0f);
            }

        }

        public override void End()
        {
            base.End();
        }

    }
}
