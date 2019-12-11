using System;
using System.Threading;
using OpenTK;


namespace Program
{
    public class Game
    {
        int MaximumFramesPerSecond = 60;
        private GameWindow window;
        public Game(GameWindow window)
        {
            this.window = window;
            Start();
        }

        void Start()
        {
            
            window.Run(1/MaximumFramesPerSecond);
        }
    }
}