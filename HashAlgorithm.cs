using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Lab_4
{
    public class HashAlgorithm
    {
        public byte[] CalculateHash(string key)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedKey = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
                return hashedKey;
            }
        }
    }
}
