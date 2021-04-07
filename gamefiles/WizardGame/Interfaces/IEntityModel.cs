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
        // Coordinates
        float XPos { get; set; }
        float YPos { get; set; }
        void DrawSelf(CanvasDrawingSession ds);
    }
}
