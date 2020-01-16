using NStack;
using Terminal.Gui;

namespace GUI.cs
{
    public class Info : Dialog
    {
        private static readonly Button Ok = new Button("Ok");

        public Info(ustring title, ustring text) : base(title, 60, 7, Ok)
        {
            Add(new Label(text));
            Ok.Clicked = Application.RequestStop;
        }
    }
}