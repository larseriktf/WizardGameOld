using Microsoft.Graphics.Canvas;
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
    public class CardEnemy : Entity, IDrawable
    {
        public string BitMapUri { get; } = "ms-appx:///Assets/Sprites/Entities/CardEnemy/spr_cards.png";
        public readonly int spriteWidth = 24;
        public readonly int spriteHeight = 24;

        private double speed = 8;
        private double angle = 0.5 * Math.PI;
        private double nextAngle = 0;
        private double turningSpeed = 0;
        private double wiggleRoom = 0.5;
        private double dist = 0;
        private double amplifier = 0;
        private double lagAngle = 0;
        private double threshold = 0;

        public static double Angle = 0;
        public static double NextAngle = 0;
        public static double LagAngle = 0;

        public async void LoadImageResourceAsync(CanvasDevice device)
        {
            Sprite = await SpriteSheet.LoadSpriteSheetAsync(device, BitMapUri, new Vector2(spriteWidth, spriteHeight));
        }

        public void DrawSelf(CanvasDrawingSession ds)
        {
            if (EntityManager.SingleEntityExists(typeof(Target)))
            {
                Target coordPoint = (Target)EntityManager.GetSingleEntity(typeof(Target));

                nextAngle = EntityManager.GetAngleBetweenEntitiesInRadians(this, coordPoint);

                

                dist = EntityManager.GetDistanceBetweenEntities(this, coordPoint);

                //if (KeyBoard.KeyLeft)
                //{
                //    XPos -= 2f;
                //}
                //if (KeyBoard.KeyRight)
                //{
                //    XPos += 2f;
                //}
                //if (KeyBoard.KeyUp)
                //{
                //    YPos -= 2f;
                //}
                //if (KeyBoard.KeyDown)
                //{
                //    YPos += 2f;
                //}

                //if (KeyBoard.KeyIncrementVector)
                //{
                //    angle += 0.025;
                //}
                //if (KeyBoard.KeyDecrementVector)
                //{
                //    angle -= 0.025;
                //}

                // Keep angle inside bounderies of [0, 2PI>
                if (angle >= 2 * PI)
                {
                    angle -= 2 * PI;
                }
                else if (angle < 0)
                {
                    angle += 2 * PI;
                }

                lagAngle = angle;

                // Keep lag angle inside bounderies of [0, 2PI>
                if (lagAngle >= 2 * PI + nextAngle)
                {
                    lagAngle -= 2 * PI;
                }
                else if (lagAngle < 0 + nextAngle)
                {
                    lagAngle += 2 * PI;
                }

                // Use of range
                if (dist < 300)
                {
                    threshold = (PI * 0.5) * ((dist - 250) / (300 - 250));
                }

                if (lagAngle > PI + nextAngle && lagAngle < PI + nextAngle + threshold)
                {
                    lagAngle = PI + nextAngle + threshold;
                }
                if (lagAngle < PI + nextAngle && lagAngle > PI + nextAngle - threshold)
                {
                    lagAngle = PI + nextAngle - threshold;
                }

                turningSpeed = 0.05 * (EntityManager.GetCrossProductOfTwoVectors(
                                    new Vector2((float)Cos(lagAngle), (float)Sin(lagAngle)),
                                    new Vector2((float)Cos(nextAngle), (float)Sin(nextAngle))));

                wiggleRoom += 0.08;

                
                if (dist < 100)
                {
                    amplifier = ((dist - 100) / (0 - 100));
                }
                else
                {
                    amplifier = 0;
                }

                angle += turningSpeed * 2 + Sin(wiggleRoom) * 0.025 * amplifier; 

                //Angle = angle;
                //NextAngle = nextAngle;
                //LagAngle = lagAngle;

                //CanvasDebugger.objA = this;
                //CanvasDebugger.objB = coordPoint;
                //CanvasDebugger.Debug(this, "Angle: " + angle
                //                    + "\nNextAngle: " + nextAngle
                //                    + "\nDistance: " + dist
                //                    + "\nAmplifier: " + amplifier
                //                    + "\nWiggleroom: " + Sin(wiggleRoom) * amplifier);
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
