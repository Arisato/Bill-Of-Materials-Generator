using System;
using System.Collections.Generic;
using BillMaterialGen.Generators.Interfaces;
using BillMaterialGen.Readers.Interfaces;
using BillMaterialGen.Shapes;

namespace BillMaterialGen
{
    public class Startup
    {
        private readonly IConsoleReader consoleReader;
        private readonly IDatabaseReader databaseReader;
        private readonly ILegacyBuilderMaterialGenerator legacyBuilderInputGenerator;

        public Startup(IConsoleReader consoleReader,
            IDatabaseReader databaseReader,
            ILegacyBuilderMaterialGenerator legacyBuilderInputGenerator)
        {
            this.consoleReader = consoleReader;
            this.databaseReader = databaseReader;
            this.legacyBuilderInputGenerator = legacyBuilderInputGenerator;
        }

        public void Run()
        {
            //Real validated and constructed data.
            IEnumerable<Shape> shapesFromConsole = consoleReader.GetShapesData();

            //Mocked database data (proof of concept for input from different system).
            //IEnumerable<Shape> shapesFromDatabase = databaseReader.GetShapesData();

            Console.WriteLine(legacyBuilderInputGenerator.GetBillOfMaterials(shapesFromConsole));
            //Console.WriteLine(legacyBuilderInputGenerator.GetBillOfMaterials(shapesFromDatabase));
        }
    }
}
