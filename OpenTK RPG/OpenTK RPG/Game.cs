using System;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK_RPG.Rendering;

namespace OpenTK_RPG
{
    public class Game
    {
        private readonly SpriteRenderer _renderer;
        private readonly GameWindow _window;

        private Sprite _testSprite;

        public Game(GameWindow window)
        {
            _window = window;

            window.UpdateFrame += Update;
            window.RenderFrame += Draw;

            _renderer = new SpriteRenderer(new ShaderProgram(new Shader[]
            {
                new Shader(ShaderType.FragmentShader, File.ReadAllText("defaultShader.frag")),
                new Shader(ShaderType.VertexShader  , File.ReadAllText("defaultShader.vert"))
            }));

            _testSprite = new Sprite()
            {
                Color = new Vector4(0.0f, 1.0f, 1.0f, 1.0f)
            };
            _renderer.Add(_testSprite);
        }

        private double counter = 0.0f;
        public void Update(object sender, FrameEventArgs args)
        {
            counter += args.Time;

            _testSprite.Position = 128.0f * new Vector2((float)Math.Cos(counter), (float)Math.Sin(counter));
        }

        public void Draw(object sender, FrameEventArgs args)
        {
            _renderer.Draw(new Vector2(_window.Width, _window.Height));

            _window.SwapBuffers();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}