using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Lab_4
{
    public class AsymmetricAlgorithm
    {
        private Dictionary<string, (byte[] publicKey, byte[] privateKey)> asymmetricKeys;
        private Dictionary<string, byte[]> encryptedData;

        public AsymmetricAlgorithm()
        {
            asymmetricKeys = new Dictionary<string, (byte[] publicKey, byte[] privateKey)>();
            encryptedData = new Dictionary<string, byte[]>();
        }

        public string Encrypt(string text, string keyName)
        {
            using (var rsa = RSA.Create())
            {
                if (!asymmetricKeys.ContainsKey(keyName))
                {
                    asymmetricKeys[keyName] = (rsa.ExportRSAPublicKey(), rsa.ExportRSAPrivateKey());
                }

                byte[] publicKey = asymmetricKeys[keyName].publicKey;

                rsa.ImportRSAPublicKey(publicKey, out _);

                byte[] encrypted = rsa.Encrypt(Encoding.UTF8.GetBytes(text), RSAEncryptionPadding.OaepSHA256);

                encryptedData[keyName] = encrypted;

                return Convert.ToBase64String(encrypted);
            }
        }

        public string Decrypt(string keyName)
        {
            if (!asymmetricKeys.ContainsKey(keyName))
            {
                throw new ArgumentException("Invalid asymmetric key name.");
            }

            byte[] privateKey = asymmetricKeys[keyName].privateKey;
            byte[] cipherText = encryptedData[keyName];

            using (var rsa = RSA.Create())
            {
                rsa.ImportRSAPrivateKey(privateKey, out _);

                byte[] decrypted = rsa.Decrypt(cipherText, RSAEncryptionPadding.OaepSHA256);

                return Encoding.UTF8.GetString(decrypted);
            }
        }

        public IEnumerable<string> GetKeys()
        {
            return asymmetricKeys.Keys;
        }
    }
}
