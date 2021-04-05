using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Interfaces;

namespace WizardGame.Classes.Entities
{
    public class CardEnemy : Entity, IGameObjectModel
    {
        public string BitMapUri { get; set; } = "ms-appx:///Assets/Sprites/Entities/CardEnemy/spr_cards.png";
    }
}
