using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace MathForGames_Demo
{
    internal class ScalingComponent : Component
    {
        public ScalingComponent(Actor owner) : base(owner)
        {      }

        Vector2 positiveScaleVector = new Vector2(10, 10);
        Vector2 negativeScaleVector = new Vector2(-10, -10);

        public override void Start()
        {
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (Raylib.IsKeyPressed(KeyboardKey.F))
            {
                Owner.Transform.Scale(positiveScaleVector);
            }

            if (Raylib.IsKeyPressed(KeyboardKey.G))
            {
                Owner.Transform.Scale(negativeScaleVector);
            }
        }

        public override void End()
        {
            base.End();
        }


    }
}
