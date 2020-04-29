using System;
using System.Collections.Generic;
using BillMaterialGen.Data;
using BillMaterialGen.Enums;
using BillMaterialGen.Readers.Interfaces;
using Serilog;

namespace BillMaterialGen.Readers
{
    public class ConsoleInputRetriever : IConsoleInputRetriever
    {
        private readonly ILogger logger;

        public ConsoleInputRetriever(ILogger logger)
        {
            this.logger = logger;
        }

        public IEnumerable<ShapeDto> GetShapeInputs()
        {
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            logger.Information("Please enter position X, position Y, Width and Height for Rectangle");
            shapeInputs.Add(new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = Console.ReadLine(),
                PositionY = Console.ReadLine(),
                Width = Console.ReadLine(),
                Height = Console.ReadLine()
            });

            logger.Information("Please enter position X, position Y and Width for Square");
            shapeInputs.Add(new ShapeDto
            {
                ShapeType = ShapeType.Square,
                PositionX = Console.ReadLine(),
                PositionY = Console.ReadLine(),
                Width = Console.ReadLine()
            });

            logger.Information("Please enter position X, position Y, horizontal diameter and vertical diameter for Ellipse");
            shapeInputs.Add(new ShapeDto
            {
                ShapeType = ShapeType.Ellipse,
                PositionX = Console.ReadLine(),
                PositionY = Console.ReadLine(),
                HorizontalDiameter = Console.ReadLine(),
                VerticalDiameter = Console.ReadLine()
            });

            logger.Information("Please enter position X, position Y and horizontal diameter for Circle");
            shapeInputs.Add(new ShapeDto
            {
                ShapeType = ShapeType.Circle,
                PositionX = Console.ReadLine(),
                PositionY = Console.ReadLine(),
                HorizontalDiameter = Console.ReadLine()
            });

            logger.Information("Please enter position X, position Y, Width, Height and Text for Textbox");
            shapeInputs.Add(new ShapeDto
            {
                ShapeType = ShapeType.Textbox,
                PositionX = Console.ReadLine(),
                PositionY = Console.ReadLine(),
                Width = Console.ReadLine(),
                Height = Console.ReadLine(),
                Text = Console.ReadLine()
            });

            return shapeInputs;
        }
    }
}
