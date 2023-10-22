using System.Net.Http.Headers;

namespace Jefferson
{
    internal class JeffersonCipher
    {

        private string[] disks;

        public string[] GetDisks() => disks;

        public JeffersonCipher(int numberOfDisks)
        {
            disks = new string[numberOfDisks];
            for (int i = 0; i < numberOfDisks; i++) disks[i] = FisherYates();
        }

        public string Encrypt(string input, int[] diskOrder, int rowOffset) => TransformText(input, diskOrder, rowOffset, forward: true);
        public string Decrypt(string input, int[] diskOrder, int rowOffset) => TransformText(input, diskOrder, rowOffset, forward: false);

        private string TransformText(string inputText, int[] diskOrder, int rowOffset, bool forward)
        {
            inputText = new string(inputText.Where(Char.IsLetter).ToArray()).ToLower();

            rowOffset = forward ? rowOffset : -rowOffset;

            string[] localArrangement = new string[disks.Length];
            for (int i = 0; i < diskOrder.Length; i++) localArrangement[i] = disks[diskOrder[i]];

            return new string(inputText.Select((c, i) => GetShiftedChar(disks[i % disks.Length], c, rowOffset)).ToArray());
        }

        private char GetShiftedChar (string disk, char c, int offset)
        {
            int index = disk.IndexOf(c) + offset;
            index = (index % disk.Length + disk.Length) % disk.Length;

            return disk[index];
        }

        private string FisherYates()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            Random rnd = new Random();
            for (int i = alphabet.Length - 1; i >= 0; i--)
            {
                int j = rnd.Next(i + 1);
                (alphabet[i], alphabet[j]) = (alphabet[j], alphabet[i]);
            }

            return new string(alphabet);
        }

    }
}
