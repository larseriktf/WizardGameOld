using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace WizardGame.Classes
{

    public static class KeyBoard
    {
        public static bool KeyLeft { get; set; }
        public static bool KeyRight { get; set; }
        public static bool KeyUp { get; set; }
        public static bool KeyDown { get; set; }


        public static void UpdateKeys()
        {
            KeyLeft = Window.Current.CoreWindow.GetKeyState(VirtualKey.A).HasFlag(CoreVirtualKeyStates.Down);
            KeyRight = Window.Current.CoreWindow.GetKeyState(VirtualKey.D).HasFlag(CoreVirtualKeyStates.Down);
            KeyUp = Window.Current.CoreWindow.GetKeyState(VirtualKey.W).HasFlag(CoreVirtualKeyStates.Down);
            KeyDown = Window.Current.CoreWindow.GetKeyState(VirtualKey.S).HasFlag(CoreVirtualKeyStates.Down);
        }
    }
}
