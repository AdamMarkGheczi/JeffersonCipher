namespace Jefferson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] diskConfig = new int[] { 0, 5, 3, 2, 4, 1, 6 };

            JeffersonCipher jc = new JeffersonCipher(diskConfig.Length);

            string plainText = "This is plaintext";

            string encrypted = jc.Encrypt(plainText, diskConfig, 2);

            string decrypted = jc.Decrypt(encrypted, diskConfig, 2);

            Console.WriteLine($"Plaintext: {plainText}");
            Console.WriteLine($"Encrypted: {encrypted}");
            Console.WriteLine($"Decrypted: {decrypted}");

        }
    }
}