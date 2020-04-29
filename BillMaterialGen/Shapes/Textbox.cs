namespace BillMaterialGen.Shapes
{
    public class Textbox : Rectangle
    {
        protected Textbox(int positionX, int positionY, int width, int height, string text) :
            base(positionX, positionY, width, height)
        {
            Text = text;
        }

        public static Textbox Create(int positionX, int positionY, int width, int height, string text)
        {
            return new Textbox(positionX, positionY, width, height, text);
        }

        public string Text { get; private set; }
    }
}
