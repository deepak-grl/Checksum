using System.Security.Cryptography;
using System.Text;

namespace DATA_INTEGRITY.REPORT
{
    class VerifyData
    {
        public static void Verifyfile(string filepath, string storedChecksumFilePath)
        {
            bool isXMLIntegrityValid = VerifyIntegrity(filepath, storedChecksumFilePath);
            if (isXMLIntegrityValid)
            {
                Console.WriteLine("file integrity verified. No changes detected.");
            }
            else
            {
                Console.WriteLine("file integrity check failed. Changes detected.");
            }
        }
        static bool VerifyIntegrity(string filePath, string storedChecksumFilePath)
        {
            // Read the file content and stored checksum
            string fileContent = File.ReadAllText(filePath);
            string storedChecksum = File.ReadAllText(storedChecksumFilePath);

            // Calculate checksum of the file content
            string regeneratedChecksum = CalculateChecksum(fileContent);

            // Compare regenerated checksum with stored checksum
            return string.Equals(regeneratedChecksum, storedChecksum, StringComparison.OrdinalIgnoreCase);
        }
        static string CalculateChecksum(string content)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(content));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
