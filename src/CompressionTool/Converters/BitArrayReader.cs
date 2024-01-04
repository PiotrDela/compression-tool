using System.Collections;

namespace CompressionTool.Converters
{
    internal class BitArrayReader
    {
        public static BitArray ReadFrom(Stream stream)
        {
            var binaryReader = new BinaryReader(stream);
            var numberOfBits = binaryReader.ReadInt32();

            int numberOfBytesNeeded = numberOfBits / BitArrayConverter.NumberOfBitsInByte;

            if (numberOfBits % BitArrayConverter.NumberOfBitsInByte != 0)
            {
                numberOfBytesNeeded += 1;
            }

            var bytes = binaryReader.ReadBytes(numberOfBytesNeeded);
            var bitArray = new BitArray(bytes);

            var booleans = new bool[numberOfBits];
            for (int i = 0; i < numberOfBits; i++)
            {
                booleans[i] = bitArray[i];
            }

            return new BitArray(booleans);
        }
    }
}
