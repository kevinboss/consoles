using NStack;

namespace GUI.cs
{
    public class Smoothie
    {
        public int Count { get; set; }

        public string Flavor { get; set; }

        public bool AddSugar { get; set; }

        public override string ToString()
        {
            var result = $"{Count} banana {(Count == 1 ? "smoothie" : "smoothies")} with {Flavor}";
            if (AddSugar)
            {
                result += " and sugar";
            }

            return result;
        }
    }
}