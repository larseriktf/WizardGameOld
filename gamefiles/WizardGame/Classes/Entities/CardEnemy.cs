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
        public string BitMapUri { get; set; } = "ms-appx:///Assets/Sprites/Entities/CardEnemy/spr_cards.png";
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

        private double angle = 0.5 * Math.PI;
        private double nextAngle = 0;

        CanvasDebugger.DebugMessage debugMessage = new CanvasDebugger.DebugMessage();

        public void DrawSelf(CanvasSpriteBatch spriteBatch)
        {
            int speed = 2;

            if (EntityManager.SingleEntityExists(typeof(CoordPoint)))
            {
                CoordPoint coordPoint = (CoordPoint)EntityManager.GetSingleEntity(typeof(CoordPoint));

                angle = EntityManager.GetAngleBetweenEntitiesInRadians(this, coordPoint);

                debugMessage.Message = "coordPoint.X: " + coordPoint.XPos + " coordPoint.Y: " + coordPoint.YPos;

                CanvasDebugger.Debug(debugMessage);

            }

            XPos += (float)(speed * Math.Cos(angle));
            YPos += (float)(speed * Math.Sin(angle));


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
