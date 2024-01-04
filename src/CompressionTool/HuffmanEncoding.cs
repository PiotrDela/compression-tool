using CompressionTool.Converters;
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

            var huffmanTree = BuildHuffmanTree(CharacterFrequencyTable.Build(text));
            var huffmanCodes = HuffmanTreeVisitor.Visit(huffmanTree);

            return Encode(text, huffmanCodes);
        }

        public static string Decode(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var huffmanTree = BuildHuffmanTree(CharacterFrequencyTableReader.ReadFrom(stream));

            var bitArray = BitArrayReader.ReadFrom(stream);

            var stringBuilder = new StringBuilder();

            var currentNode = huffmanTree.RootNode;
            for (int i = 0; i < bitArray.Length; i++)
            {
                if (bitArray[i])
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode = currentNode.Left;
                }

                if (currentNode.Left == null && currentNode.Right == null)
                {
                    stringBuilder.Append(currentNode.Character);
                    currentNode = huffmanTree.RootNode;
                }              
            }

            return stringBuilder.ToString();
        }

        public static void Encode(string text, Stream stream)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException($"{nameof(text)} cannot be null nor empty", nameof(text));
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var characterFrequencyTable = CharacterFrequencyTable.Build(text);
            var huffmanTree = BuildHuffmanTree(characterFrequencyTable);
            var huffmanCodes = HuffmanTreeVisitor.Visit(huffmanTree);

            var binaryString = Encode(text, huffmanCodes);
            var arrayOfBits = BitArrayConverter.FromString(binaryString);

            CharacterFrequencyTableWriter.WriteTo(stream, characterFrequencyTable);
            BitArrayWriter.WriteTo(stream, arrayOfBits);
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
