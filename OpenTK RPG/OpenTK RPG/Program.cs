using System;
using OpenTK;

namespace OpenTK_RPG
{
	class Program
	{
		public static void Main(string[] args)
		{
			GameWindow window = new GameWindow(500, 500);
			window.Run(1.0/60.0);
		}
	}
}