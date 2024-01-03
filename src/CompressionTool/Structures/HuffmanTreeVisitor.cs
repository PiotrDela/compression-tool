namespace CompressionTool.Structures
{
    internal class HuffmanTreeVisitor
    {
        public static HuffmanCodes Visit(HuffmanTree tree)
        {
            var huffmanCodes = new HuffmanCodes();

            VisitTreeNode(tree.RootNode, huffmanCodes, string.Empty);

            return huffmanCodes;
        }

        private static void VisitTreeNode(HuffmanTreeNode treeNode, HuffmanCodes codes, string prefix)
        {
            if (treeNode == null)
            {
                return;
            }

            if (treeNode.Character.HasValue)
            {
                codes.Add(treeNode.Character.Value, prefix);
            }

            VisitTreeNode(treeNode.Left, codes, prefix + "0");
            VisitTreeNode(treeNode.Right, codes, prefix + "1");
        }
    }
}
