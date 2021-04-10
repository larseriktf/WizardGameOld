using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using WizardGame.Interfaces;
using static System.Math;

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

        private float originalX = 0;
        private float originalY = 0;
        private Vector3 f1 = new Vector3(); // X = A, Y = B, Z = C
        private Vector3 f2 = new Vector3();
        private float incrementY = 0.15f;
        private float incrementX = 0.1f;
        private float valueY = 0;
        private float valueX = 0;
        private float threshold = 75;

        public void DrawSelf(CanvasDrawingSession ds)
        {
            if (originalX == 0 && originalX == 0)
            {
                originalX = XPos;
                originalY = YPos;
            }

            f1.X = 0;
            f1.Y = 1;
            f1.Z = originalY + (float)(threshold * Sin(valueY));

            f2.X = 1;
            f2.Y = 0;
            f2.Z = originalX + (float)(threshold * Sin(valueX));

            valueY += incrementY;
            valueX += incrementX;

            float delta = f1.X * f2.Y - f2.X * f1.Y;

            float x = (f2.Y * f1.Z - f1.Y * f2.Z) / delta;
            float y = (f1.X * f2.Z - f2.X * f1.Z) / delta;

            XPos = x;
            YPos = y;

            if (BitMap != null)
            {
                //ds.DrawImage(BitMap, XPos - 4, YPos - 4);
            }
        }
    }
}
