using System;
using System.IO;
using AssemblerToMachineLanguage.Utils;

namespace AssemblerToMachineLanguage.Handlers.AsmFileHandler;

public class DirectoryHandler
{
    private string MachineLanguageWorkingDirectory { get; }
    
    public string DirectoryOfAsmFile { get; private set; }

    public DirectoryHandler(string machineLanguageWorkingDirectory)
    {
        MachineLanguageWorkingDirectory = machineLanguageWorkingDirectory;
    }

    public void CopySourceAsmToWorkingDirectory(string file)
    {
        DirectoryOfAsmFile = CreateDestinationDirectoryFromFileName(file);

        var fileName = Path.GetFileName(file);

        var destinationAsmFile = DirectoryOfAsmFile.CheckTrailingSlash() + fileName;

        Console.WriteLine($"copying asm source file to {destinationAsmFile}");

        FileUtil.CopyFileToDestination(file, destinationAsmFile, true);
    }

    private string CreateDestinationDirectoryFromFileName(string fileName)
    {
        var name = FileUtil.GetFileNameFromFullPath(fileName);

        var workingDirectory = MachineLanguageWorkingDirectory.CheckTrailingSlash();

        var directory = workingDirectory.CheckTrailingSlash() + name.CheckTrailingSlash();

        DirUtil.CreateDirIfNotExists(directory);

        return directory;
    }
}