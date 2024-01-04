using CompressionTool.Structures;

namespace CompressionTool.Converters
{
    internal class CharacterFrequencyTableWriter
    {
        public static void WriteTo(Stream stream, CharacterFrequencyTable table)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var writer = new BinaryWriter(stream);

            writer.Write(table.Count);

            foreach (var item in table)
            {
                writer.Write(item.Key);
                writer.Write(item.Value);
            }

            writer.Flush();
        }
    }
}
