using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Classes.Entities;
using WizardGame.Interfaces;

namespace WizardGame.Classes
{
    public static class EntityManager
    {
        public static List<Layer> Layers { get; set; } = new List<Layer>();

        public static List<IGameObjectModel> gameEntities = new List<IGameObjectModel>();

        public static bool EntityExists(Type className)
        {   // Runs through list of entities and checks if they are of type className
            foreach (IGameObjectModel entity in gameEntities)
            {
                if (entity.GetType().Equals(className))
                {   
                    return true;
                }
            }
            return false;
        }

        public static bool SingleEntityExists(Type className)
        {
            int occurrences = 0;
            foreach (IGameObjectModel entity in gameEntities)
            {
                if (entity.GetType().Equals(className))
                {
                    occurrences++;
                }
            }
            if (occurrences == 1) return true;
            return false;
        }

        public static Object GetSingleEntity(Type className)
        {
            foreach (IGameObjectModel entity in gameEntities)
            {
                if (entity.GetType().Equals(className))
                {
                    return entity;
                }
            }
            return null;
        }
    }
}
