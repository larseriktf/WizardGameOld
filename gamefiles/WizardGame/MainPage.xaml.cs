﻿using System;
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
using WizardGame.Interfaces;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WizardGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Map> maps;
        Dictionary<string, SpriteSheet> mapSpriteSheets = new Dictionary<string, SpriteSheet>();
        readonly DispatcherTimer gameTimer = new DispatcherTimer();
        readonly Player player = new Player();
        readonly CardEnemy card = new CardEnemy();
        readonly CoordPoint point = new CoordPoint();

        
        

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
            args.TrackAsyncAction(LoadResourcesAsync(sender).AsAsyncAction());
        }

        async Task LoadResourcesAsync(CanvasAnimatedControl sender)
        {   // Loads images and spritesheets
            EntityManager.gameEntities.Add(new Player()
            {
                Sprite = await SpriteSheet.LoadSpriteSheetAsync(sender.Device, player.BitMapUri, new Vector2(96, 96)),
            });
            EntityManager.gameEntities.Add(new CardEnemy()
            {
                Sprite = await SpriteSheet.LoadSpriteSheetAsync(sender.Device, card.BitMapUri, new Vector2(24, 24)),
                XPos = 500,
                YPos = 500
            });
            EntityManager.gameEntities.Add(new CoordPoint()
            {
                Sprite = await SpriteSheet.LoadSpriteSheetAsync(sender.Device, point.BitMapUri, new Vector2(8, 8)),
                XPos = 1000,
                YPos = 500
            });

            mapSpriteSheets.Add(
                "dev",
                await SpriteSheet.LoadSpriteSheetAsync(sender.Device, "ms-appx:///Assets/Sprites/Dev/spr_dev.jpg", new Vector2(128, 128)));

            // Get maps
            maps = MapEditor.GetMaps(mapSpriteSheets);

            // @TODO: Make this more flexible, so it allowes all maps to be added / Or just current playing map to be added
            Layer layer0 = new Layer("layer0");
            layer0.GameObjects.Add(maps[0].MapLayouts[0]);

            // Add stuff
            Layer layer1 = new Layer("layer1");

            foreach (IGameObjectModel entity in EntityManager.gameEntities)
            {
                layer1.GameObjects.Add(entity);
            }

            EntityManager.Layers.Add(layer0);
            EntityManager.Layers.Add(layer1);
        }

        

        private void OnDraw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            var ds = args.DrawingSession;

            using (var spriteBatch = ds.CreateSpriteBatch())
            {

                // Draw gameObjects
                foreach (Layer layer in EntityManager.Layers)
                {
                    foreach (IGameObjectModel gameObject in layer.GameObjects)
                    {
                        gameObject.UpdateMovement();
                        gameObject.DrawSelf(spriteBatch);   
                    }
                }
            }
        }
    }
}
