using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardGame.Classes
{
    public class Player
    {
        public int MoveSpeed { get; set; } = 10;
        public int XOffset { get; set; } = 0;
        public int YOffset { get; set; } = 0;

        public string BitMapUri { get; set; } = "";
    }
}
