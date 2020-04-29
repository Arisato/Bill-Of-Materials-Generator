using BillMaterialGen.Configuration.Interfaces;

namespace BillMaterialGen.Configuration
{
    public class Settings : ISettings
    {
        public int CanvasSize { get; set; }
        public string LegacyBuilderErrorCode { get; set; }
    }
}
