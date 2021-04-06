using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Classes.Entities;
using WizardGame.Interfaces;

namespace WizardGame.Classes
{
    public class Player :IGameObjectModel
    {
        public int MoveSpeed { get; set; } = 10;

        public string BitMapUri { get; set; } = "ms-appx:///Assets/Sprites/Entities/Player/spr_player.png";
        public CanvasBitmap BitMap { get; set; }
        public SpriteSheet Sprite { get; set; }

        public int XPos { get; set; } = 0;
        public int YPos { get; set; } = 0;

        public int ImageX { get; set; } = 0;
        public int ImageY { get; set; } = 0;
        public float XScale { get; set; } = 1f;
        public float YScale { get; set; } = 1f;

        public float Red { get; set; } = 1f;
        public float Green { get; set; } = 1f;
        public float Blue { get; set; } = 1f;
        public float Alpha { get; set; } = 1f;

        public void DrawSelf(CanvasSpriteBatch spriteBatch)
        {
            Sprite.DrawSpriteExt(
                spriteBatch,
                new Vector2(XPos, YPos),
                new Vector2(ImageX, ImageY),
                new Vector4(Red, Green, Blue, Alpha),
                0,
                new Vector2(XScale, YScale),
                0);
        }

        public void UpdateMovement()
        {
            if (KeyBoard.KeyLeft)
            {
                XPos -= MoveSpeed;
                XScale = -1f;
            }
            if (KeyBoard.KeyRight)
            {
                XPos += MoveSpeed;
                XScale = 1f;
            }
            if (KeyBoard.KeyUp)
            {
                YPos -= MoveSpeed;
            }
            if (KeyBoard.KeyDown)
            {
                YPos += MoveSpeed;
            }
        }
    }
}
