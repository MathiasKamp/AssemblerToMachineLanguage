using System.Collections.Generic;

namespace AssemblerToMachineLanguage.Handlers.AsmFileHandler.Instructions;

public class Jump
{
    public Dictionary<string, string> Jumps { get; }

    public Jump()
    {
        Jumps = new Dictionary<string, string>();
        FillJumpInstructions();
    }

    private void FillJumpInstructions()
    {
        Jumps.Add("null","000");
        Jumps.Add("JGT","001");
        Jumps.Add("JEQ","010");
        Jumps.Add("JGE","011");
        Jumps.Add("JLT","100");
        Jumps.Add("JNE","101");
        Jumps.Add("JLE","110");
        Jumps.Add("JMP","111");
    }
}