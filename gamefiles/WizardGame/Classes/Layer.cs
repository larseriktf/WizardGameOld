using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Classes.Entities;

namespace WizardGame.Classes
{
    public class Layer
    {
        public string Name { get; set; }
        public List<Entity> Entities { get; set; } = new List<Entity>();

        public Layer(string name)
        {
            Name = name;
        }
    }
}
