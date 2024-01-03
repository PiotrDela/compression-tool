namespace CompressionTool.Structures
{
    internal class HuffmanTreeNode
    {
        public char? Character { get; private set; }
        public int Frequency { get; private set; }

        public HuffmanTreeNode Left { get; private set; }

        public HuffmanTreeNode Right { get; private set; }

        public HuffmanTreeNode(char? character, int frequency) : this(character, frequency, null, null) { }                

        public HuffmanTreeNode(char? character, int frequency, HuffmanTreeNode left, HuffmanTreeNode right)
        {
            Character = character;
            Frequency = frequency;
            Left = left;
            Right = right;
        }
    }
}
