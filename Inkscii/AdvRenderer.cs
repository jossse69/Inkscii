using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Inkscii
{
    public class AdvRenderer : Renderer
    {
        public AdvRenderer(RenderWindow window, int cellSize) : base(window, cellSize)
        {
        }

        public void DrawRectangle(Vector2i position, int width, int height, char character, Color textColor, Color bgColor, bool filled = true)
        {
            int startX = position.X;
            int startY = position.Y;

            for (int y = startY; y < startY + height; y++)
            {
                for (int x = startX; x < startX + width; x++)
                {
                    if (filled || y == startY || y == startY + height - 1 || x == startX || x == startX + width - 1)
                    {
                        DrawCharacter(character, new Vector2i(x, y), textColor, bgColor);
                    }
                }
            }
        }

        public void DrawCircle(Vector2i center, int radius, char character, Color textColor, Color bgColor, bool filled = true)
        {
            int startX = center.X - radius;
            int startY = center.Y - radius;

            for (int y = startY; y <= startY + radius * 2; y++)
            {
                for (int x = startX; x <= startX + radius * 2; x++)
                {
                    float distanceSquared = (center.X - x) * (center.X - x) + (center.Y - y) * (center.Y - y);

                    if (distanceSquared <= radius * radius)
                    {
                        if (filled || MathF.Abs(distanceSquared - radius * radius) < radius)
                        {
                            DrawCharacter(character, new Vector2i(x, y), textColor, bgColor);
                        }
                    }
                }
            }
        }
    }
}
