namespace BillMaterialGen.Logger.Interfaces
{
    public interface IErrorLogger
    {
        void LogParameterError(string paramName, string paramValue, string shapeName);
        void LogShapeLocationError(string paramNameOne, string paramNameTwo, string paramValueOne, string paramValueTwo, string shapeName);
    }
}
