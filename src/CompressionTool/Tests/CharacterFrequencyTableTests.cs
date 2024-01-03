using CompressionTool.Structures;
using Xunit;

namespace CompressionTool.Tests
{
    public class CharacterFrequencyTableTests
    {
        [Fact]
        public void Test()
        {
            var table = CharacterFrequencyTable.Build("dummy text");
            
            Assert.Equal(1, table.GetCount('d'));
            Assert.Equal(1, table.GetCount('u'));
            Assert.Equal(2, table.GetCount('m'));
            Assert.Equal(1, table.GetCount('y'));
            Assert.Equal(1, table.GetCount(' '));
            Assert.Equal(2, table.GetCount('t'));
            Assert.Equal(1, table.GetCount('e'));
            Assert.Equal(1, table.GetCount('x'));
        }
    }
}
