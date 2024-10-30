using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;

        public struct Vector4
        {

            public float x;
            public float y;
            public float z;
            public float w;



            public Vector4()
            {
                x = 0;
                y = 0;
                z = 0;
                w = 0;
            }
            public float Magnitude
            {
                get
                {
                    //c = sqrt(x^2 + y^2)
                    return (float)
                        Math.Abs(Math.Sqrt
                        (Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2) + Math.Pow(w, 2)
                        )
                        );
                }
            }

            public Vector4 Normalized
            {
                get
                {
                    return this / Magnitude;
                }
            }

            public Vector4(float x, float y, float z, float w)
            {
                this.x = x;
                this.y = y;
                this.z = z;
                this.w = w;
            }

            public Vector4 Normalize()
            {
                this = Normalized;
                return this;
            }

            public override string ToString()
            {
                return "(" + x + "," + y + "," + z + "," + w + ")";
            }

            public static float DotProduct(Vector4 left, Vector4 right)
            {
                return (left.x * right.x) + (left.y * right.y) + (left.z * right.z) + (left.w * right.w);
            }

            public float DotProduct(Vector4 other)
            {
                return (x * other.x) + (y * other.y) + (z * other.z) + (w * other.w);
            }

            public static bool operator ==(Vector4 left, Vector4 right)
            {
                return (left.x == right.x) && (left.y == right.y) && (left.z == right.z) && (left.w == right.w);
            }

            public static bool operator !=(Vector4 left, Vector4 right)
            {
                return !(left == right);
            }

            public static Vector4 CrossProduct(Vector4 left, Vector4 right)
            {
                return new Vector4((left.y * right.z) - (left.z * right.y), (left.z * right.x) - (left.x * right.z), 
                    (left.x * right.y) - (left.y * right.x), (left.w * right.x) - (left.x * right.w));
            }

            public Vector4 CrossProduct(Vector4 other)
            {
                return new Vector4((y * other.z) - (z * other.y), (z * other.x) - (x * other.z), 
                    (x * other.y) - (y * other.x), (w * other.x) - (x * other.w));
            }

            //operator overload for addition
            public static Vector4 operator +(Vector4 left, Vector4 right)
            {
                return new Vector4(left.x + right.x, left.y + right.y, left.z + right.z, left.w + right.w);
            }

            //operator overload for subtraction
            public static Vector4 operator -(Vector4 left, Vector4 right)
            {
                return new Vector4(left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);
            }

            //operator overload for multiplication by a vector
            public static Vector4 operator *(Vector4 left, Vector4 right)
            {
                return new Vector4(left.x * right.x, left.y * right.y, left.z * right.z, left.w * right.w);
            }

            //operator overload for multiplication by a scalar
            public static Vector4 operator *(Vector4 left, float scalar)
            {
                return new Vector4(left.x * scalar, left.y * scalar, left.z * scalar, left.w * scalar);
            }

            public static Vector4 operator *(float scalar, Vector4 right)
            {
                return new Vector4(scalar * right.x, scalar * right.y, scalar * right.z, scalar * right.w);
            }

            //operator overload for division
            public static Vector4 operator /(Vector4 left, float scalar)
            {
                return new Vector4(left.x / scalar, left.y / scalar, left.z / scalar, left.w / scalar);
            }

            //implicit conversion from System.Numerics.Vector2 to Vector4
            public static implicit operator Vector4(System.Numerics.Vector4 vector)
            {
                return new Vector4(vector.X, vector.Y, vector.Z, vector.W);
            }

            //implicit conversion from Vector4 to System.Numerics.Vector2
            public static implicit operator System.Numerics.Vector2(Vector4 vector)
            {
                return new System.Numerics.Vector2(vector.x, vector.y);
            }
        }
    

}
