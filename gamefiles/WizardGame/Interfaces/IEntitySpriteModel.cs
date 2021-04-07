using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Classes;

namespace WizardGame.Interfaces
{
    public interface IEntitySpriteModel : IEntityModel
    {
        // Coordinates
        int ImageX { get; set; }
        int ImageY { get; set; }

        // Scaling
        float XScale { get; set; }
        float YScale { get; set; }

        // Tint
        float Red { get; set; }
        float Green { get; set; }
        float Blue { get; set; }
        float Alpha { get; set; }
    }
}
