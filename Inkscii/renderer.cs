using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Inkscii
{
    public class Renderer
    {
        private RenderWindow window;
        private Font font;
        private char[,] characterGrid;
        private Color[,] colorGrid;
        private int cellSize;

        public Renderer(RenderWindow window, int cellSize)
        {
            this.window = window;
            this.cellSize = cellSize;
            characterGrid = new char[window.Size.X / cellSize, window.Size.Y / cellSize];
            colorGrid = new Color[window.Size.X / cellSize, window.Size.Y / cellSize];
            

            // Load the font for rendering ASCII characters
            font = new Font("PublicPixel-z84yD.ttf"); // Replace with the path to your font file
            font.GetKerning(0, 0, 0);
            font.GetTexture(1).Smooth = false;
        }

        public void DrawCharacter(char character, Vector2i position, Color textColor, Color bgColor, int characterSize = 12)
        {
            int x = position.X;
            int y = position.Y;

            if (x < 0 || x >= characterGrid.GetLength(0) || y < 0 || y >= characterGrid.GetLength(1))
                return;

            characterGrid[x, y] = character;
            colorGrid[x, y] = bgColor;

            Text text = new Text(character.ToString(), font, (uint)characterSize); // Explicit cast to uint
            text.Position = new Vector2f(x * cellSize, y * cellSize);
            text.Color = textColor;

            window.Draw(text);
        }

        public void PrintLine(string text, Vector2i position, Color textColor, Color bgColor, int characterSize = 12)
        {
            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];
                DrawCharacter(character, new Vector2i(position.X + i, position.Y), textColor, bgColor, characterSize);
            }
        }

        public void Clear()
        {
            characterGrid = new char[window.Size.X / cellSize, window.Size.Y / cellSize];
            colorGrid = new Color[window.Size.X / cellSize, window.Size.Y / cellSize];
        }

        public void Render()
        {
            window.Clear(Color.Black);

            for (int x = 0; x < characterGrid.GetLength(0); x++)
            {
                for (int y = 0; y < characterGrid.GetLength(1); y++)
                {
                    char character = characterGrid[x, y];
                    Color bgColor = colorGrid[x, y];

                    RectangleShape background = new RectangleShape(new Vector2f(cellSize, cellSize));
                    background.Position = new Vector2f(x * cellSize, y * cellSize);
                    background.FillColor = bgColor;

                    window.Draw(background);

                    if (character != '\0')
                    {
                        Text text = new Text(character.ToString(), font, (uint)cellSize);
                        text.Position = new Vector2f(x * cellSize, y * cellSize);
                        text.Color = Color.White;
                        window.Draw(text);
                    }
                }
            }

            window.Display();
        }

        public void SetCharacterSize(int characterSize)
        {
            // Set the character size of the rendered text
            font.GetGlyph(characterGrid[0, 0], (uint)characterSize, false, cellSize);
        }

        public void SetFont(string fontFilePath)
        {
            font = new Font(fontFilePath);
        }
    }
}
