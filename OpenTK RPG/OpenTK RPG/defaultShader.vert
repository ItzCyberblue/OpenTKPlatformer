#version 330

in vec2 position;

uniform mat4 u_projection;
uniform mat4 u_transformation;

void main(void)
{
	gl_Position = u_projection * u_transformation * vec4(position, 0.0, 1.0);
}
