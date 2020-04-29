using System.Collections.Generic;
using BillMaterialGen.Data;

namespace BillMaterialGen.Readers.Interfaces
{
    public interface IConsoleInputRetriever
    {
        IEnumerable<ShapeDto> GetShapeInputs();
    }
}
