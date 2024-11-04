using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames_Demo
{
    internal class Transform2D
    {


        public float GlobalRotationAngle
        {
            get { return (float)Math.Atan2(_globalMatrix.m01, _globalMatrix.m00); }
        }

        public Transform2D Parent { get => _parent; }

        public Transform2D[] Children { get => _children; }

        public Transform2D(Actor owner)
        {
            _owner = owner;
            _children = new Transform2D[0];
        }

        public void Translate(Vector2 direction)
        {
            LocalPosition += direction;
        }

        public void Translate(float x, float y)
        {
            LocalPosition += new Vector2(x, y);
        }




    }
}
