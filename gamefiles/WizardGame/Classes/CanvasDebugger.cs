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
        public static List<DebugMessage> Messages { get; set; } = new List<DebugMessage>();

        public static void DrawMessages(CanvasDrawingSession ds)
        {
            ds.DrawText("Canvas Debugger", xIndent, yIndent, Colors.White);
            ds.DrawText("---------------", xIndent, yIndent * 2, Colors.White);

            for (int i = 0; i < Messages.Count(); i++)
            {
                ds.DrawText(Messages[i].Message, xIndent, yIndent * (i + 3), Colors.White);
            }
        }

        public static void Debug(DebugMessage message)
        {
            if (!Messages.Contains(message)) Messages.Add(message);
        }

        public class DebugMessage
        {
            public string Message { get; set; }
        }
    }
}
