﻿using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Classes.Entities;

namespace WizardGame.Classes
{
    public class Player : Entity
    {
        public int MoveSpeed { get; set; } = 10;
        public string BitMapUri { get; set; } = "ms-appx:///Assets/Sprites/Player/spr_player_sheet.png";
        
    }
}
