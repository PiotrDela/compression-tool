using CompressionTool.Converters;
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
            
            Assert.Equal(1, table.GetCharacterCount('d'));
            Assert.Equal(1, table.GetCharacterCount('u'));
            Assert.Equal(2, table.GetCharacterCount('m'));
            Assert.Equal(1, table.GetCharacterCount('y'));
            Assert.Equal(1, table.GetCharacterCount(' '));
            Assert.Equal(2, table.GetCharacterCount('t'));
            Assert.Equal(1, table.GetCharacterCount('e'));
            Assert.Equal(1, table.GetCharacterCount('x'));
        }

        [Fact]
        public void WritingToStreamShouldWork()
        {
            var table = new CharacterFrequencyTable();
            table.Increase('a');
            table.Increase('b', 2);

            using (var memoryStream = new MemoryStream())
            {
                CharacterFrequencyTableWriter.WriteTo(memoryStream, table);
                memoryStream.Seek(0, SeekOrigin.Begin);

                var t2 = CharacterFrequencyTableReader.ReadFrom(memoryStream);
                Assert.Equal(2, t2.GetCharacterCount('b'));
                Assert.Equal(1, t2.GetCharacterCount('a'));
            }
        }
    }
}
