using System.Collections.Generic;
using BillMaterialGen.Data;
using BillMaterialGen.Enums;
using BillMaterialGen.Readers.Interfaces;
using BillMaterialGen.Shapes;
using BillMaterialGen.Validation.Interfaces;

namespace BillMaterialGen.Readers
{
    public class ConsoleReader : IConsoleReader
    {
        private readonly IConsoleInputRetriever consoleInputRetriever;
        private readonly IInputValidator inputValidator;

        public ConsoleReader(IConsoleInputRetriever consoleInputRetriever, IInputValidator inputValidator)
        {
            this.consoleInputRetriever = consoleInputRetriever;
            this.inputValidator = inputValidator;
        }

        public IEnumerable<Shape> GetShapesData()
        {
            IEnumerable<ShapeDto> shapeInputs = consoleInputRetriever.GetShapeInputs();

            if (!inputValidator.IsInputValid(shapeInputs))
            {
                return null;
            }

            List<Shape> shapes = new List<Shape>();

            foreach (var shapeInput in shapeInputs)
            {
                shapes.Add(ConstructShape(shapeInput));
            }

            return shapes;
        }

        private Shape ConstructShape(ShapeDto shape)
        {
            switch (shape.ShapeType)
            {
                case ShapeType.Square:
                    return Square.Create(int.Parse(shape.PositionX), int.Parse(shape.PositionY), int.Parse(shape.Width));
                case ShapeType.Rectangle:
                    return Rectangle.Create(int.Parse(shape.PositionX), int.Parse(shape.PositionY), int.Parse(shape.Width), int.Parse(shape.Height));
                case ShapeType.Textbox:
                    return Textbox.Create(int.Parse(shape.PositionX), int.Parse(shape.PositionY), int.Parse(shape.Width), int.Parse(shape.Height), shape.Text);
                case ShapeType.Circle:
                    return Circle.Create(int.Parse(shape.PositionX), int.Parse(shape.PositionY), int.Parse(shape.HorizontalDiameter));
                case ShapeType.Ellipse:
                    return Ellipse.Create(int.Parse(shape.PositionX), int.Parse(shape.PositionY), int.Parse(shape.HorizontalDiameter), int.Parse(shape.VerticalDiameter));
                default:
                    return null;
            }
        }
    }
}
