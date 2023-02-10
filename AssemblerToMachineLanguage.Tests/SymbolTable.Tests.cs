using AssemblerToMachineLanguage.Handlers.AsmFileHandler.Instructions;
using NUnit.Framework;

namespace AssemblerToMachineLanguage.Tests
{
    [TestFixture]
    public class SymbolTable_Tests
    {
        private readonly SymbolTable symbolTable = new SymbolTable();
        [Test]
        public void ShouldAddToDictionaryIfNotExists()
        {
            var alreadyExists = symbolTable.ExistsInTable("test");

            if (!alreadyExists)
            {
                symbolTable.AddToSymbolTable("test","test");
            }

            alreadyExists = symbolTable.ExistsInTable("test");
            
            Assert.True(alreadyExists);

        }
    }
}