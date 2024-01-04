using Xunit;

namespace CompressionTool.Tests
{
    public class HuffmanEncodingTests
    {
        [Theory]
        [InlineData("cccbba", "000111110")]
        [InlineData("cbbaaa", "101111000")]
        public void EncodeTests(string input, string expectedOutput)
        {
            Assert.Equal(expectedOutput, HuffmanEncoding.Encode(input));
        }

        [Theory]
        [InlineData("Lorem ipsum bla bla bla...")]
        [InlineData("Hello World")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam convallis arcu ut maximus elementum.")]
        public void DecodeTests(string inputText)
        {
            using (var stream = new MemoryStream())
            {
                HuffmanEncoding.Encode(inputText, stream);

                stream.Seek(0, SeekOrigin.Begin);
                var decoded = HuffmanEncoding.Decode(stream);

                Assert.Equal(inputText, decoded);
            }
        }
    }
}
