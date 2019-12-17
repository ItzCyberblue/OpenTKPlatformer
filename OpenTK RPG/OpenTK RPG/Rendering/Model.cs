using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace OpenTK_RPG.Rendering
{
    class Model
    {
        private readonly int _vbo;

        public int Vao { get; }
        public PrimitiveType Type { get; }
        public int Count { get; }

        public Model(float[] vertexData, int dimensions, PrimitiveType type)
        {
            Count = vertexData.Length / dimensions;
            Type = type;

            // Generate a vao and a vbo
            Vao = GL.GenVertexArray();
            _vbo = GL.GenBuffer();

            // Tell OpenTK that we are working with the vao and the vbo
            GL.BindVertexArray(Vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);

            // Put the vertexData into the vbo
            GL.NamedBufferStorage(
                _vbo,
                vertexData.Length * sizeof(float),
                vertexData,
                BufferStorageFlags.MapWriteBit
            );

            // Open the attribute at index 0 for writing
            GL.VertexArrayAttribBinding(Vao, 0, 0);
            GL.EnableVertexArrayAttrib(Vao, 0);

            // Tell the vao what the layout is for the data inside the vbo
            GL.VertexArrayAttribFormat(
                Vao,
                0,                          // attribute index
                dimensions,                 // size of attribute
                VertexAttribType.Float,     // contains floats
                false,                      // does not need to be normalized as it is already, floats ignore this flag anyway
                0);                         // relative offset, first item

            // Bind the vbo to the vao
            GL.VertexArrayVertexBuffer(Vao, 0, _vbo, IntPtr.Zero, dimensions * sizeof(float));

            // Tell OpenTK we are done working with the vbo and vao
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        void CleanUp()
        {
            // Free the memory on the gpu
            GL.DeleteBuffer(_vbo);
            GL.DeleteVertexArray(Vao);
        }
    }
}
