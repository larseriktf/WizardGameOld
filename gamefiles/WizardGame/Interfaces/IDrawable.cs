using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardGame.Interfaces
{
    public interface IDrawable
    {
        void DrawSelf(CanvasDrawingSession ds);
    }
}
