using System;
using McMaster.Extensions.CommandLineUtils;

namespace CommandLineUtils
{
    class Program
    {
        public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        [Option(ShortName = "c", LongName = "count", Description = "How many smoothies?")]
        public int Count { get; } = 1;

        [Option(ShortName = "f", LongName = "flavor", Description = "Which flavor to use")]
        public string Flavor { get; } = "chocolate";

        [Option(ShortName = "a", LongName = "add-sugar", Description = "Add sugar to the smoothie?")]
        public bool AddSugar { get; } = false;

        private void OnExecute()
        {
            var result = $"Creating {Count} banana {(Count == 1 ? "smoothie" : "smoothies")} with {Flavor}";
            if (AddSugar)
            {
                result += " and sugar";
            }

            Console.WriteLine(result);
        }
    }
}