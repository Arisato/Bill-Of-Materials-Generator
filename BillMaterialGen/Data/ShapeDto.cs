using BillMaterialGen.Enums;

namespace BillMaterialGen.Data
{
    public class ShapeDto
    {
        public ShapeType ShapeType { get; set; }
        public string PositionX { get; set; }
        public string PositionY { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string HorizontalDiameter { get; set; }
        public string VerticalDiameter { get; set; }
        public string Text { get; set; }
    }
}
