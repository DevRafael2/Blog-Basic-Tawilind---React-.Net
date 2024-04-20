using System.Security.Cryptography;
using System.Text;

namespace Enternova.Blog.Helpers.EncryptHelper
{
    public static class EncryptHelper
    {
        public static string Sha256(this string text)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
