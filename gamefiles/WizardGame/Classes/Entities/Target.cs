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
    public class Target : Entity, IDrawable
    {
        public CanvasBitmap BitMap;
        public string BitMapUri { get; } = "ms-appx:///Assets/Sprites/Dev/spr_point.jpg";

        public async void LoadImageResourceAsync(CanvasDevice device)
        {
            BitMap = await CanvasBitmap.LoadAsync(device, new Uri(BitMapUri));
        }

        public void DrawSelf(CanvasDrawingSession ds)
        { 
            if (BitMap != null)
            {
                ds.DrawImage(BitMap, XPos - 4, YPos - 4);
            }
        }
    }
}
