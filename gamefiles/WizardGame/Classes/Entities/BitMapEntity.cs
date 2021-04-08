using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardGame.Classes.Entities
{
    public abstract class BitMapEntity : Entity
    {
        public static readonly string bitMapUri = "ms-appx:///Assets/Sprites/Dev/spr_point.jpg";
        public static CanvasBitmap BitMap { get; set; } = null;
    }
}
