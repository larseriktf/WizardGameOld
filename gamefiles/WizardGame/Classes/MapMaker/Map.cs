using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Classes.MapMaker;

namespace WizardGame.Classes
{
    public class Map : GameObject
    {
        public List<MapLayout> MapLayouts { get; set; }

        public Map(List<MapLayout> mapLayouts)
        {
            MapLayouts = mapLayouts;
        }
    }
}
