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
        public int[,] Layout { get; set; } // multidimensional array

        public MapLayout(SpriteSheet spriteSheet, int[,] layout)
        {
            SpriteSheet = spriteSheet;
            Layout = layout;
        }
    }
}
