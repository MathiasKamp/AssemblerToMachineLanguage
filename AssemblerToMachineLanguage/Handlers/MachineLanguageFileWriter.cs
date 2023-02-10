  using System;
  using System.Collections.Generic;
  using System.IO;
  using AssemblerToMachineLanguage.Handlers.AsmFileHandler;
  using AssemblerToMachineLanguage.Utils;

  namespace AssemblerToMachineLanguage.Handlers
{
    public class MachineLanguageFileWriter
    {
        private List<string> FileContent { get; set; }

        private string MachineLanguageFileDirectory { get; set; }

        private string AsmFileName { get; set; }
        
        public DirectoryHandler DirectoryHandler { get; set; }


        public MachineLanguageFileWriter(List<string> fileContent, string asmFileName)
        {
            FileContent = fileContent;
            AsmFileName = asmFileName;

            MachineLanguageFileDirectory =
                SysUtil.GetRootPath.CheckTrailingSlash() + "AssemblyFiles".CheckTrailingSlash();

            DirUtil.CreateDirIfNotExists(MachineLanguageFileDirectory);

            DirectoryHandler = new DirectoryHandler(MachineLanguageFileDirectory);
        }


        public void WriteFile()
        {
            try
            {
                if (string.IsNullOrEmpty(AsmFileName) && string.IsNullOrWhiteSpace(AsmFileName))
                {
                    Console.WriteLine("file content is empty");
                    throw new ArgumentException("fileName is empty");
                }

                var fileName = Path.GetFileNameWithoutExtension(AsmFileName);
                
                var file = CreateHackFile(fileName);
                
                File.WriteAllLines(file, FileContent);

                Console.WriteLine($"file created at : {file}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string CreateHackFile(string fileName)
        {
            string file = DirectoryHandler.DirectoryOfAsmFile + fileName + ".hack";
            
            file.CreateFileIfNotExists();

            return file;

        }
    }
}