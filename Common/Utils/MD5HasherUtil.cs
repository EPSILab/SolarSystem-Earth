using System.Security.Cryptography;
using System.Text;

namespace SolarSystem.Earth.Common.Utils
{
    public static class MD5HasherUtil
    {
        public static string Hash(string word)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(word);
            byte[] hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();

            foreach (byte t in hash)
                sb.Append(t.ToString("x2"));

            return sb.ToString();
        }
    }
}