using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace OpenTK_RPG.Rendering
{
    class Shader
    {
        public int Id { get; }

        public Shader(ShaderType type, string source)
        {
            // Allocate a shader on the gpu
            Id = GL.CreateShader(type);

            // Send the shadercode to the gpu, and compile it
            GL.ShaderSource(Id, source);
            GL.CompileShader(Id);

            // Check for errors / warnings during shader compilation
            var info = GL.GetShaderInfoLog(Id);
            if (!string.IsNullOrWhiteSpace(info))
                throw new Exception(info);
        }

        public void CleanUp()
        {
            GL.DeleteShader(Id);
        }
    }
}
