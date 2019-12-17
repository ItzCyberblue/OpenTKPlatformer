using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace OpenTK_RPG.Rendering
{
    class ShaderProgram
    {
        private readonly int _program;
        private readonly Dictionary<string, int> _uniforms = new Dictionary<string, int>();

        public ShaderProgram(IEnumerable<Shader> shaders)
        {
            var enumerable = shaders as Shader[] ?? shaders.ToArray();

            // Create program and attach the shaders to it
            _program = GL.CreateProgram();
            foreach (var shader in enumerable)
                GL.AttachShader(_program, shader.Id);

            // Link the code
            GL.LinkProgram(_program);
            string info = GL.GetProgramInfoLog(_program);
            if (!string.IsNullOrWhiteSpace(info))
                throw new Exception(info);

            // Detach the shaders, as we already compiled them
            foreach (var shader in enumerable)
                GL.DetachShader(_program, shader.Id);
        }

        public int GetUniformLocation(string uniformName)
        {
            // If the uniform is inside of the dictionary, return that value
            if (_uniforms.ContainsKey(uniformName))
                return _uniforms[uniformName];

            // If the uniform is not inside the dictionary, ask the gpu what the location is, and store it in the dictionary
            int uniformLocation = GL.GetUniformLocation(_program, uniformName);
            _uniforms.Add(uniformName, uniformLocation);
            return uniformLocation;
        }

        public void Bind()
        {
            // Tell OpenTK that we want to use the program
            GL.UseProgram(_program);
        }

        public void Unbind()
        {
            // Tell OpenTK that we are done using the program
            GL.UseProgram(0);
        }

        void CleanUp()
        {
            // Free memory on the gpu
            GL.DeleteProgram(_program);
        }
    }
}
