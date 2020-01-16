using Terminal.Gui;

namespace GUI.cs
{
    class Program
    {
        private static void Main()
        {
            Application.Init();
            Application.Top.Add(new MainWindow("Smoothie machine"));
            Application.Run();
        }
    }
}