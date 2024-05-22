using System.Text;
using System.Security.Cryptography;


namespace DATA_INTEGRITY.REPORT
{
    internal class GenerateHashcode
    {
        public static void GenerateDigitalSignature(string filePath, string signatureFilePath)
        {
            // Read the file content
            string fileContent = File.ReadAllText(filePath);

            // Generate digital signature
            string signature = GenerateSHA256Hash(fileContent);

            // Write digital signature to file
            File.WriteAllText(signatureFilePath, signature);
        }
        static string GenerateSHA256Hash(string content)
        {
            // Generate SHA-256 hash
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(content));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
