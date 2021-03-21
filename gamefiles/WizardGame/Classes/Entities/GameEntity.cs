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
        public int XOffset { get; set; } = 0;
        public int YOffset { get; set; } = 0;
    }
}
