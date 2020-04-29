namespace BillMaterialGen.Shapes
{
    public class Rectangle : Square
    {
        protected Rectangle(int positionX, int positionY, int width, int height) : base(positionX, positionY, width)
        {
            Height = height;
        }

        public static Rectangle Create(int positionX, int positionY, int width, int height)
        {
            return new Rectangle(positionX, positionY, width, height);
        }

        public int Height { get; private set; }
    }
}
