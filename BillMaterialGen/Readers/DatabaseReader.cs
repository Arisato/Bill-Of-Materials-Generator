using System.Collections.Generic;
using BillMaterialGen.Readers.Interfaces;
using BillMaterialGen.Shapes;

namespace BillMaterialGen.Readers
{
    public class DatabaseReader : IDatabaseReader
    {
        public IEnumerable<Shape> GetShapesData()
        {
            return new Shape[]
            {
                Rectangle.Create(10,10,30,40),
                Square.Create(500,30,35),
                Ellipse.Create(100,150,300,200),
                Circle.Create(1,1,300),
                Textbox.Create(5,5,200,100,"sample text")
            };
        }
    }
}
