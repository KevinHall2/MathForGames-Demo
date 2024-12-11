using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace MathForGames_Demo
{
    internal class ChildActor : PlayerActor
    {
        private PlayerActor parent;
        //public static Transform2D transformManipulator = PlayerActor.transformObject;
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);


            //drawing the child
            float scale = 50.0f;
            Rectangle rect = new Rectangle(Transform.LocalPosition, Transform.GlobalScale * scale);
            Vector2 offSet = new Vector2(scale / 2, scale / 2);

            Raylib.DrawRectanglePro(rect, Transform.LocalScale + offSet, Transform.LocalRotationAngle * (180 / 3.14f), Color.Blue);
            Raylib.DrawLineV(Transform.GlobalPosition, Transform.GlobalPosition + (Transform.Forward * 100), Color.Black);

            if (parent != null)
            {
                //rect = ;
            }
        }

        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);
        }
    }
}
