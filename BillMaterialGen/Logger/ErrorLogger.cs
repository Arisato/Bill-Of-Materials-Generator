using BillMaterialGen.Logger.Interfaces;
using Serilog;

namespace BillMaterialGen.Logger
{
    public class ErrorLogger : IErrorLogger
    {
        private readonly ILogger logger;

        public ErrorLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public void LogParameterError(string paramName, string paramValue, string shapeName)
        {
            logger.Debug($"Invalid parameter value of {paramName}: [{paramValue}] for shape: {shapeName}");
        }

        public void LogShapeLocationError(string paramNameOne, string paramNameTwo, string paramValueOne, string paramValueTwo, string shapeName)
        {
            logger.Debug($"Invalid locaion value for {paramNameOne}: [{paramValueOne}] in respect to {paramNameTwo}: [{paramValueTwo}] of shape: {shapeName}");
        }
    }
}
