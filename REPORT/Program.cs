using System.Reflection;
using System.Text;

namespace DATA_INTEGRITY.REPORT
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string ReportFilePath = @".\..\..\..\Report\SampleReport.html";

            // Generate checksum for HTML file
            //GenerateHashcode.GenerateDigitalSignature(ReportFilePath, @".\..\..\..\Report\checksum_file.txt");

            // Verify integrity of the  file
            VerifyData.Verifyfile(ReportFilePath, @".\..\..\..\Report\checksum_file.txt");
        }


    }
}
