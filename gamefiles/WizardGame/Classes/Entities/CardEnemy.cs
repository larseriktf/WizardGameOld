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
    public class CardEnemy : IEntitySpriteModel
    {
        public static readonly string bitMapUri = "ms-appx:///Assets/Sprites/Entities/CardEnemy/spr_cards.png";
        public static readonly int spriteWidth = 24;
        public static readonly int spriteHeight = 24;
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

        private double speed = 1;
        private double angle = 0.5 * Math.PI;
        private double nextAngle = 0;
        private double turningSpeed = 0.01;
        private double lag = 10;

        public void DrawSelf(CanvasDrawingSession ds)
        {
            if (EntityManager.SingleEntityExists(typeof(Target)))
            {
                Target coordPoint = (Target)EntityManager.GetSingleEntity(typeof(Target));

                angle = EntityManager.GetAngleBetweenEntitiesInRadians(this, coordPoint);

                //angle = nextAngle - lag;

                //if (angle > Math.PI * 2)
                //{
                //    angle = 0;
                //}

                //if (nextAngle > angle)
                //{
                    
                //    angle += turningSpeed;
                //}
                //else
                //{
                //    angle -= turningSpeed;
                //}

                CanvasDebugger.objA = this;
                CanvasDebugger.objB = coordPoint;

                CanvasDebugger.Debug(this, "coordPoint.X: " + coordPoint.XPos + " coordPoint.Y: " + coordPoint.YPos + "Angle: " + angle);
            }

            XPos += (float)(speed * Math.Cos(angle));
            YPos += (float)(speed * Math.Sin(angle));

            using (var spriteBatch = ds.CreateSpriteBatch())
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
