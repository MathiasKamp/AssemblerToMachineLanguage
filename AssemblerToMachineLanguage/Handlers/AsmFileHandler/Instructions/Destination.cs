using System.Collections.Generic;

namespace AssemblerToMachineLanguage.Handlers.AsmFileHandler.Instructions;

public class Destination
{
    public Dictionary<string, string> Destinations { get; }

    public Destination()
    {
        Destinations = new Dictionary<string, string>();
        FillInstructionDestinations();
    }

    private void FillInstructionDestinations()
    {
        Destinations.Add("null","000");
        Destinations.Add("M","001");
        Destinations.Add("D","010");
        Destinations.Add("MD","011");
        Destinations.Add("A","100");
        Destinations.Add("AM","101");
        Destinations.Add("AD","110");
        Destinations.Add("AMD","111");
    }
}