using System.Collections.Generic;
using BillMaterialGen.Shapes;

namespace BillMaterialGen.Readers.Interfaces
{
    public interface IReader
    {
        IEnumerable<Shape> GetShapesData();
    }
}
