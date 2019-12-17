using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace OpenTK_RPG.Rendering
{
    class Sprite
    {
        public Vector2 Position { get; set; } = new Vector2(0.0f, 0.0f);
        public Vector2 Size { get; set; } = new Vector2(32.0f, 32.0f);
        public float Rotation { get; set; } = 0.0f;

        public Vector4 Color { get; set; } = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);

        public Sprite()
        {}

        public Sprite(Vector2 position) :
            this()
        {
            Position = position;
        }

        public Sprite(Vector2 position, Vector2 size) :
            this(position)
        {
            Size = size;
        }

        public Sprite(Vector2 position, Vector2 size, float rotation) :
            this(position, size)
        {
            Rotation = rotation;
        }

        public Matrix4 CalculateTransformationMatrix()
        {
            return Matrix4.CreateScale(Size.X, Size.Y, 1.0f)
                   * Matrix4.CreateRotationZ(Rotation)
                   * Matrix4.CreateTranslation(Position.X, Position.Y, 0.0f);
        }
    }
}
