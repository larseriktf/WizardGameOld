﻿using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Interfaces;
using static System.Math;

namespace WizardGame.Classes.Entities
{
    public class CardEnemy : SpriteEntity, IDrawable
    {
        public static readonly string bitMapUri = "ms-appx:///Assets/Sprites/Entities/CardEnemy/spr_cards.png";
        public static readonly int spriteWidth = 24;
        public static readonly int spriteHeight = 24;

        private double speed = 8;
        private double angle = 0.5 * Math.PI;
        private double nextAngle = 0;
        private double turningSpeed = 0;
        private double wiggleRoom = 0.5;
        private double distanceToPoint = 0;
        private double amplifier = 0.025;

        public static double Angle = 0;
        public static double NextAngle = 0;

        public void DrawSelf(CanvasDrawingSession ds)
        {
            if (EntityManager.SingleEntityExists(typeof(Target)))
            {
                Target coordPoint = (Target)EntityManager.GetSingleEntity(typeof(Target));

                nextAngle = EntityManager.GetAngleBetweenEntitiesInRadians(this, coordPoint);

                turningSpeed = 0.05 * (EntityManager.GetCrossProductOfTwoVectors(
                                    new Vector2((float)Cos(angle), (float)Sin(angle)),
                                    new Vector2((float)Cos(nextAngle), (float)Sin(nextAngle))));

                angle += turningSpeed + Sin(wiggleRoom) * 0.025;

                Angle = angle;


                wiggleRoom += 0.08;
                
                NextAngle = nextAngle;

                distanceToPoint = EntityManager.GetDistanceBetweenEntities(this, coordPoint);

                if (distanceToPoint < 300)
                {
                    amplifier = 0.5 * (distanceToPoint / 300);
                }

                CanvasDebugger.objA = this;
                CanvasDebugger.objB = coordPoint;
                CanvasDebugger.Debug(this, "Angle: " + angle
                                    + "\nNextAngle: " + nextAngle
                                    + "\nWiggleRoom: " + Sin(wiggleRoom)
                                    + "\nDistance: " + distanceToPoint);
            }

            XPos += (float)(speed * Cos(angle));
            YPos += (float)(speed * Sin(angle));

            using (var spriteBatch = ds.CreateSpriteBatch())
            {
                if (Sprite != null)
                {
                    Sprite.DrawSpriteExt(
                    spriteBatch,
                    new Vector2(XPos, YPos),
                    new Vector2(ImageX, ImageY),
                    new Vector4(Red, Green, Blue, Alpha),
                    (float)(angle - 0.5 * Math.PI),
                    new Vector2(XScale, YScale),
                    0);
                }
            }
        }
    }
}
