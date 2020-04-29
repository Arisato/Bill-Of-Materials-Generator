using System.Collections.Generic;
using BillMaterialGen.Shapes;

namespace BillMaterialGen.Generators.Interfaces
{
    public interface IBillMaterialGenerator
    {
        string GetBillOfMaterials(IEnumerable<Shape> shapes);
    }
}
