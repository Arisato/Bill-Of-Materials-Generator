using System.Collections.Generic;
using System.Linq;
using BillMaterialGen.Data;
using BillMaterialGen.Enums;
using BillMaterialGen.Readers;
using BillMaterialGen.Readers.Interfaces;
using BillMaterialGen.Shapes;
using BillMaterialGen.Validation.Interfaces;
using Telerik.JustMock;
using Xunit;

namespace BillMaterialGenTests.Readers
{
    public class ConsoleReaderTests
    {
        [Fact]
        public void IsInputValid_ValidInput_ShapesReturned()
        {
            //Arrange
            ShapeDto shapeInput = new ShapeDto
            {
                ShapeType = ShapeType.Square,
                PositionX = "10",
                PositionY = "10",
                Width = "10"
            };

            IEnumerable<ShapeDto> shapeInputs = new ShapeDto[] { shapeInput };

            var consoleInputRetriever = Mock.Create<IConsoleInputRetriever>();
            var inputValidator = Mock.Create<IInputValidator>();
            var consoleReader = Mock.Create(() => new ConsoleReader(consoleInputRetriever, inputValidator));

            Mock.Arrange(() => consoleInputRetriever.GetShapeInputs()).Returns(shapeInputs).OccursOnce();
            Mock.Arrange(() => inputValidator.IsInputValid(shapeInputs)).Returns(true).OccursOnce();

            //Act
            var square = consoleReader.GetShapesData().First() as Square;

            //Assert
            Assert.Equal(shapeInput.ShapeType.ToString(), square.GetType().Name);
            Assert.Equal(int.Parse(shapeInput.PositionX), square.PositionX);
            Assert.Equal(int.Parse(shapeInput.PositionY), square.PositionY);
            Assert.Equal(int.Parse(shapeInput.Width), square.Width);
            Mock.Assert(consoleInputRetriever);
            Mock.Assert(inputValidator);
        }

        [Fact]
        public void IsInputValid_InvalidInput_NullReturned()
        {
            //Arrange
            ShapeDto shapeInput = new ShapeDto
            {
                ShapeType = ShapeType.Square,
                PositionX = "-10",
                PositionY = "10",
                Width = "10"
            };

            IEnumerable<ShapeDto> shapeInputs = new ShapeDto[] { shapeInput };

            var consoleInputRetriever = Mock.Create<IConsoleInputRetriever>();
            var inputValidator = Mock.Create<IInputValidator>();
            var consoleReader = Mock.Create(() => new ConsoleReader(consoleInputRetriever, inputValidator));

            Mock.Arrange(() => consoleInputRetriever.GetShapeInputs()).Returns(shapeInputs).OccursOnce();
            Mock.Arrange(() => inputValidator.IsInputValid(shapeInputs)).Returns(false).OccursOnce();

            //Act
            var shapes = consoleReader.GetShapesData();

            //Assert
            Assert.Null(shapes);
            Mock.Assert(consoleInputRetriever);
            Mock.Assert(inputValidator);
        }
    }
}
