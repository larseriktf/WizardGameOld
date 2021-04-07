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
    public class Target : IEntityModel
    {
        public static string BitMapUri { get; set; } = "ms-appx:///Assets/Sprites/Dev/spr_point.jpg";
        public SpriteSheet Sprite { get; set; }

        public float XPos { get; set; } = 0;
        public float YPos { get; set; } = 0;

        public void DrawSelf(CanvasDrawingSession ds)
        {
            
            XPos = KeyBoard.PointerPosition.ToVector2().X;
            YPos = KeyBoard.PointerPosition.ToVector2().Y;

            CanvasDebugger.Debug(this, "Bruh");

            
        }
    }
}
