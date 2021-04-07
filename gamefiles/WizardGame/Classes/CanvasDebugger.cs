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
        private static readonly int xIndent = 25;
        private static readonly int yIndent = 25;
        public static List<string> Messages { get; set; } = new List<string>();
        public static Dictionary<object, string> DebugMessages { get; set; } = new Dictionary<object, string>();

        public static void DrawMessages(CanvasDrawingSession ds)
        {
            ds.DrawText("Canvas Debugger", xIndent, yIndent, Colors.White);
            ds.DrawText("---------------", xIndent, yIndent * 2, Colors.White);

            //for (int i = 0; i < Messages.Count(); i++)
            //{
            //    ds.DrawText(Messages[i], xIndent, yIndent * (i + 3), Colors.White);
            //}
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

            //if (!Messages.Contains(message))
            //{
            //    Messages.Clear();
            //    Messages.Add(message);
            //}
        }
    }
}
