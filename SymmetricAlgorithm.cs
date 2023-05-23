using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;


namespace Lab_4
{
    public class SymmetricAlgorithm
    {
        private Dictionary<string, byte[]> encryptedData;
        private HashAlgorithm hashAlgorithm;
        public SymmetricAlgorithm()
        {
            hashAlgorithm = new HashAlgorithm();
            encryptedData = new Dictionary<string, byte[]>();
        }

        public string Encrypt(string text,string mainKey)
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateIV();
                byte[] iv = aes.IV;
                byte[] encrypted;
                using (var encryptor = aes.CreateEncryptor(hashAlgorithm.CalculateHash(mainKey), iv))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(cs))
                            {
                                swEncrypt.Write(text);
                            }
                            encrypted = ms.ToArray();
                        }
                    }
                }
                byte[] upgradeText = iv.Concat(encrypted).ToArray();
                encryptedData[mainKey] = upgradeText;
                return Convert.ToBase64String(upgradeText);
            }
        }

        public string Decrypt(string keyName)
        {
            if (!encryptedData.ContainsKey(keyName))
            {
                throw new ArgumentException("Invalid key.");
            }
            byte[] cipherText = encryptedData[keyName];
            using (var aes = Aes.Create())
            {
                int ivLength = aes.BlockSize / 8;
                byte[] iv = new byte[ivLength];
                byte[] encrypted = new byte[cipherText.Length - ivLength];
                using (var ms = new MemoryStream(cipherText))
                {
                    ms.Read(iv, 0, iv.Length);
                    ms.Read(encrypted, 0, encrypted.Length);
                }
                string decrypted;
                using (var decryptor = aes.CreateDecryptor(hashAlgorithm.CalculateHash(keyName), iv))
                using (var ms = new MemoryStream(encrypted))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(cs))
                {
                    decrypted = reader.ReadToEnd();
                }
                return decrypted;
            }
        }
        
        public IEnumerable<string> GetKeys()
        {
            return encryptedData.Keys;
        }

    }
}
