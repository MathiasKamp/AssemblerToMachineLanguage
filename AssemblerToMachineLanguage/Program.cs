using System;
using System.IO;
using AssemblerToMachineLanguage.Handlers;
using AssemblerToMachineLanguage.Handlers.AsmFileHandler;


namespace AssemblerToMachineLanguage
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("only use 1 argument. ie : full path to .asm file");
                return;
            }

            var file = args[0];

            if (!File.Exists(file))
            {
                Console.WriteLine($"file {file} does not exists");
                return;
            }

            var parser = new Parser(file);
            
            parser.CollectLabels();
            
            parser.CollectSymbols();

            parser.TransferLabelsToSymbolTable();

            var binaryFileContent = parser.ParseAsmToML();

            var fileWriter = new MachineLanguageFileWriter(binaryFileContent, file);

            fileWriter.DirectoryHandler.CopySourceAsmToWorkingDirectory(file);

            fileWriter.WriteFile();
        }
    }
}