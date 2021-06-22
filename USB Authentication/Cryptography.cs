using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace USB_Authentication
{
    static class Cryptography
    {
        public static string HashSHA512(this string toEncrypt)
        {
            byte[] toEncryptBytes = Encoding.UTF8.GetBytes(toEncrypt);
            byte[] encryptedBytes;

            using (SHA512 shaManaged = new SHA512Managed())
                encryptedBytes = shaManaged.ComputeHash(toEncryptBytes);

            return Convert.ToBase64String(encryptedBytes);
        }
    }
}
