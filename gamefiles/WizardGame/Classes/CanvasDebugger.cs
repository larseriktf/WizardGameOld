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
        private static int xIndent = 25;
        private static int yIndent = 25;
        public static List<string> Messages { get; set; } = new List<string>();

        public static void DrawMessages(CanvasDrawingSession ds)
        {
            ds.DrawText("Canvas Debugger", xIndent, yIndent, Colors.White);
            ds.DrawText("---------------", xIndent, yIndent * 2, Colors.White);

            for (int i = 0; i < Messages.Count(); i++)
            {
                ds.DrawText(Messages[i], xIndent, yIndent * (i + 3), Colors.White);
            }
        }

        public static void DebugMessage(string message)
        {
            if (!Messages.Contains(message)) Messages.Add(message);
        }
    }
}
