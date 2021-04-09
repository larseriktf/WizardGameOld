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
using static System.Math;

namespace WizardGame.Classes
{
    public static class CanvasDebugger
    {
        private static readonly int xIndent = 25;
        private static readonly int yIndent = 25;
        public static Dictionary<object, string> DebugMessages { get; set; } = new Dictionary<object, string>();

        public static void DrawMessages(CanvasDrawingSession ds)
        {
            if (DebugMessages.Count() > 0)
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


        public static Entity objA { get; set; } = null;
        public static Entity objB { get; set; } = null;
        private static int length = 128;
        public static void TestDrawing(CanvasDrawingSession ds)
        {
            if (objA != null && objB != null)
            {

                // Card velocity vector
                ds.DrawLine(
                    objA.XPos,
                    objA.YPos,
                    objA.XPos + ((float)Math.Cos(CardEnemy.Angle) * length),
                    objA.YPos + ((float)Math.Sin(CardEnemy.Angle) * length),
                    Colors.Blue);

                // Vector that lags behind
                double dist = EntityManager.GetDistanceBetweenEntities(objA, objB);

                // Old: double lagAngle = CardEnemy.Angle * (1 + ((CardEnemy.Angle - (2 * PI)/3) / (PI - (2 * PI) / 3)) * 0.25);
                double lagAngle = CardEnemy.Angle;

                // Keep angle inside bounderies of [0, 2PI>
                if (lagAngle >= 2 * PI + CardEnemy.NextAngle)
                {
                    lagAngle -= 2 * PI;
                }
                else if (lagAngle < 0 + CardEnemy.NextAngle)
                {
                    lagAngle += 2 * PI;
                }

                // Use of range
                double threshold = 1.25 * (dist / 300);

                if (lagAngle > PI + CardEnemy.NextAngle && lagAngle < PI + CardEnemy.NextAngle + threshold)
                {
                    lagAngle = PI + CardEnemy.NextAngle + threshold;
                }
                if (lagAngle < PI + CardEnemy.NextAngle && lagAngle > PI + CardEnemy.NextAngle - threshold)
                {
                    lagAngle = PI + CardEnemy.NextAngle - threshold;
                }

                ds.DrawText((lagAngle - CardEnemy.NextAngle).ToString(), 250, 50, Colors.Yellow);


                ds.DrawLine(
                    objA.XPos,
                    objA.YPos,
                    objA.XPos + ((float)Math.Cos(lagAngle) * length),
                    objA.YPos + ((float)Math.Sin(lagAngle) * length),
                    Colors.Green);

                // Vector towards target
                ds.DrawLine(
                    objA.XPos,
                    objA.YPos,
                    objA.XPos + ((float)Math.Cos(CardEnemy.NextAngle) * length),
                    objA.YPos + ((float)Math.Sin(CardEnemy.NextAngle) * length),
                    Colors.Red);
            }

            
        }
    }
}
