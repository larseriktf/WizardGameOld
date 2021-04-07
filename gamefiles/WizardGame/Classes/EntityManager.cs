using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WizardGame.Classes.Entities;
using WizardGame.Interfaces;
using static System.Math;

namespace WizardGame.Classes
{
    public static class EntityManager
    {
        public static List<Layer> Layers { get; set; } = new List<Layer>();

        public static List<IEntityModel> gameEntities = new List<IEntityModel>();

        public static bool EntityExists(Type className)
        {   // Runs through list of entities and checks if they are of type className
            foreach (IEntityModel entity in gameEntities)
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
            foreach (IEntityModel entity in gameEntities)
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
            foreach (IEntityModel entity in gameEntities)
            {
                if (entity.GetType().Equals(className))
                {
                    return entity;
                }
            }
            return null;
        }

        

        public static double GetAngleBetweenEntitiesInRadians(IEntityModel objA, IEntityModel objB)
        {
            // Vector between objA and objB
            Vector2 a = new Vector2(objB.XPos - objA.XPos, objB.YPos - objA.YPos);

            // Horizontal right vector
            Vector2 b = new Vector2(1, 0);

            // Calculate angle (theta) in radians
            double angle = Acos(Vector2.Dot(a, b) / (Sqrt(Pow(a.X, 2) + Pow(a.Y, 2)) * Sqrt(Pow(b.X, 2) + Pow(b.Y, 2))));

            return angle;
        }
    }
}
