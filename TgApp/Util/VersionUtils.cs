using System.Diagnostics;
using System.Reflection;

namespace TgApp.Util
{
    public class VersionUtils
    {
        private string path = Assembly.GetExecutingAssembly().Location;

        private readonly FileVersionInfo _versionInfo;
        public VersionUtils()
        {
            _versionInfo = FileVersionInfo.GetVersionInfo(path);
        }
        public string Version => _versionInfo.ProductVersion;

        public string Name => _versionInfo.ProductName;

    }
}
