using System;
using System.Collections.Generic;
using System.Linq;
using Terminal.Gui;

namespace GUI.cs
{
    public class SmoothieConfig : FrameView
    {
        public SmoothieConfig() : base("Smoothie-config")
        {
            var amountLabel = new Label("Amount: ");
            var amountField = new TextField("")
            {
                X = Pos.Right(amountLabel),
                Y = Pos.Top(amountLabel),
                Width = 5
            };
            var flavourOptions = new List<string>
            {
                "Chocolate",
                "Strawberry",
                "Cherry",
                "Vanilla"
            };
            var flavourRadioGroup = new RadioGroup(flavourOptions.Select(e => "_" + e).ToArray())
            {
                X = 0,
                Y = Pos.Top(amountField) + 2,
                Selected = 0
            };
            var addSugarCheckBox = new CheckBox("Add sugar?")
            {
                Y = Pos.Top(flavourRadioGroup) + flavourOptions.Count + 3
            };
            var okButton = new Button("Ok")
            {
                Clicked = () =>
                {
                    if (!int.TryParse(amountField.Text.ToString(), out var count))
                    {
                        var warningDialog = new Info("Warning", "Amount must be a number") {ColorScheme = Colors.Error};
                        Application.Run(warningDialog);
                        return;
                    }

                    var newSmoothie = new Smoothie
                    {
                        Count = count,
                        Flavor = flavourOptions[flavourRadioGroup.Selected],
                        AddSugar = addSugarCheckBox.Checked
                    };

                    NewSmoothieCreated?.Invoke(newSmoothie);
                },
                Y = Pos.Top(addSugarCheckBox) + 9
            };
            Add(
                amountLabel,
                amountField,
                flavourRadioGroup,
                addSugarCheckBox,
                okButton
            );
        }

        public Action<Smoothie> NewSmoothieCreated { get; set; }
    }
}