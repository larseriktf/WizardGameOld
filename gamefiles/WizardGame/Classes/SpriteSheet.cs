using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System.Numerics;
using System.Threading.Tasks;
using Windows.Foundation;
using System;

namespace WizardGame.Classes
{
    public class SpriteSheet
    {
        private readonly CanvasBitmap bitmap;

        public Vector2 SpriteSize { get; set; }

        public SpriteSheet(CanvasBitmap bitmap, Vector2 spriteSize)
        {
            this.bitmap = bitmap;
            SpriteSize = spriteSize;

            // spritesPerRow = (int)(bitmap.Size.Width / spriteSize.X);
        }


        public static async Task<SpriteSheet> LoadSpriteSheetAsync(CanvasDevice device, string fileName, Vector2 spriteSize)
        {
            return new SpriteSheet(await CanvasBitmap.LoadAsync(device, new Uri(fileName)), spriteSize);
        }

        public void DrawSprite(CanvasSpriteBatch spriteBatch, int x, int y, int imageX, int imageY) // , CanvasBitmap bitmap
        {
            spriteBatch.DrawFromSpriteSheet(
                bitmap,
                new Rect(x, y, SpriteSize.X, SpriteSize.Y),
                new Rect(imageX * SpriteSize.X, imageY * SpriteSize.Y, SpriteSize.X, SpriteSize.Y));
        }
    }
}