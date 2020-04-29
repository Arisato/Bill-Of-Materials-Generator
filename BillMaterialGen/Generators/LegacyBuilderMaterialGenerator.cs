using System.Collections.Generic;
using System.Text;
using BillMaterialGen.Configuration.Interfaces;
using BillMaterialGen.Generators.Interfaces;
using BillMaterialGen.Shapes;

namespace BillMaterialGen.Generators
{
    public class LegacyBuilderMaterialGenerator : ILegacyBuilderMaterialGenerator
    {
        private readonly ISettings settings;

        public LegacyBuilderMaterialGenerator(ISettings settings)
        {
            this.settings = settings;
        }

        public string GetBillOfMaterials(IEnumerable<Shape> shapes)
        {
            if (shapes == null)
            {
                return settings.LegacyBuilderErrorCode;
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("----------------------------------------------------------------");
            builder.AppendLine("Bill of Materials");
            builder.AppendLine("----------------------------------------------------------------");

            foreach (var shape in shapes)
            {
                builder.AppendLine(GetShapeInput(shape));
            }

            builder.AppendLine("----------------------------------------------------------------");

            return builder.ToString();
        }

        private string GetShapeInput(Shape shape)
        {
            if (shape.GetType() == typeof(Square))
            {
                var square = shape as Square;
                return $"{nameof(Square)} ({square.PositionX},{square.PositionY}) size={square.Width}";
            }
            if (shape.GetType() == typeof(Rectangle))
            {
                var rectangle = shape as Rectangle;
                return $"{nameof(Rectangle)} ({rectangle.PositionX},{rectangle.PositionY}) width={rectangle.Width} height={rectangle.Height}";
            }
            if (shape.GetType() == typeof(Textbox))
            {
                var textbox = shape as Textbox;
                return $"{nameof(Textbox)} ({textbox.PositionX},{textbox.PositionY}) width={textbox.Width} height={textbox.Height} text={textbox.Text}";
            }
            if (shape.GetType() == typeof(Circle))
            {
                var circle = shape as Circle;
                return $"{nameof(Circle)} ({circle.PositionX},{circle.PositionY}) size={circle.HorizontalDiameter}";
            }
            if (shape.GetType() == typeof(Ellipse))
            {
                var ellipse = shape as Ellipse;
                return $"{nameof(Ellipse)} ({ellipse.PositionX},{ellipse.PositionY}) diameterH = {ellipse.HorizontalDiameter} diameterV = {ellipse.VerticalDiameter}";
            }

            return string.Empty;
        }
    }
}
