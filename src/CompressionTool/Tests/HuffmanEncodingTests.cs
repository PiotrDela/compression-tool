using Xunit;

namespace CompressionTool.Tests
{
    public class HuffmanEncodingTests
    {
        [Theory]
        [InlineData("cccbba", "000111110")]
        [InlineData("cbbaaa", "101111000")]
        public void EncodingTests(string input, string expectedOutput)
        {
            Assert.Equal(expectedOutput, HuffmanEncoding.Encode(input));
        }
    }
}
