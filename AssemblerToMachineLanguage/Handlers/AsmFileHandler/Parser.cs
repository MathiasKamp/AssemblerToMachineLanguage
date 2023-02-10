using System.Collections.Generic;
using System.Linq;
using AssemblerToMachineLanguage.Handlers.AsmFileHandler.Instructions;
using AssemblerToMachineLanguage.Utils;

namespace AssemblerToMachineLanguage.Handlers.AsmFileHandler;

public class Parser
{
    private AsmFileReader AsmReader { get; }
    private SymbolTable SymbolTable { get; }

    private const string StartCInstruction = "111";
    private Code Code { get; }

    private List<string> RawAsmFileContent { get; }

    private List<string> AsmParsedToMachineLanguage { get; }

    private Dictionary<string, string> Labels { get; }


    // have dictionary to hold variables like @i, (LOOP) etc and their binary

    public Parser(string file)
    {
        AsmReader = new AsmFileReader(file);
        RawAsmFileContent = AsmReader.FileContent;
        SymbolTable = new SymbolTable();
        Code = new Code(SymbolTable);
        AsmParsedToMachineLanguage = new List<string>();
        Labels = new Dictionary<string, string>();
    }

    // run this before first run to scan for labels and symbols
    public void CollectLabels()
    {
        foreach (var str in RawAsmFileContent)
        {
            int index = RawAsmFileContent.FindIndex(a => a.Contains(str));

            if (str.StartsWith("(") && str.EndsWith(")"))
            {
                var replace = str.Replace("(", "");

                replace = replace.Replace(")", "");

                Labels.Add(replace, (index - Labels.Count).ToString());
            }
        }
    }


    public void TransferLabelsToSymbolTable()
    {
        if (!Labels.Any())
        {
            return;
        }

        foreach (var label in Labels.Where(label => !SymbolTable.ExistsInTable(label.Key)))
        {
            SymbolTable.AddToSymbolTable(label.Key, label.Value);
        }
    }

    public string HandleAInstruction(string command)
    {
        command = command.Replace("@", "");

        var alreadyExists = SymbolTable.ExistsInTable(command);

        if (alreadyExists) return SymbolTable.GetValueFromSymbolTable(command);
        // remove @ sign
        // add to symbolTable

        // check if the command without @ is only a number. if so just add the number to the symbolTable
        // otherwise get the maximum variable number starting from R15..

        bool isOnlyNumbers = command.IsOnlyNumbers();

        SymbolTable.AddToSymbolTable(command, !isOnlyNumbers ? DetermineVariableNumber().ToString() : command);
        
        return SymbolTable.GetValueFromSymbolTable(command);
    }

    private int DetermineVariableNumber()
    {
        var sortedSymbols = SymbolTable.SymbolTableTranslations.Where(x => x.Key != "SCREEN")
            .Where(y => y.Key != "KBD");

        var maxVal = sortedSymbols.Select(max => int.Parse(max.Value)).Max();

        return maxVal + 1;
    }

    private string HandleCInstruction(string command)
    {
        string cInstruction = string.Empty;

        if (command.Contains("="))
        {
            var commandValues = command.Split('=');

            var dest = Code.GetDestination(commandValues[0]);

            var comp = Code.GetComp(commandValues[1]);

            var jump = Code.GetJump("null");

            cInstruction = StartCInstruction + comp + dest + jump;
        }

        return cInstruction;
    }

    private string HandleJumpInstruction(string command)
    {
        string jumpInstruction = string.Empty;

        if (command.Contains(";"))
        {
            var values = command.Split(';');

            var comp = Code.GetComp(values[0]);

            var dest = Code.GetDestination("null");

            var jump = Code.GetJump(values[1]);

            jumpInstruction = StartCInstruction + comp + dest + jump;
        }

        return jumpInstruction;
    }

    public List<string> ParseAsmToML()
    {
        foreach (var command in RawAsmFileContent)


            if (command.StartsWith("@"))
            {
                AsmParsedToMachineLanguage.Add(HandleAInstruction(command));
            }

            else if (command.Contains("="))
            {
                AsmParsedToMachineLanguage.Add(HandleCInstruction(command));
            }

            else if (command.Contains(";"))
            {
                AsmParsedToMachineLanguage.Add(HandleJumpInstruction(command));
            }


        return AsmParsedToMachineLanguage;
    }

    public void CollectSymbols()
    {
        foreach (var command in RawAsmFileContent)
        {
            if (command.StartsWith("@"))
            {
                var trimmedCommand = command.Replace("@", "");

                var onlyLowerCase = trimmedCommand.IsOnlyLowerCase();

                bool isOnlyNumbers = trimmedCommand.IsOnlyNumbers();

                bool alreadyExists = SymbolTable.ExistsInTable(trimmedCommand);

                if (alreadyExists) continue;
                if (isOnlyNumbers)
                {
                    SymbolTable.AddToSymbolTable(trimmedCommand, trimmedCommand);
                }

                else if (onlyLowerCase)
                {
                    SymbolTable.AddToSymbolTable(trimmedCommand, DetermineVariableNumber().ToString());
                }
            }
        }
    }
}