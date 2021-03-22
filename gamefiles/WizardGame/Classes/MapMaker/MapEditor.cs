using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardGame.Classes
{
    public static class MapEditor
    {

        public static async Task MakeMapsAsync(CanvasAnimatedControl sender)
        {
            // map 1
            player.Sprite = await SpriteSheet.LoadSpriteSheetAsync(sender.Device, player.BitMapUri, new Vector2(96, 96));
        }
    }
}
