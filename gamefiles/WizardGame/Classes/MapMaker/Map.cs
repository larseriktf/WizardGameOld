using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Classes.MapMaker;
using WizardGame.Interfaces;

namespace WizardGame.Classes
{
    public class Map : IGameObjectModel
    {
        public List<MapLayout> MapLayouts { get; set; }

        public Map(List<MapLayout> mapLayouts)
        {
            MapLayouts = mapLayouts;
        }

        public void DrawSelf(CanvasSpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
