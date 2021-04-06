using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Interfaces;

namespace WizardGame.Classes.Entities
{
    public class CardEnemy : IGameObjectModel
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

        public void DrawSelf(CanvasSpriteBatch spriteBatch)
        {
            int speed = 2;


            if (EntityManager.SingleEntityExists(typeof(CoordPoint)))
            {
                CoordPoint coordPoint = (CoordPoint)EntityManager.GetSingleEntity(typeof(CoordPoint));

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

        public void UpdateMovement()
        {
            // New x = cos Theta
            // new y = sin Theta
            // Length: |A| = \sqrt{ AcosTheta^2 + AsinTheta^2 }
            // Theta = tan^(-1) | AcosTheta / AsinTheta |
        }
    }
}
