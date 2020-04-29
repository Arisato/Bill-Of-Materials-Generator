using System.Collections.Generic;
using BillMaterialGen.Configuration.Interfaces;
using BillMaterialGen.Data;
using BillMaterialGen.Enums;
using BillMaterialGen.Logger.Interfaces;
using BillMaterialGen.Validation;
using Microsoft.Extensions.Configuration;
using Telerik.JustMock;
using Xunit;

namespace BillMaterialGenTests.Validation
{
    public class InputValidatiorTests
    {
        [Fact]
        public void IsInputValid_CircularShapeInputValid_ShouldReturnTrue()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Ellipse,
                PositionX = "10",
                PositionY = "10",
                HorizontalDiameter = "10",
                VerticalDiameter = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).Occurs(2);
            Mock.Arrange(() => errorLogger
            .LogParameterError(Arg.AnyString, Arg.AnyString, Arg.AnyString)).OccursNever();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.True(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_QuadrilateralShapeInputValid_ShouldReturnTrue()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = "10",
                PositionY = "10",
                Width = "10",
                Height = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).Occurs(2);
            Mock.Arrange(() => errorLogger
            .LogParameterError(Arg.AnyString, Arg.AnyString, Arg.AnyString)).OccursNever();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.True(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapeNegativePositionX_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = "-10",
                PositionY = "10",
                Width = "10",
                Height = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursNever();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.PositionX), shapeDto.PositionX, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapeNegativePositionY_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = "10",
                PositionY = "-10",
                Width = "10",
                Height = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));
            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursOnce();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.PositionY), shapeDto.PositionY, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapeNegativeWidth_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = "10",
                PositionY = "10",
                Width = "-10",
                Height = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));
            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursNever();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.Width), shapeDto.Width, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapeNegativeHeight_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = "10",
                PositionY = "10",
                Width = "10",
                Height = "-10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));
            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursOnce();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.Height), shapeDto.Height, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapeNegativeVerticalDiameter_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Ellipse,
                PositionX = "10",
                PositionY = "10",
                HorizontalDiameter = "10",
                VerticalDiameter = "-10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursOnce();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.VerticalDiameter), shapeDto.VerticalDiameter, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapeNegativeHorizontalDiameter_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Ellipse,
                PositionX = "10",
                PositionY = "10",
                HorizontalDiameter = "-10",
                VerticalDiameter = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursNever();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.HorizontalDiameter), shapeDto.HorizontalDiameter, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapePositionXWidthLocationInvalid_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = "500",
                PositionY = "10",
                Width = "501",
                Height = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursOnce();
            Mock.Arrange(() => errorLogger
            .LogShapeLocationError(nameof(shapeDto.PositionX), nameof(shapeDto.Width),
            shapeDto.PositionX, shapeDto.Width, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapePositionYHeightLocationInvalid_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = "10",
                PositionY = "500",
                Width = "10",
                Height = "501"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).Occurs(2);
            Mock.Arrange(() => errorLogger
            .LogShapeLocationError(nameof(shapeDto.PositionY), nameof(shapeDto.Height),
            shapeDto.PositionY, shapeDto.Height, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapePositionXHorizontalDiameterLocationInvalid_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Ellipse,
                PositionX = "500",
                PositionY = "10",
                HorizontalDiameter = "501",
                VerticalDiameter = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursOnce();
            Mock.Arrange(() => errorLogger
            .LogShapeLocationError(nameof(shapeDto.PositionX), nameof(shapeDto.HorizontalDiameter),
            shapeDto.PositionX, shapeDto.HorizontalDiameter, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapePositionYVerticalDiameterLocationInvalid_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Ellipse,
                PositionX = "10",
                PositionY = "500",
                HorizontalDiameter = "10",
                VerticalDiameter = "501"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).Occurs(2);
            Mock.Arrange(() => errorLogger
            .LogShapeLocationError(nameof(shapeDto.PositionY), nameof(shapeDto.VerticalDiameter),
            shapeDto.PositionY, shapeDto.VerticalDiameter, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapePositionXInvalidValue_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = "Test",
                PositionY = "10",
                Width = "10",
                Height = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursNever();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.PositionX), shapeDto.PositionX, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapePositionYInvalidValue_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = "10",
                PositionY = "Test",
                Width = "10",
                Height = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursOnce();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.PositionY), shapeDto.PositionY, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapeWidthInvalidValue_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = "10",
                PositionY = "10",
                Width = "Test",
                Height = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursNever();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.Width), shapeDto.Width, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapeHeightInvalidValue_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Rectangle,
                PositionX = "10",
                PositionY = "10",
                Width = "10",
                Height = "Test"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursOnce();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.Height), shapeDto.Height, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapeVerticalDiameterInvalidValue_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Ellipse,
                PositionX = "10",
                PositionY = "10",
                HorizontalDiameter = "10",
                VerticalDiameter = "Test"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursOnce();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.VerticalDiameter), shapeDto.VerticalDiameter, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }

        [Fact]
        public void IsInputValid_ShapeHorizontalDiameterInvalidValue_ShouldReturnFalse()
        {
            //Arrange
            List<ShapeDto> shapeInputs = new List<ShapeDto>();

            ShapeDto shapeDto = new ShapeDto
            {
                ShapeType = ShapeType.Ellipse,
                PositionX = "10",
                PositionY = "10",
                HorizontalDiameter = "Test",
                VerticalDiameter = "10"
            };

            shapeInputs.Add(shapeDto);

            var settings = Mock.Create<ISettings>();
            var errorLogger = Mock.Create<IErrorLogger>();
            var inputValidator = Mock.Create(() => new InputValidator(settings, errorLogger));

            Mock.Arrange(() => settings.CanvasSize).Returns(1000).OccursNever();
            Mock.Arrange(() => errorLogger
            .LogParameterError(nameof(shapeDto.HorizontalDiameter), shapeDto.HorizontalDiameter, shapeDto.ShapeType.ToString())).OccursOnce();

            //Act
            var result = inputValidator.IsInputValid(shapeInputs);

            //Assert
            Assert.False(result);
            Mock.Assert(settings);
            Mock.Assert(errorLogger);
        }
    }
}
