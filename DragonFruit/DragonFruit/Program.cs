using System;

namespace DragonFruit
{
    class Program
    {
        /// <summary>
        /// DragonFruit smoothie machine
        /// </summary>
        /// <param name="addSugar">Add sugar to the smoothie?</param>
        /// <param name="flavor">Which flavor to use</param>
        /// <param name="count">How many smoothies?</param>
        static int Main(
            bool addSugar = false,
            string flavor = "chocolate",
            int count = 1)
        {
           
            var result = $"Creating {count} banana {(count == 1 ? "smoothie" : "smoothies")} with {flavor}";
            if (addSugar)
            {
                result += " and sugar";
            }
            Console.WriteLine(result);
            return 0;
        }
    }
}