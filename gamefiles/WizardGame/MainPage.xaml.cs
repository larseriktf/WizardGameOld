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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WizardGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        CanvasBitmap playerSprite;
        DispatcherTimer gameTimer = new DispatcherTimer();

        Player player = new Player();

        public MainPage()
        {
            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(16);
            gameTimer.Start();

            InitializeComponent();
        }

        // Every tick
        private void GameTimerEvent(object sender, object e)
        {
            TrackKeyboard();
        }

        private void TrackKeyboard()
        {
            KeyBoard.UpdateKeys();

            if (KeyBoard.KeyLeft) player.XOffset -= player.MoveSpeed;
            if (KeyBoard.KeyRight) player.XOffset += player.MoveSpeed;
            if (KeyBoard.KeyUp) player.YOffset -= player.MoveSpeed;
            if (KeyBoard.KeyDown) player.YOffset += player.MoveSpeed;
        }

        // Best practice: Prevent simple memory leak
        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            this.canvas.RemoveFromVisualTree();
            this.canvas = null;
        }

        private void CreateResources(CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        { // Creates Resources once
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        async Task CreateResourcesAsync(CanvasAnimatedControl sender)
        {
            /*
             can do sender.Height and sender.Width to change canvas size
             Check out https://stackoverflow.com/questions/49945675/resizing-an-image-using-win2d-with-proportional-aspect-ratio
            */
            playerSprite = await CanvasBitmap.LoadAsync(sender, new Uri(player.BitMapUri));
        }

        private void Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            var ds = args.DrawingSession;
            //ds.DrawRectangle(100 + player.XOffset, 100 + player.YOffset, 50, 50, Colors.Aqua);
            ds.DrawImage(playerSprite, player.XOffset, player.YOffset, new Rect(0, 0, 64, 64));

            ds.Clear(Colors.Blue);

            ds.Transform = Matrix3x2.CreateTranslation((float)sender.Size.Width * 0.5f, (float)sender.Size.Height * 0.5f);
            ds.DrawLine(-100, 0, 100, 0, Colors.White, 1);
            ds.DrawLine(0, -100, 0, 100, Colors.White, 1);

            Rect r = new Rect(-25, -25, 50, 50);
            ds.DrawRectangle(r, Colors.Red);
            ds.Transform = Matrix3x2.CreateRotation(2) * ds.Transform;
            ds.DrawRectangle(r, Colors.White);
        }
    }
}
