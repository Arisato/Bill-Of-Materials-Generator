using System.Collections.Generic;
using BillMaterialGen.Configuration.Interfaces;
using BillMaterialGen.Data;
using BillMaterialGen.Enums;
using BillMaterialGen.Logger.Interfaces;
using BillMaterialGen.Validation.Interfaces;

namespace BillMaterialGen.Validation
{
    public class InputValidator : IInputValidator
    {
        private readonly ISettings settings;
        private readonly IErrorLogger logger;

        public InputValidator(ISettings settings, IErrorLogger logger)
        {
            this.settings = settings;
            this.logger = logger;
        }

        public bool IsInputValid(IEnumerable<ShapeDto> shapes)
        {
            foreach (var shape in shapes)
            {
                if (!IsShapeValid(shape))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsShapeValid(ShapeDto shape)
        {
            if (shape.ShapeType == ShapeType.Square || shape.ShapeType == ShapeType.Circle)
            {
                return IsConstantShapeValid(shape);
            }
            if (shape.ShapeType == ShapeType.Rectangle || shape.ShapeType == ShapeType.Textbox || shape.ShapeType == ShapeType.Ellipse)
            {
                return IsDynamicShapeValid(shape);
            }

            return false;
        }

        private bool IsConstantShapeValid(ShapeDto shape)
        {
            var paramValue = shape.ShapeType == ShapeType.Square ? shape.Width : shape.HorizontalDiameter;
            var paramName = shape.ShapeType == ShapeType.Square ? nameof(shape.Width) : nameof(shape.HorizontalDiameter);

            return IsShapePositionAndSizeValid(shape.ShapeType.ToString(),
                nameof(shape.PositionX), paramName, shape.PositionX, paramValue)
                && IsCanvasParamValid(shape.ShapeType.ToString(), nameof(shape.PositionY), shape.PositionY, out _);
        }

        private bool IsDynamicShapeValid(ShapeDto shape)
        {
            var paramWidthValue = shape.ShapeType == ShapeType.Ellipse ? shape.HorizontalDiameter : shape.Width;
            var paramWidthName = shape.ShapeType == ShapeType.Ellipse ? nameof(shape.HorizontalDiameter) : nameof(shape.Width);
            var paramHeightValue = shape.ShapeType == ShapeType.Ellipse ? shape.VerticalDiameter : shape.Height;
            var paramHeightName = shape.ShapeType == ShapeType.Ellipse ? nameof(shape.VerticalDiameter) : nameof(shape.Height);

            return IsShapePositionAndSizeValid(shape.ShapeType.ToString(),
                nameof(shape.PositionX), paramWidthName, shape.PositionX, paramWidthValue)
                && IsShapePositionAndSizeValid(shape.ShapeType.ToString(),
                nameof(shape.PositionY), paramHeightName, shape.PositionY, paramHeightValue);
        }

        private bool IsShapePositionAndSizeValid(string shapeName, string paramOneName, string paramTwoName, string paramOneValue, string paramTwoValue)
        {
            if (!IsCanvasParamValid(shapeName, paramOneName, paramOneValue, out int paramOneParsedValue) ||
                !IsCanvasParamValid(shapeName, paramTwoName, paramTwoValue, out int paramTwoParsedValue))
            {
                return false;
            }
            if (paramOneParsedValue + paramTwoParsedValue > settings.CanvasSize)
            {
                logger.LogShapeLocationError(paramOneName, paramTwoName, paramOneValue, paramTwoValue, shapeName);
                return false;
            }

            return true;
        }

        private bool IsCanvasParamValid(string shapeName, string paramName, string paramValue, out int paramIntValue)
        {
            paramIntValue = 0;
            if (!int.TryParse(paramValue, out int result) || result < 0)
            {
                logger.LogParameterError(paramName, paramValue, shapeName);
                return false;
            }

            paramIntValue = result;
            return true;
        }
    }
}
