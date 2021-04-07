using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using WizardGame.Classes.Entities;
using WizardGame.Interfaces;

namespace WizardGame.Classes
{
    public static class CanvasDebugger
    {
        private static readonly int xIndent = 25;
        private static readonly int yIndent = 25;
        public static List<string> Messages { get; set; } = new List<string>();
        public static Dictionary<object, string> DebugMessages { get; set; } = new Dictionary<object, string>();

        public static void DrawMessages(CanvasDrawingSession ds)
        {
            ds.DrawText("Canvas Debugger", xIndent, yIndent, Colors.White);
            ds.DrawText("---------------", xIndent, yIndent * 2, Colors.White);

            int i = 0;
            foreach (KeyValuePair<object, string> message in DebugMessages)
            {
                ds.DrawText(message.Value, xIndent, yIndent * (i + 3), Colors.White);
                i++;
            }
        }

        public static void Debug(object obj, string message)
        {
            if (!DebugMessages.ContainsKey(obj))
            {
                DebugMessages.Add(obj, message);
            }
            else
            {
                DebugMessages[obj] = message;
            }
        }


        public static IEntityModel objA { get; set; } = null;
        public static IEntityModel objB { get; set; } = null;
        private static int length = 128;
        public static void TestDrawing(CanvasDrawingSession ds)
        {
            if (objA != null && objB != null)
            {
                // Previous vector
                //ds.DrawLine(objA.XPos, objA.YPos, objB.XPos, objB.YPos, Colors.Yellow);
                //ds.DrawLine(objA.XPos, objA.YPos, objB.XPos, objA.YPos, Colors.Yellow);

                ds.DrawLine(
                    objA.XPos,
                    objA.YPos,
                    objA.XPos + ((float)Math.Cos(CardEnemy.Angle) * length),
                    objA.YPos + ((float)Math.Sin(CardEnemy.Angle) * length),
                    Colors.Yellow);

                ds.DrawLine(
                    objA.XPos,
                    objA.YPos,
                    objA.XPos + ((float)Math.Cos(CardEnemy.NextAngle) * length),
                    objA.YPos + ((float)Math.Sin(CardEnemy.NextAngle) * length),
                    Colors.Yellow);
            }

            
        }

        //public static double GetAngleBetweenEntitiesInRadians(IEntityModel objA, IEntityModel objB)
        //{
        //    // Vector between objA and objB
        //    Vector2 a = new Vector2(objB.XPos - objA.XPos, objB.YPos - objA.YPos);

        //    // Horizontal right vector
        //    Vector2 b = new Vector2(1, 0);

        //    // Calculate angle (theta) in radians
        //    double angle = Acos(Vector2.Dot(a, b) / (Sqrt(Pow(a.X, 2) + Pow(a.Y, 2)) * Sqrt(Pow(b.X, 2) + Pow(b.Y, 2))));

        //    return angle;
        //}
    }
}
