using System;
using System.Collections.Generic;
using System.Text;

namespace Default
{
    class Program
    {
        private const string ParameterNameAddSugar = "add-sugar";
        private const string ParameterNameFlavor = "flavor";
        private const string ParameterNameCount = "count";

        private static readonly Dictionary<string, (Func<string, object> parser, Func<object> fallback)>
            ExpectedParameters =
                new Dictionary<string, (Func<string, object> parser, Func<object> fallback)>
                {
                    {ParameterNameAddSugar, (s => bool.Parse(s), () => false)},
                    {ParameterNameFlavor, (s => s, () => "chocolate")},
                    {ParameterNameCount, (s => int.Parse(s), () => 1)},
                };

        private static void Main(string[] args)
        {
            if (Array.Exists(args, s => s == "--help"))
            {
                PrintHelp();
                return;
            }
            
            var addSugar = ParameterExists(args, ParameterNameAddSugar);
            var flavor = GetParameter<string>(args, ParameterNameFlavor);
            var count = GetParameter<int>(args, ParameterNameCount);

            var result = $"Creating {count} banana {(count == 1 ? "smoothie" : "smoothies")} with {flavor}";
            if (addSugar)
            {
                result += " and sugar";
            }
            Console.WriteLine(result);
        }

        private static void PrintHelp()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Default:");
            sb.AppendLine("  Default Smoothie machine");
            sb.AppendLine();
            sb.AppendLine("Usage:");
            sb.AppendLine("  Default [options]");
            sb.AppendLine();
            sb.AppendLine("Options:");
            sb.AppendLine("  --add-sugar          Add sugar to the smoothie?");
            sb.AppendLine("  --flavor <flavor>    Which flavor to use");
            sb.AppendLine("  --count <count>      How many smoothies?");
            Console.WriteLine(sb);
        }

        private static T GetParameter<T>(string[] args, string parameterName)
        {
            ExpectedParameters.TryGetValue(parameterName, out var paramFunctions);
            try
            {
                var index = Array.FindIndex(args, s => s == $"--{parameterName}");
                var result = paramFunctions.parser.Invoke(args[index + 1]);
                return (T) result;
            }
            catch
            {
                return (T) paramFunctions.fallback();
            }
        }

        private static bool ParameterExists(string[] args, string parameterName)
        {
            return Array.Exists(args, s => s == $"--{parameterName}");
        }
    }
}