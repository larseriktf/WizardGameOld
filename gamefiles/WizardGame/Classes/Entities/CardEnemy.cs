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
        private double targetAngle = 0;
        private double turningSpeed = 0;
        private double wiggleRoom = 0.5;
        private double dist = 0;
        private double amplifier = 0;
        private double lagAngle = 0;
        private double threshold = 0;
        
        // For debugging
        public static double Angle = 0;
        public static double TargetAngle = 0;
        public static double LagAngle = 0;

        public async void LoadImageResourceAsync(CanvasDevice device)
        {
            Sprite = await SpriteSheet.LoadSpriteSheetAsync(device, BitMapUri, new Vector2(spriteWidth, spriteHeight));
        }

        public void DrawSelf(CanvasDrawingSession ds)
        {
            Target target = (Target)EntityManager.GetNearestEntity(this, typeof(Target));
            targetAngle = EntityManager.GetAngleBetweenEntitiesInRadians(this, target);

            dist = EntityManager.GetDistanceBetweenEntities(this, target);

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
            if (lagAngle >= 2 * PI + targetAngle)
            {
                lagAngle -= 2 * PI;
            }
            else if (lagAngle < 0 + targetAngle)
            {
                lagAngle += 2 * PI;
            }

            // Use of range
            int minLength = 200;
            int maxLength = 250;

            if (dist < maxLength)
            {
                threshold = (PI * 0.5) * ((dist - minLength) / (maxLength - minLength));
            }

            if (lagAngle > PI + targetAngle && lagAngle < PI + targetAngle + threshold)
            {
                lagAngle = PI + targetAngle + threshold;
            }
            if (lagAngle < PI + targetAngle && lagAngle > PI + targetAngle - threshold)
            {
                lagAngle = PI + targetAngle - threshold;
            }

            turningSpeed = 0.05 * (EntityManager.GetCrossProductOfTwoVectors(
                                new Vector2((float)Cos(lagAngle), (float)Sin(lagAngle)),
                                new Vector2((float)Cos(targetAngle), (float)Sin(targetAngle))));

            wiggleRoom += 0.08;

                
            //if (dist < 100)
            //{
            //    amplifier = ((dist - 100) / (0 - 100));
            //}
            //else
            //{
            //    amplifier = 0;
            //}

            angle += turningSpeed * 2.25 + Sin(wiggleRoom) * 0.025; 

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
