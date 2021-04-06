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
        public int[][] Layout { get; set; } // multidimensional array

        public CanvasBitmap BitMap { get; set; }
        public SpriteSheet Sprite { get; set; }

        public float XPos { get; set; } = 0;
        public float YPos { get; set; } = 0;

        public int ImageX { get; set; } = 0;
        public int ImageY { get; set; } = 0;
        public float XScale { get; set; } = 1f;
        public float YScale { get; set; } = 1f;

        public float Red { get; set; } = 1f;
        public float Green { get; set; } = 1f;
        public float Blue { get; set; } = 1f;
        public float Alpha { get; set; } = 1f;
        public string BitMapUri { get; set; }

        public MapLayout(SpriteSheet spriteSheet, int[][] layout)
        {
            Sprite = spriteSheet;
            Layout = layout;
        }

        public void DrawSelf(CanvasSpriteBatch spriteBatch)
        {
            for (int x = 0; x < Layout.Length; x++)
            {
                for (int y = 0; y < Layout[x].Length; y++)
                {
                    if (Layout[y][x] == 1)
                    {
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

        public void UpdateMovement()
        {
            
        }
    }
}
