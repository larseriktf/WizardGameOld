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
    public class Target : BitMapEntity, IDrawable
    {
        public void DrawSelf(CanvasDrawingSession ds)
        { 
            if (BitMap != null)
            {
                ds.DrawImage(BitMap, XPos - 4, YPos - 4);
            }
        }
    }
}
