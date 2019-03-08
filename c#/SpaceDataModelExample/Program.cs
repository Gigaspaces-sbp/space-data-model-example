using System;
using GigaSpaces.Core;
using SpaceDataModelExample.Embedded.One2Many;
using SpaceDataModelExample.Embedded.One2One;
using SpaceDataModelExample.NonEmbedded.One2Many;
using SpaceDataModelExample.NonEmbedded.One2One;

namespace SpaceDataModelExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("GigaSpaces Data Modeling Example");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Embedded one-to-one.");
            Console.WriteLine("2. Embedded one-to-many.");
            Console.WriteLine("3. Non-Embedded one-to-one.");
            Console.WriteLine("4. Non-Embedded one-to-many.");

            Console.WriteLine();
            Console.WriteLine("Please enter your selection:");
            var selection = Console.ReadLine();

            IExamplePattern pattern;

            switch (selection)
            {
                case "1":
                    pattern = new EmbeddedOne2OneExample();
                    break;
                case "2":
                    pattern= new EmbeddedOne2ManyExample();
                    break;
                case "3":
                    pattern = new NonEmbeddedOne2OneExample();
                    break;
                case "4":
                    pattern = new NonEmbeddedOne2ManyExample();
                    break;
                default:
                    throw new InvalidOperationException("Select an option within range.");
            }

            Console.WriteLine();
            Console.WriteLine("Launching space, please wait.");
            ISpaceProxy proxy = GigaSpacesFactory.FindSpace("/./modeling-data-samples");

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("BEGIN EXAMPLE");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();

            pattern.Fill(proxy);
            pattern.QuerySpace(proxy);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
        }
    }
}
