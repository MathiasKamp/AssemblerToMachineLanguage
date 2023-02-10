using System.Collections.Generic;
using AssemblerToMachineLanguage.Utils;

namespace AssemblerToMachineLanguage.Handlers.AsmFileHandler.Instructions;

public class SymbolTable
{
    public Dictionary<string, string> SymbolTableTranslations { get; }
    
    public SymbolTable()
    {
        SymbolTableTranslations = new Dictionary<string, string>();
        FillSymbolTable();
    }


    private void FillSymbolTable()
    {
        SymbolTableTranslations.Add("R0", "0");
        SymbolTableTranslations.Add("R1", "1");
        SymbolTableTranslations.Add("R2", "2");
        SymbolTableTranslations.Add("R3", "3");
        SymbolTableTranslations.Add("R4", "4");
        SymbolTableTranslations.Add("R5", "5");
        SymbolTableTranslations.Add("R6", "6");
        SymbolTableTranslations.Add("R7", "7");
        SymbolTableTranslations.Add("R8", "8");
        SymbolTableTranslations.Add("R9", "9");
        SymbolTableTranslations.Add("R10", "10");
        SymbolTableTranslations.Add("R11", "11");
        SymbolTableTranslations.Add("R12", "12");
        SymbolTableTranslations.Add("R13", "13");
        SymbolTableTranslations.Add("R14", "14");
        SymbolTableTranslations.Add("R15", "15");
        SymbolTableTranslations.Add("0", "0");
        SymbolTableTranslations.Add("1", "1");
        SymbolTableTranslations.Add("2", "2");
        SymbolTableTranslations.Add("3", "3");
        SymbolTableTranslations.Add("4", "4");
        SymbolTableTranslations.Add("5", "5");
        SymbolTableTranslations.Add("6", "6");
        SymbolTableTranslations.Add("7", "7");
        SymbolTableTranslations.Add("8", "8");
        SymbolTableTranslations.Add("9", "9");
        SymbolTableTranslations.Add("10", "10");
        SymbolTableTranslations.Add("11", "11");
        SymbolTableTranslations.Add("12", "12");
        SymbolTableTranslations.Add("13", "13");
        SymbolTableTranslations.Add("14", "14");
        SymbolTableTranslations.Add("15", "15");
        SymbolTableTranslations.Add("SCREEN", "16384");
        SymbolTableTranslations.Add("KBD", "24576");
        SymbolTableTranslations.Add("SP", "0");
        SymbolTableTranslations.Add("LCL", "1");
        SymbolTableTranslations.Add("ARG", "2");
        SymbolTableTranslations.Add("THIS", "3");
        SymbolTableTranslations.Add("THAT", "4");
    }


    // returns 16 bit binary of the integer value in the dictionary
    public string GetValueFromSymbolTable(string key)
    {
        SymbolTableTranslations.TryGetValue(key, out var val);

        return !string.IsNullOrEmpty(val) ? IntUtil.ConvertIntTo16BitBinary(val) : "";
    }

    public void AddToSymbolTable(string key, string value)
    {
        var alreadyExists = ExistsInTable(key);

        if (!alreadyExists)
        {
            SymbolTableTranslations.Add(key, value);
        }
    }

    public bool ExistsInTable(string key)
    {
        SymbolTableTranslations.TryGetValue(key, out var val);

        return !string.IsNullOrEmpty(val);
    }
}