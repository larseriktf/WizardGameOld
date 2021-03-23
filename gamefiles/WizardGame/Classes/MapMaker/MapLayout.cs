using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Interfaces;

namespace WizardGame.Classes.MapMaker
{
    public class MapLayout : IGameObjectModel
    {
        public SpriteSheet Sprite { get; set; }
        public int[][] Layout { get; set; } // multidimensional array

        public MapLayout(SpriteSheet spriteSheet, int[][] layout)
        {
            Sprite = spriteSheet;
            Layout = layout;
        }

        public void DrawSelf(CanvasSpriteBatch spriteBatch)
        {
            for (int y = 0; y < Layout.Length; y++)
            {
                for (int x = 0; x < Layout[y].Length; x++)
                {
                    int hey = Layout[x][y];

                    Sprite.DrawSpriteExt(
                        spriteBatch,
                        new Vector2(x * 128, y * 128),
                        new Vector2(0, 0),
                        new Vector4(1, 1, 1, 1),
                        0,
                        new Vector2(1, 1),
                        0);
                }
            }
        }
    }
}
