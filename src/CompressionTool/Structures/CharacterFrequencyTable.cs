using System.Collections;

namespace CompressionTool.Structures
{
    internal class CharacterFrequencyTable: IEnumerable<KeyValuePair<char, int>>
    {
        internal static CharacterFrequencyTable Build(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            var table = new CharacterFrequencyTable();

            foreach (char c in text)
            {
                table.Increase(c);
            }

            return table;
        }

        private readonly SortedDictionary<char, int> frequencyTable = new SortedDictionary<char, int>();

        public int Count => frequencyTable.Count;

        public void Increase(char character, int count = 1)
        {
            if (frequencyTable.TryGetValue(character, out int val))
            {
                frequencyTable[character] = val + count;
            }
            else
            {
                frequencyTable.Add(character, count);
            }
        }

        public int GetCharacterCount(char character)
        {
            return frequencyTable[character];
        }
        
        public IEnumerator<KeyValuePair<char, int>> GetEnumerator()
        {
            return frequencyTable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
