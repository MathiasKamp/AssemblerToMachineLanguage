using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AssemblerToMachineLanguage.Handlers.AsmFileHandler;

public class AsmFileReader
{
    private string AsmFileToRead { get; }

    private readonly Regex commentRegex = new(@"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/");
    
    public List<string> FileContent { get; private set; }

    public AsmFileReader(string file)
    {
        AsmFileToRead = file;
        FileContent = new List<string>();
        ReadAsmFile();
    }

    private void ReadAsmFile()
    {
        var fileContent = File.ReadAllLines(AsmFileToRead).Where(arg => !string.IsNullOrWhiteSpace(arg) || !string.IsNullOrEmpty(arg)).ToList();
        
        if (!fileContent.Any()) return;

        FileContent = TrimFileContent(fileContent);
        
    }

    private List<string> TrimFileContent(List<string> content)
    {
        content = RemoveCommentsFromAsm(content);
        content = RemoveWhiteSpaces(content);
        content = RemoveEmptyLines(content);

        return content;
    }
 
    private static List<string> RemoveEmptyLines(List<string> content)
    {
        content.RemoveAll(s => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s));

        return content;
    }
    

    private static List<string> RemoveWhiteSpaces(IEnumerable<string> content)
    {
        return content.Select(str => Regex.Replace(str, @"\s+", "")).ToList();
    }
    
    private List<string> RemoveCommentsFromAsm(IEnumerable<string> fileContent)

    {
        return fileContent.Select(str => commentRegex.Replace(str, "")).ToList();
    }
}