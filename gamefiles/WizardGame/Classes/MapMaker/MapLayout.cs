using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardGame.Classes.MapMaker
{
    public class MapLayout
    {
        public SpriteSheet SpriteSheet { get; set; }
        public List<List<int>> Layout { get; set; } // 2D list

        public MapLayout(SpriteSheet spriteSheet, List<List<int>> layout)
        {
            SpriteSheet = spriteSheet;
            Layout = layout;
        }
    }
}
