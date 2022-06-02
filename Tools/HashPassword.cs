using System.Security.Cryptography;
using System.Text;

namespace EasyToEnter.ASP.Tools
{
    public static class HashPassword
    {
        public static string HashPasswordSHA256(string password)
        {
            using SHA256 sha256 = SHA256.Create();

            byte[] passwordByteArray = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            string hashPassword = BitConverter.ToString(passwordByteArray).Replace("-", "").ToLower();

            sha256.Clear();

            return hashPassword;
        }
    }
}