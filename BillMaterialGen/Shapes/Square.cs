namespace BillMaterialGen.Shapes
{
    public class Square : Shape
    {
        protected Square(int positionX, int positionY, int width) : base(positionX, positionY)
        {
            Width = width;
        }

        public static Square Create(int positionX, int positionY, int width)
        {
            return new Square(positionX, positionY, width);
        }

        public int Width { get; private set; }
    }
}
