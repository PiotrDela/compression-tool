using System.Collections;

namespace CompressionTool.Converters
{
    internal class BitArrayWriter
    {
        public static void WriteTo(Stream stream, BitArray bits)
        {
            var binaryWriter = new BinaryWriter(stream);

            binaryWriter.Write(bits.Length);
            binaryWriter.Write(BitArrayConverter.ToBytes(bits));

            binaryWriter.Flush();
        }
    }
}
