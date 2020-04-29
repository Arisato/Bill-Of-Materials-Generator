using System.Collections.Generic;
using BillMaterialGen;
using BillMaterialGen.Generators.Interfaces;
using BillMaterialGen.Readers.Interfaces;
using BillMaterialGen.Shapes;
using Telerik.JustMock;
using Xunit;

namespace BillMaterialGenTests
{
    public class StartupTests
    {
        [Fact]
        public void Startup_Integration_AllCallsMadeAsExpected()
        {
            //Arrange
            IEnumerable<Shape> shapes = new Shape[] { Square.Create(500, 30, 35) };

            var consoleReader = Mock.Create<IConsoleReader>();
            var databaseReader = Mock.Create<IDatabaseReader>();
            var legacyBuilderMaterialGenerator = Mock.Create<ILegacyBuilderMaterialGenerator>();
            var startup = Mock.Create(() => new Startup(consoleReader, databaseReader, legacyBuilderMaterialGenerator));

            Mock.Arrange(() => consoleReader.GetShapesData()).Returns(shapes).OccursOnce();
            Mock.Arrange(() => legacyBuilderMaterialGenerator.GetBillOfMaterials(shapes)).Returns(string.Empty).OccursOnce();

            //Act
            startup.Run();

            //Assert
            Mock.Assert(consoleReader);
            Mock.Assert(legacyBuilderMaterialGenerator);
        }
    }
}
