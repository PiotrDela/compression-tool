using System.Collections;

namespace CompressionTool.Converters
{
    internal static class BitArrayConverter
    {
        public const byte NumberOfBitsInByte = 8;

        public static byte[] ToBytes(BitArray bits)
        {
            int numberOfBytesNeeded = bits.Length / NumberOfBitsInByte;

            if (bits.Length % NumberOfBitsInByte != 0)
            {
                numberOfBytesNeeded += 1;
            }

            var bytes = new byte[numberOfBytesNeeded];
            bits.CopyTo(bytes, 0);
            return bytes;
        }

        public static BitArray FromString(string binaryString)
        {
            return new BitArray(binaryString.Select(x => x == '1').ToArray());
        }
    }
}
