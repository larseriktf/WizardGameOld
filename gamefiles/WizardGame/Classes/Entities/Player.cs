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
    public class Player : Entity, IGameObjectModel
    {
        public int MoveSpeed { get; set; } = 10;
        public string BitMapUri { get; set; } = "ms-appx:///Assets/Sprites/Entities/Player/spr_player_sheet.png";


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
            throw new NotImplementedException();
        }
    }
}
