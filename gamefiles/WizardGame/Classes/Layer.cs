using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Classes.Entities;
using WizardGame.Interfaces;

namespace WizardGame.Classes
{
    public class Layer
    {
        public string Name { get; set; }
        public List<IEntityModel> GameObjects { get; set; } = new List<IEntityModel>();

        public Layer(string name)
        {
            Name = name;
        }
    }
}
