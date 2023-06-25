using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Inkscii
{
    class Program
    {
        static void Main(string[] args)
        {
            const int WindowWidth = 800;
            const int WindowHeight = 600;
            const int CellSize = 16;

            RenderWindow window = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), "Inkscii");
            window.Closed += (sender, e) => window.Close();

            Renderer renderer = new Renderer(window, CellSize);
            InputHandler inputHandler = new InputHandler(window);

            int playerX = WindowWidth / (2 * CellSize);
            int playerY = WindowHeight / (2 * CellSize);

            bool upKeyPressed = false;
            bool downKeyPressed = false;
            bool leftKeyPressed = false;
            bool rightKeyPressed = false;

            while (window.IsOpen)
            {
                window.DispatchEvents();

                // Handle input
                if (inputHandler.IsKeyPressed(Keyboard.Key.Escape))
                {
                    window.Close();
                }

                if (inputHandler.IsKeyPressed(Keyboard.Key.Up))
                {
                    if (!upKeyPressed)
                    {
                        playerY--;
                        upKeyPressed = true;
                    }
                }
                else
                {
                    upKeyPressed = false;
                }

                if (inputHandler.IsKeyPressed(Keyboard.Key.Down))
                {
                    if (!downKeyPressed)
                    {
                        playerY++;
                        downKeyPressed = true;
                    }
                }
                else
                {
                    downKeyPressed = false;
                }

                if (inputHandler.IsKeyPressed(Keyboard.Key.Left))
                {
                    if (!leftKeyPressed)
                    {
                        playerX--;
                        leftKeyPressed = true;
                    }
                }
                else
                {
                    leftKeyPressed = false;
                }

                if (inputHandler.IsKeyPressed(Keyboard.Key.Right))
                {
                    if (!rightKeyPressed)
                    {
                        playerX++;
                        rightKeyPressed = true;
                    }
                }
                else
                {
                    rightKeyPressed = false;
                }

                // Game logic goes here...

                // Rendering
                renderer.Clear();

                // Draw game objects
                renderer.PrintLine("there is no game here!", new Vector2i(2, 3), Color.Red, Color.Black);
                renderer.DrawCharacter('@', new Vector2i(playerX, playerY), Color.White, Color.Black);

                // Call Render() to display the rendered ASCII game
                renderer.Render();
            }
        }
    }
}
