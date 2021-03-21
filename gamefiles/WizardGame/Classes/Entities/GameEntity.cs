using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardGame.Classes.Entities
{
    public class GameEntity
    {
        public CanvasBitmap BitMap { get; set; }
        public SpriteSheet Sprite { get; set; }
        public int XPos { get; set; } = 0;
        public int YPos { get; set; } = 0;
        public int ImageX { get; set; } = 0;
        public int ImageY { get; set; } = 0;
    }
}
