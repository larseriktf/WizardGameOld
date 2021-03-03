using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardGame.Classes
{
    class Scaling
    {
        public float scaleWidth { get; set; }
        public float scaleHeight { get; set; }

        public static void SetScale()
        {
            // Display Information
        }

        public static Transform2DEffect BitmapToImage(CanvasBitMap bitmap)
        {
            return new Transform2DEffect() { Source = (Windows.Graphics.Effects.IGraphicsEffectSource)bitmap };
        }
    }
}
