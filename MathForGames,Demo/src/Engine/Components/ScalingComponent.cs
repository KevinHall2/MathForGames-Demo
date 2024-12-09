using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace MathForGames_Demo
{
    internal class ScalingComponent : Component
    {
        public ScalingComponent(Actor owner) : base(owner)
        {      }

        Vector2 scaleVector = new Vector2(10, 10);

        public override void Start()
        {
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (Raylib.IsKeyPressed(KeyboardKey.F))
            {
                //Owner.Transform.GlobalScale += scaleVector;
            }
        }




    }
}
