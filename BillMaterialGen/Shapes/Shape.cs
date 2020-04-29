namespace BillMaterialGen.Shapes
{
    public class Shape
    {
        protected Shape(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public int PositionX { get; private set; }

        public int PositionY { get; private set; }
    }
}
