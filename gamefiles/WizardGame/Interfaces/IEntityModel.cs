using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Classes;

namespace WizardGame.Interfaces
{
    public interface IEntityModel
    {
        string BitMapUri { get; set; }
        CanvasBitmap BitMap { get; set; }

        // Coordinates
        float XPos { get; set; }
        float YPos { get; set; }

        void DrawSelf(CanvasSpriteBatch spriteBatch);
    }
}
