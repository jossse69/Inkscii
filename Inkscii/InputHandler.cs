using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;

namespace Inkscii
{
    public class InputHandler
    {
        private Dictionary<Keyboard.Key, bool> keyStates;
        private Dictionary<Mouse.Button, bool> mouseButtonStates;

        public InputHandler(RenderWindow window)
        {
            keyStates = new Dictionary<Keyboard.Key, bool>();
            mouseButtonStates = new Dictionary<Mouse.Button, bool>();

            // Initialize key states
            foreach (Keyboard.Key key in System.Enum.GetValues(typeof(Keyboard.Key)))
            {
                keyStates[key] = false;
            }

            // Initialize mouse button states
            foreach (Mouse.Button button in System.Enum.GetValues(typeof(Mouse.Button)))
            {
                mouseButtonStates[button] = false;
            }

            // Register event handlers
            window.KeyPressed += OnKeyPressed;
            window.KeyReleased += OnKeyReleased;
            window.MouseButtonPressed += OnMouseButtonPressed;
            window.MouseButtonReleased += OnMouseButtonReleased;
        }

        public bool IsKeyPressed(Keyboard.Key key)
        {
            return keyStates[key];
        }

        public bool IsMouseButtonPressed(Mouse.Button button)
        {
            return mouseButtonStates[button];
        }

        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            keyStates[e.Code] = true;
        }

        private void OnKeyReleased(object sender, KeyEventArgs e)
        {
            keyStates[e.Code] = false;
        }

        private void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            mouseButtonStates[e.Button] = true;
        }

        private void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            mouseButtonStates[e.Button] = false;
        }
    }
}
