namespace BillMaterialGen.Shapes
{
    public class Ellipse : Circle
    {
        protected Ellipse(int positionX, int positionY, int horizontalDiameter, int verticalDiameter) :
            base(positionX, positionY, horizontalDiameter)
        {
            VerticalDiameter = verticalDiameter;
        }

        public static Ellipse Create(int positionX, int positionY, int horizontalDiameter, int verticalDiameter)
        {
            return new Ellipse(positionX, positionY, horizontalDiameter, verticalDiameter);
        }

        public int VerticalDiameter { get; private set; }
    }
}
