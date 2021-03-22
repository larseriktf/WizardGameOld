using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using System.Numerics;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using Windows.System;
using Windows.UI.Core;
using WizardGame.Classes;
using Microsoft.Graphics.Canvas.UI.Xaml;
using WizardGame.Classes.Entities;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WizardGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        readonly DispatcherTimer gameTimer = new DispatcherTimer();
        readonly Player player = new Player();
        

        public MainPage()
        {
            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(16);
            gameTimer.Start();

            InitializeComponent();
        }

        private void GameTimerEvent(object sender, object e)
        {   // Every tick
            TrackKeyboard();
        }

        private void TrackKeyboard()
        {
            KeyBoard.UpdateKeys();

            if (KeyBoard.KeyLeft)
            {
                player.XPos -= player.MoveSpeed;
                player.XScale = -1f;
            }
            if (KeyBoard.KeyRight)
            {
                player.XPos += player.MoveSpeed;
                player.XScale = 1f;
            }
            if (KeyBoard.KeyUp) player.YPos -= player.MoveSpeed;
            if (KeyBoard.KeyDown) player.YPos += player.MoveSpeed;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        void OnUnloaded(object sender, RoutedEventArgs e)
        {   // Best practice: Prevent simple memory leak
            this.canvas.RemoveFromVisualTree();
            this.canvas = null;
        }

        private void OnCreateResources(CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {   // Creates Resources once
            // Load Images
            args.TrackAsyncAction(LoadImagesAsync(sender).AsAsyncAction());
            args.TrackAsyncAction(MapEditor.MakeMapsAsync(sender).AsAsyncAction());

            // Add entities
            AddEntities();
        }

        private void AddEntities()
        {
            Layer layer1 = new Layer("layer1");

            layer1.Entities.Add(player);

            LayerManager.Layers.Add(layer1);
        }

        async Task LoadImagesAsync(CanvasAnimatedControl sender)
        {   // Loads images and spritesheets
            player.Sprite = await SpriteSheet.LoadSpriteSheetAsync(sender.Device, player.BitMapUri, new Vector2(96, 96));
        }

        private void OnDraw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            var ds = args.DrawingSession;
            //ds.DrawRectangle(100 + player.XOffset, 100 + player.YOffset, 50, 50, Colors.Aqua);
            //ds.DrawImage(playerSprite, player.XOffset, player.YOffset, new Rect(0, 0, 64, 64));

            using (var spriteBatch = ds.CreateSpriteBatch())
            {
                foreach (Layer layer in LayerManager.Layers)
                {
                    foreach (Entity entity in layer.Entities)
                    {
                        entity.Sprite.DrawSpriteExt(
                        spriteBatch,
                        new Vector2(entity.XPos, entity.YPos),
                        new Vector2(entity.ImageX, entity.ImageY),
                        new Vector4(entity.Red, entity.Green, entity.Blue, entity.Alpha),
                        0,
                        new Vector2(entity.XScale, entity.YScale),
                        0);
                    }
                }
            }
        }
    }
}
