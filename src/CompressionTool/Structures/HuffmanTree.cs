namespace CompressionTool.Structures
{
    internal class HuffmanTree
    {
        public HuffmanTreeNode RootNode { get; private set; }

        public HuffmanTree(HuffmanTreeNode rootNode)
        {
            RootNode = rootNode ?? throw new ArgumentNullException(nameof(rootNode));
        }
    }
}
