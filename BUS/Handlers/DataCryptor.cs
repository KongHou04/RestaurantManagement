using System.Text;
using System.Security.Cryptography;

namespace BUS.Handler
{
    public static class DataCryptor
    {
        public static string EncodeString(this string source)
        {
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(source);

                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);

                // Convert hash byte array to string
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                // return MD5 hash
                return hash;
            }
        }
    }
}


