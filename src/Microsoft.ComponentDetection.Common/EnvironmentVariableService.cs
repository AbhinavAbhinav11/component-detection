using System;
using System.Linq;
using System.Composition;
using Microsoft.ComponentDetection.Contracts;

namespace Microsoft.ComponentDetection.Common
{
    [Export(typeof(IEnvironmentVariableService))]
    public class EnvironmentVariableService : IEnvironmentVariableService
    {
        public bool DoesEnvironmentVariableExist(string name)
        {
            // Environment variables are case-insensitive on Windows, and case-sensitive on
            // Linux and MacOS.
            // https://docs.microsoft.com/en-us/dotnet/api/system.environment.getenvironmentvariable
            return Environment.GetEnvironmentVariables().Keys
                .OfType<string>()
                .FirstOrDefault(x => string.Compare(x, name, true) == 0) != null;
        }
    }
}