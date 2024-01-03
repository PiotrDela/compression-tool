using CompressionTool.Structures;
using System.Text;

namespace CompressionTool
{
    internal class HuffmanEncoding
    {
        public static string Encode(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException($"{nameof(text)} cannot be null nor empty", nameof(text));
            }

            var characterFrequencyTable = CharacterFrequencyTable.Build(text);
            var huffmanTree = BuildHuffmanTree(characterFrequencyTable);
            var huffmanCodes = HuffmanTreeVisitor.Visit(huffmanTree);

            return Encode(text, huffmanCodes);
        }

        private static HuffmanTree BuildHuffmanTree(CharacterFrequencyTable characterFrequencyTable)
        {
            var priorityQueue = new PriorityQueue<HuffmanTreeNode, int>();

            foreach (var item in characterFrequencyTable)
            {
                var character = item.Key;
                var frequency = item.Value;

                priorityQueue.Enqueue(new HuffmanTreeNode(character, frequency), frequency);
            }

            while (priorityQueue.Count > 1)
            {
                var item1 = priorityQueue.Dequeue();
                var item2 = priorityQueue.Dequeue();

                var weight = item1.Frequency + item2.Frequency;

                priorityQueue.Enqueue(new HuffmanTreeNode(null, weight, item1, item2), weight);
            }

            return new HuffmanTree(priorityQueue.Dequeue());
        }

        private static string Encode(string text, HuffmanCodes huffmanCodes)
        {
            var stringBuilder = new StringBuilder();

            foreach (var character in text)
            {
                stringBuilder.Append(huffmanCodes.Get(character));
            }

            return stringBuilder.ToString();
        }
    }
}
