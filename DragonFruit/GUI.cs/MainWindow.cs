using System;
using System.Threading;
using Mono.Terminal;
using NStack;
using Terminal.Gui;

namespace GUI.cs
{
    public class MainWindow : Window
    {
        public MainWindow(ustring title = null) : base(title)
        {
            var smoothieConfig = new SmoothieConfig
            {
                Width = 30,
                Height = Dim.Fill(1)
            };
            var smoothieHistory = new SmoothieHistory()
            {
                X = Pos.Right(smoothieConfig),
                Width = Dim.Fill(),
                Height = Dim.Fill(1)
            };
            smoothieConfig.NewSmoothieCreated = smoothieHistory.AddSmoothie;

            Add(smoothieConfig, smoothieHistory);
        }
    }
}