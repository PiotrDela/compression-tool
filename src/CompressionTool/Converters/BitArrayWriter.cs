using System.Collections;

namespace CompressionTool.Converters
{
    internal class BitArrayWriter
    {
        public static void WriteTo(Stream stream, BitArray bits)
        {
            var binaryWriter = new BinaryWriter(stream);
            binaryWriter.Write(bits.Length);

            var bitsAsBytes = BitArrayConverter.GetBytes(bits);
            binaryWriter.Write(bitsAsBytes);

            binaryWriter.Flush();
        }
    }
}
