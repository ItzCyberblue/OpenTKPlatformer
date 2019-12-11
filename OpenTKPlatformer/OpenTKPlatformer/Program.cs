using System;
using OpenTK;


namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            // JESSICA'S QUICK START PROGRAM
            GameWindow window = new GameWindow(800, 600);
            Game gameObject = new Game(window);
        }
    }
}