namespace BillMaterialGen.Shapes
{
    public class Circle : Shape
    {
        protected Circle(int positionX, int positionY, int horizontalDiameter) : base(positionX, positionY)
        {
            HorizontalDiameter = horizontalDiameter;
        }

        public static Circle Create(int positionX, int positionY, int horizontalDiameter)
        {
            return new Circle(positionX, positionY, horizontalDiameter);
        }

        public int HorizontalDiameter { get; private set; }
    }
}
