namespace BillMaterialGen.Configuration.Interfaces
{
    public interface ISettings
    {
        int CanvasSize { get; set; }
        string LegacyBuilderErrorCode { get; set; }
    }
}
