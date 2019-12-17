using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTK_RPG.Rendering
{
    class SpriteRenderer
    {
        private readonly Model _spriteModel;
        private readonly List<Sprite> _sprites = new List<Sprite>();

        public ShaderProgram Shader { get; set; }

        public SpriteRenderer(ShaderProgram shader)
        {
            _spriteModel = new Model(new float[]
            {
                 0.5f, -0.5f,
                 0.5f,  0.5f,
                -0.5f, -0.5f,
                -0.5f,  0.5f
            }, 2, PrimitiveType.TriangleStrip );

            Shader = shader;
        }

        // Some functions to add / remove to the sprites list
        public void Add(Sprite sprite) => _sprites.Add(sprite);
        public void AddRange(IEnumerable<Sprite> sprites) => _sprites.AddRange(sprites);
        public bool Remove(Sprite sprite) => _sprites.Remove(sprite);

        private Matrix4 CalculateProjectionMatrix(Vector2 windowSize)
        {
            return new Matrix4(
                2.0f / windowSize.X, 0.0f, 0.0f, 0.0f,
                0.0f, 2.0f / windowSize.Y, 0.0f, 0.0f,
                0.0f, 0.0f, 0.0f, 0.0f,
                0.0f, 0.0f, 0.0f, 1.0f
            );
        }

        public void Draw(Vector2 windowSize)
        {
            // Bind the shader
            Shader.Bind();

            // Bind the vao of the sprite model
            GL.BindVertexArray(_spriteModel.Vao);

            Matrix4 projection = CalculateProjectionMatrix(windowSize);
            GL.UniformMatrix4(Shader.GetUniformLocation("u_projection"), false, ref projection);

            foreach (Sprite sprite in _sprites)
            {
                // Send the coordinates of the sprite to the gpu
                Matrix4 transform = sprite.CalculateTransformationMatrix();
                GL.UniformMatrix4(Shader.GetUniformLocation("u_transformation"), false, ref transform);

                // Send the color of the sprite to the gpu
                GL.Uniform4(Shader.GetUniformLocation("u_color"), sprite.Color);

                // Draw the sprite
                GL.DrawArrays(_spriteModel.Type, 0, _spriteModel.Count);
            }
        }
    }
}
