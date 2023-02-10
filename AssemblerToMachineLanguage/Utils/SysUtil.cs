using System.IO;

namespace AssemblerToMachineLanguage.Utils;

public static class SysUtil
{
    public static readonly string GetRootPath =
        Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
}