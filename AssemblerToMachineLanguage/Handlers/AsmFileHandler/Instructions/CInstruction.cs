using System.Collections.Generic;

namespace AssemblerToMachineLanguage.Handlers.AsmFileHandler.Instructions;

public class CInstruction
{
    public Dictionary<string, string> CInstructions { get; }

    public CInstruction()
    {
        CInstructions = new Dictionary<string, string>();
        FillCInstructionsA0();
        FillCInstructionsA1();
    }

    private void FillCInstructionsA0()
    {
        CInstructions.Add("0","0101010");
        CInstructions.Add("1","0111111");
        CInstructions.Add("-1","0111010");
        CInstructions.Add("D","0001100");
        CInstructions.Add("A","0110000");
        CInstructions.Add("!D","0001101");
        CInstructions.Add("!A","0110001");
        CInstructions.Add("-D","0001101");
        CInstructions.Add("-A","0110011");
        CInstructions.Add("D+1","0011111");
        CInstructions.Add("A+1","0110111");
        CInstructions.Add("D-1","0001110");
        CInstructions.Add("A-1","0110010");
        CInstructions.Add("D+A","0000010");
        CInstructions.Add("D-A","0010011");
        CInstructions.Add("A-D","00000111");
        CInstructions.Add("D&A","0000000");
        CInstructions.Add("D|A","0010101");
    }

    private void FillCInstructionsA1()
    {
        CInstructions.Add("M","1110000");
        CInstructions.Add("!M","1110001");
        CInstructions.Add("-M","1110011");
        CInstructions.Add("M+1","1110111");
        CInstructions.Add("M-1","1110010");
        CInstructions.Add("D+M","1000010");
        CInstructions.Add("D-M","1010011");
        CInstructions.Add("M-D","1000111");
        CInstructions.Add("D&M","1000000");
        CInstructions.Add("D|M","1010101");
    }
}