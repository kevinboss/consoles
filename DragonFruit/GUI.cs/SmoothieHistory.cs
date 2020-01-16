using System;
using System.Collections.Generic;
using System.Linq;
using Terminal.Gui;

namespace GUI.cs
{
    public class SmoothieHistory : FrameView
    {
        private readonly List<Smoothie> _smoothieHistorySource = new List<Smoothie>();

        public SmoothieHistory() : base("Smoothie-history")
        {
            var smoothieHistory = new ListView(Array.Empty<Smoothie>())
            {
                CanFocus = true,
                AllowsMarking = false
            };
            Add(smoothieHistory);
            AddSmoothie = newSmoothie =>
            {
                _smoothieHistorySource.Add(newSmoothie);
                Application.Run(new Info("Info", $"Created {newSmoothie}"));
                smoothieHistory.SetSource(_smoothieHistorySource.AsEnumerable().Reverse().ToList());
            };
        }

        public Action<Smoothie> AddSmoothie { get; }
    }
}