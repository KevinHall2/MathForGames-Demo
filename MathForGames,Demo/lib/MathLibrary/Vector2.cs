using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.InteropServices;

namespace MathLibrary
{
    public struct Vector2
    {
        public float x;
        public float y;



        public Vector2()
        {
            x = 0;
            y = 0;
        }
        public float Magnitude
        {
            get
            {
                //c = sqrt(x^2 + y^2)
                return (float)
                    Math.Abs
                    (Math.Sqrt
                    (Math.Pow
                    (x, 2) + Math.Pow(y, 2)
                    )
                    );
            }
        }

        public Vector2 Normalized
        {
            get
            {
                return this / Magnitude;
            }
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2 Normalize()
        {
            this = Normalized;
            return this;
        }


        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }

        public float DotProduct(Vector2 other)
        {
            return (x * other.x) + (y * other.y); 
        }

        public float Distance(Vector2 other)
        {
            return (other - this).Magnitude;
        }

        //operator overload for "is equal to"
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return (left.x == right.x) && (left.y == right.y);
        }

        //operator overload for "is not equal to"
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }



        //operator overload for addition
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }

        //operator overload for subtraction
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x - right.x, left.y - right.y);
        }

        //operator overload for multiplication by a vector
        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x * right.x, left.y * right.y);
        }

        //operator overload for multiplication by a scalar
        public static Vector2 operator *(Vector2 left, float scalar)
        {
            return new Vector2(left.x * scalar, left.y * scalar);
        }

        //operator overload for division
        public static Vector2 operator /(Vector2 left, float scalar)
        {
            return new Vector2(left.x / scalar, left.y / scalar);
        }

        //implicit conversion from System.Numerics.Vector2 to Vector2
        public static implicit operator Vector2(System.Numerics.Vector2 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        //implicit conversion from Vector2 to System.Numerics.Vector2
        public static implicit operator System.Numerics.Vector2(Vector2 vector)
        {
            return new System.Numerics.Vector2(vector.x, vector.y);
        }
    }
}
