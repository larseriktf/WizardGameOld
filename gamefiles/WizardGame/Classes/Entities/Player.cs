﻿using Microsoft.Graphics.Canvas;
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
    public class Player : SpriteEntity, IDrawable
    {
        public int MoveSpeed { get; set; } = 10;

        public static readonly string bitMapUri = "ms-appx:///Assets/Sprites/Entities/Player/spr_player.png";
        public static readonly int spriteWidth = 96;
        public static readonly int spriteHeight = 96;
        
        public void DrawSelf(CanvasDrawingSession ds)
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

            using (var spriteBatch = ds.CreateSpriteBatch())
            {
                if (Sprite != null)
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
            }
        }
    }
}
