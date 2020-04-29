using System.Collections.Generic;
using System.Text;
using BillMaterialGen.Configuration.Interfaces;
using BillMaterialGen.Generators;
using BillMaterialGen.Shapes;
using Microsoft.Extensions.Configuration;
using Telerik.JustMock;
using Xunit;

namespace BillMaterialGenTests.Generators
{
    public class LegacyBuilderMaterialGeneratorTests
    {
        [Fact]
        public void GetBillOfMaterials_NullShapes_ErrorCodeReturned()
        {
            //Arrange
            string errorCode = "+++++Abort+++++";

            var settings = Mock.Create<ISettings>();
            var legacyBuilderMaterialGenerator = Mock.Create(() => new LegacyBuilderMaterialGenerator(settings));

            Mock.Arrange(() => settings.LegacyBuilderErrorCode).Returns(errorCode).OccursOnce();

            //Act
            var result = legacyBuilderMaterialGenerator.GetBillOfMaterials(null);

            //Assert
            Assert.Equal(errorCode, result);
            Mock.Assert(settings);
        }

        [Fact]
        public void GetBillOfMaterials_Rectangle_OutputAsExpected()
        {
            //Arrange
            Rectangle rectangle = Rectangle.Create(10, 10, 30, 40);

            StringBuilder expectation = new StringBuilder();
            expectation.AppendLine("----------------------------------------------------------------");
            expectation.AppendLine("Bill of Materials");
            expectation.AppendLine("----------------------------------------------------------------");
            expectation.AppendLine($"{nameof(Rectangle)} ({rectangle.PositionX},{rectangle.PositionY}) width={rectangle.Width} height={rectangle.Height}");
            expectation.AppendLine("----------------------------------------------------------------");

            IEnumerable<Shape> shapes = new Shape[] { rectangle };

            var settings = Mock.Create<ISettings>();
            var legacyBuilderMaterialGenerator = Mock.Create(() => new LegacyBuilderMaterialGenerator(settings));

            Mock.Arrange(() => settings.LegacyBuilderErrorCode).Returns("+++++Abort+++++").OccursNever();

            //Act
            var result = legacyBuilderMaterialGenerator.GetBillOfMaterials(shapes);

            //Assert
            Assert.Equal(expectation.ToString(), result);
            Mock.Assert(settings);
        }

        [Fact]
        public void GetBillOfMaterials_Square_OutputAsExpected()
        {
            //Arrange
            Square square = Square.Create(500, 30, 35);

            StringBuilder expectation = new StringBuilder();
            expectation.AppendLine("----------------------------------------------------------------");
            expectation.AppendLine("Bill of Materials");
            expectation.AppendLine("----------------------------------------------------------------");
            expectation.AppendLine($"{nameof(Square)} ({square.PositionX},{square.PositionY}) size={square.Width}");
            expectation.AppendLine("----------------------------------------------------------------");

            IEnumerable<Shape> shapes = new Shape[] { square };

            var settings = Mock.Create<ISettings>();
            var legacyBuilderMaterialGenerator = Mock.Create(() => new LegacyBuilderMaterialGenerator(settings));

            Mock.Arrange(() => settings.LegacyBuilderErrorCode).Returns("+++++Abort+++++").OccursNever();

            //Act
            var result = legacyBuilderMaterialGenerator.GetBillOfMaterials(shapes);

            //Assert
            Assert.Equal(expectation.ToString(), result);
            Mock.Assert(settings);
        }

        [Fact]
        public void GetBillOfMaterials_Ellipse_OutputAsExpected()
        {
            //Arrange
            Ellipse ellipse = Ellipse.Create(100, 150, 300, 200);

            StringBuilder expectation = new StringBuilder();
            expectation.AppendLine("----------------------------------------------------------------");
            expectation.AppendLine("Bill of Materials");
            expectation.AppendLine("----------------------------------------------------------------");
            expectation.AppendLine($"{nameof(Ellipse)} ({ellipse.PositionX},{ellipse.PositionY}) diameterH = {ellipse.HorizontalDiameter} diameterV = {ellipse.VerticalDiameter}");
            expectation.AppendLine("----------------------------------------------------------------");

            IEnumerable<Shape> shapes = new Shape[] { ellipse };

            var settings = Mock.Create<ISettings>();
            var legacyBuilderMaterialGenerator = Mock.Create(() => new LegacyBuilderMaterialGenerator(settings));

            Mock.Arrange(() => settings.LegacyBuilderErrorCode).Returns("+++++Abort+++++").OccursNever();

            //Act
            var result = legacyBuilderMaterialGenerator.GetBillOfMaterials(shapes);

            //Assert
            Assert.Equal(expectation.ToString(), result);
            Mock.Assert(settings);
        }

        [Fact]
        public void GetBillOfMaterials_Circle_OutputAsExpected()
        {
            //Arrange
            Circle circle = Circle.Create(1, 1, 300);

            StringBuilder expectation = new StringBuilder();
            expectation.AppendLine("----------------------------------------------------------------");
            expectation.AppendLine("Bill of Materials");
            expectation.AppendLine("----------------------------------------------------------------");
            expectation.AppendLine($"{nameof(Circle)} ({circle.PositionX},{circle.PositionY}) size={circle.HorizontalDiameter}");
            expectation.AppendLine("----------------------------------------------------------------");

            IEnumerable<Shape> shapes = new Shape[] { circle };

            var settings = Mock.Create<ISettings>();
            var legacyBuilderMaterialGenerator = Mock.Create(() => new LegacyBuilderMaterialGenerator(settings));

            Mock.Arrange(() => settings.LegacyBuilderErrorCode).Returns("+++++Abort+++++").OccursNever();

            //Act
            var result = legacyBuilderMaterialGenerator.GetBillOfMaterials(shapes);

            //Assert
            Assert.Equal(expectation.ToString(), result);
            Mock.Assert(settings);
        }

        [Fact]
        public void GetBillOfMaterials_Textbox_OutputAsExpected()
        {
            //Arrange
            Textbox textbox = Textbox.Create(5, 5, 200, 100, "sample text");

            StringBuilder expectation = new StringBuilder();
            expectation.AppendLine("----------------------------------------------------------------");
            expectation.AppendLine("Bill of Materials");
            expectation.AppendLine("----------------------------------------------------------------");
            expectation.AppendLine($"{nameof(Textbox)} ({textbox.PositionX},{textbox.PositionY}) width={textbox.Width} height={textbox.Height} text={textbox.Text}");
            expectation.AppendLine("----------------------------------------------------------------");

            IEnumerable<Shape> shapes = new Shape[] { textbox };

            var settings = Mock.Create<ISettings>();
            var legacyBuilderMaterialGenerator = Mock.Create(() => new LegacyBuilderMaterialGenerator(settings));

            Mock.Arrange(() => settings.LegacyBuilderErrorCode).Returns("+++++Abort+++++").OccursNever();

            //Act
            var result = legacyBuilderMaterialGenerator.GetBillOfMaterials(shapes);

            //Assert
            Assert.Equal(expectation.ToString(), result);
            Mock.Assert(settings);
        }
    }
}
