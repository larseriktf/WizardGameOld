using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace WizardGame.Classes
{
    public static class CanvasDebugger
    {
        public static List<string> Messages { get; set; } = new List<string>();

        public static void DrawMessages(CanvasDrawingSession ds)
        {
            for (int i = 0; i < Messages.Count(); i++)
            {
                ds.DrawText(Messages[i], 50, 50 * (i + 1), Colors.White);
            }
        }

        public static void DebugMessage(string message)
        {
            if (!Messages.Contains(message)) Messages.Add(message);
        }
    }
}
