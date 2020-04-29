using System.Collections.Generic;
using BillMaterialGen.Data;

namespace BillMaterialGen.Validation.Interfaces
{
    public interface IInputValidator
    {
        bool IsInputValid(IEnumerable<ShapeDto> shapes);
    }
}
