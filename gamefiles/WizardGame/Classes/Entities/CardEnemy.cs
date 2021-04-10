﻿using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Windows.UI.Xaml;
using WizardGame.Interfaces;
using static System.Math;

namespace WizardGame.Classes.Entities
{
    public class CardEnemy : Entity, IDrawable
    {
        public string BitMapUri { get; } = "ms-appx:///Assets/Sprites/Entities/CardEnemy/spr_cards.png";
        public readonly int spriteWidth = 24;
        public readonly int spriteHeight = 24;

        private static readonly Random random = new Random();

        private readonly double speed = 6 + random.NextDouble() * 5;
        private double angle = random.NextDouble() * 2 * Math.PI;
        private double decidedAngle = 0;
        private double targetAngle = 0;
        private double lagAngle = 0;
        private double turningSpeed = 0;
        
        private double dist = 0;
        private double amplifier = 0;
        
        private double threshold = 0;
        private int state = 0; // 0: Guarding, 1: Chasing, 2: Dead

        private readonly double wiggleRate = random.NextDouble() * 0.1;
        private readonly double wiggleMultiplier = random.NextDouble() * 0.025;
        private double wiggle = random.NextDouble();

        // For debugging
        public static double Angle = 0;
        public static double TargetAngle = 0;
        public static double LagAngle = 0;

        Timer animTimer = null;
        Entity target;

        public async void LoadImageResourceAsync(CanvasDevice device)
        {
            Sprite = await SpriteSheet.LoadSpriteSheetAsync(device, BitMapUri, new Vector2(spriteWidth, spriteHeight));
        }

        public static void Spawner(float x, float y, int amount)
        {
            int min = -16;
            int max = 16;

            EntityManager.gameEntities.Add(new Target()
            {
                XPos = x,
                YPos = x
            });

            for (int i = 0; i < amount; i++)
            {
                EntityManager.gameEntities.Add(new CardEnemy()
                {
                    XPos = x + (float)random.NextDouble() * (max - min) + min,
                    YPos = y + (float)random.NextDouble() * (max - min) + min
                });
            }
        }

        public void DrawSelf(CanvasDrawingSession ds)
        {

            DetectStateChange();
            UpdateMovement();

            if (animTimer == null)
            {
                ImageX = random.Next(0, 3);

                animTimer = new Timer(random.Next(0, 2000));

                animTimer.Elapsed += delegate(object source, ElapsedEventArgs e)
                {   // Plays animation on timer tick
                    PlayAnimation();
                };
                animTimer.Start();
            }

            if (ImageX > 3)
            {
                ImageX = 0;
            }
            else if (ImageX < 0)
            {
                ImageX = 3;
            }

            if (ImageY > 3)
            {
                ImageY = 0;
            }
            else if (ImageY < 0)
            {
                ImageY = 3;
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
                    (float)(angle + 0.5 * PI),
                    new Vector2(XScale, YScale),
                    0);
                }
            }
        }

        private void DetectStateChange()
        {
            int prevState = 0;

            if (state != prevState)
            {
                PlayAnimation();
                prevState = state;
            }
        }

        private void PlayAnimation()
        {
            if (state == 0)
            {
                ImageY++;

                if (ImageY % 2 == 0)
                {   // Front / back of card
                    animTimer.Interval = random.Next(1000, 3000);
                }
                else
                {   // Card is in transition
                    animTimer.Interval = 50;
                }
            }
            else if (state == 1)
            {
                if (ImageY != 2)
                {   // Back side or mid transition
                    ImageY++;
                    animTimer.Interval = 50;
                }
            }
        }

        private void UpdateMovement()
        {
            int minLength = 200;
            int maxLength = 250;

            if (KeyBoard.ToggleTarget)
            {
                state = 1;
            }
            else
            {
                state = 0;
            }


            if (state == 0)
            {   // Guarding state
                target = EntityManager.GetNearestEntity(this, typeof(Target));
                targetAngle = EntityManager.GetAngleBetweenEntitiesInRadians(this, target);

                dist = EntityManager.GetDistanceBetweenEntities(this, target);

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

                // Range Threshold
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

                decidedAngle = lagAngle;
                amplifier = 2.25;

            }
            else if (state == 1)
            {   // Chasing state
                target = EntityManager.GetNearestEntity(this, typeof(Player));
                targetAngle = EntityManager.GetAngleBetweenEntitiesInRadians(this, target);

                decidedAngle = angle;
                amplifier = 2.0;
            }

            // Keep angle inside bounderies of [0, 2PI>
            if (angle >= 2 * PI)
            {
                angle -= 2 * PI;
            }
            else if (angle < 0)
            {
                angle += 2 * PI;
            }

            turningSpeed = 0.05 * (EntityManager.GetCrossProductOfTwoVectors(
                                    new Vector2((float)Cos(decidedAngle), (float)Sin(decidedAngle)),
                                    new Vector2((float)Cos(targetAngle), (float)Sin(targetAngle))));
            wiggle += wiggleRate;

            angle += turningSpeed * amplifier + Sin(wiggle) * wiggleMultiplier;

            //// Debug
            //Angle = angle;
            //TargetAngle = targetAngle;
            //LagAngle = lagAngle;

            //CanvasDebugger.objA = this;
            //CanvasDebugger.objB = target;
            //CanvasDebugger.Debug(this, "Angle: " + angle
            //                    + "\nNextAngle: " + TargetAngle
            //                    + "\nDistance: " + dist
            //                    + "\nAmplifier: " + amplifier
            //                    + "\nWiggleroom: " + Sin(wiggle));

            XPos += (float)(speed * Cos(angle));
            YPos += (float)(speed * Sin(angle));
        }
    }
}
