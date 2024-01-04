using CompressionTool.Structures;

namespace CompressionTool.Converters
{
    internal class CharacterFrequencyTableReader
    {
        public static CharacterFrequencyTable ReadFrom(Stream stream)
        {
            var table = new CharacterFrequencyTable();

            var reader = new BinaryReader(stream);

            var count = reader.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                var key = reader.ReadChar();
                var value = reader.ReadInt32();

                table.Increase(key, value);
            }

            return table;
        }
    }
}
