using AssemblerToMachineLanguage.Extensions;
using AssemblerToMachineLanguage.Handlers.AsmFileHandler.Instructions;

namespace AssemblerToMachineLanguage.Handlers.AsmFileHandler;

/**
 * This class has the purpose of translating assembly commands to binary
 */
public class Code
{
    private CInstruction CInstruction { get; }
    private Destination Destination { get; }
    private Jump Jump { get; }
    private SymbolTable SymbolTable { get; }

    public Code(SymbolTable symbolTable)
    {
        CInstruction = new CInstruction();
        Destination = new Destination();
        Jump = new Jump();
        SymbolTable = symbolTable;
    }

    public string GetComp(string command)
    {
        return CInstruction.CInstructions[command];
    }

    public string GetDestination(string command)
    {
        // return default null key of destinations
        return Destination.Destinations.GetValueOrDefault(command, "000");
    }

    // returns default the null key if the key does not exist in the dictionary
    public string GetJump(string command)
    {
        // return default null key of jumps
        return Jump.Jumps.GetValueOrDefault(command, "000");
    }
}