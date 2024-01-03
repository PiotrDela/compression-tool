namespace CompressionTool.Structures
{
    internal class HuffmanCodes
    {
        private readonly Dictionary<char, string> codes = new Dictionary<char, string>();

        public void Add(char character, string code)
        {
            codes.Add(character, code);
        }

        public string Get(char character)
        {
            return codes[character];
        }
    }
}
