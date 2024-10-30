using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MathLibrary
{
    public struct Vector3
    {

        public float x;
        public float y;
        public float z;



        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public float Magnitude
        {
            get
            {
                //c = sqrt(x^2 + y^2 + z^2)
                return (float)
                    Math.Abs(Math.Sqrt
                    (Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)
                    )
                    );
            }
        }

        public Vector3 Normalized
        {
            get
            {
                return this / Magnitude;
            }
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3 Normalize()
        {
            this = Normalized;
            return this;
        }

        public override string ToString()
        {
            return "(" + x + "," + y + "," + z + ")";
        }

        public static float DotProduct(Vector3 left, Vector3 right)
        {
            return (left.x * right.x) + (left.y * right.y) + (left.z * right.z);
        }

        public float DotProduct(Vector3 other)
        {
           return (x * other.x) + (y * other.y) + (z * other.z);
        }

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return (left.x == right.x) && (left.y == right.y) && (left.z == right.z);
        }

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !(left == right);
        }

        public static Vector3 CrossProduct(Vector3 left, Vector3 right)
        {
            return new Vector3((left.y * right.z) - (left.z * right.y), (left.z * right.x) - (left.x * right.z), (left.x * right.y) - (left.y * right.x));
        }

        public Vector3 CrossProduct(Vector3 other)
        {
            return new Vector3((y * other.z) - (z * other.y), (z * other.x) - (x * other.z), (x * other.y) - (y * other.x));
        }

        //operator overload for addition
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x + right.x, left.y + right.y, left.z + right.z);
        }

        //operator overload for subtraction
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x - right.x, left.y - right.y, left.z - right.z);
        }

        //operator overload for multiplication by a vector
        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x * right.x, left.y * right.y, left.z * right.z);
        }

        //operator overload for multiplication by a scalar
        public static Vector3 operator *(Vector3 left, float scalar)
        {
            return new Vector3(left.x * scalar, left.y * scalar, left.z * scalar);
        }

        public static Vector3 operator *(float scalar, Vector3 right)
        {
            return new Vector3(scalar * right.x, scalar * right.y, scalar * right.z);
        }

        //operator overload for division
        public static Vector3 operator /(Vector3 left, float scalar)
        {
            return new Vector3(left.x / scalar, left.y / scalar, left.z / scalar);
        }

        //implicit conversion from System.Numerics.Vector2 to Vector3
        public static implicit operator Vector3(System.Numerics.Vector3 vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        //implicit conversion from Vector3 to System.Numerics.Vector2
        public static implicit operator System.Numerics.Vector2(Vector3 vector)
        {
            return new System.Numerics.Vector2(vector.x, vector.y);
        }
    }
}
