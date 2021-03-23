using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WizardGame.Classes.Entities
{
    public abstract class Entity : GameObject
    {
        public CanvasBitmap BitMap { get; set; }
        public SpriteSheet Sprite { get; set; }

        // Coordinates
        public int XPos { get; set; } = 0;
        public int YPos { get; set; } = 0;
        public int ImageX { get; set; } = 0;
        public int ImageY { get; set; } = 0;

        // Scaling
        public float XScale { get; set; } = 1f;
        public float YScale { get; set; } = 1f;

        // Tint
        public float Red { get; set; } = 1f;
        public float Green { get; set; } = 1f;
        public float Blue { get; set; } = 1f;
        public float Alpha { get; set; } = 1f;
    }
}
