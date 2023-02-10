using AssemblerToMachineLanguage.Handlers.AsmFileHandler;
using NUnit.Framework;

namespace AssemblerToMachineLanguage.Tests
{
    [TestFixture]
    public class Parser_Tests
    {
        private const string file = @"D:\asmFiles\max\Max.asm";
        private Parser Parser = new Parser(file);

        [Test]
        public void ShouldReturnBitValueOfAInstruction()
        {
            Parser.HandleAInstruction("@R2");
        }
    }
}