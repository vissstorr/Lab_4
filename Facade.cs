
using System.Collections.Generic;
namespace Lab_4
{
    public class Facade
    {
        private SymmetricAlgorithm _symmetricEncryption;
        private AsymmetricAlgorithm _asymmetricEncryption;
        private HashAlgorithm _hashAlgorithm;

        public Facade()
        {
            _symmetricEncryption = new SymmetricAlgorithm();
            _asymmetricEncryption = new AsymmetricAlgorithm();
            _hashAlgorithm = new HashAlgorithm();

        }
       
        public string EncryptSymmetric(string text,string key)
        {
            return _symmetricEncryption.Encrypt(text, key);
        }

        public string EncryptAsymmetric(string text, string key)
        {
            return _asymmetricEncryption.Encrypt(text, key);
        }

        public string DecryptSymmetric(string key)
        {
            return _symmetricEncryption.Decrypt(key);
        }

        public string DecryptAsymmetric(string key)
        {
            return _asymmetricEncryption.Decrypt(key);
        }

        public IEnumerable<string> GetSymmetricKeys()
        {
            return _symmetricEncryption.GetKeys();
        }

        public IEnumerable<string> GetAsymmetricKeys()
        {
            return _asymmetricEncryption.GetKeys();
        }
        public byte[] Hash(string key)
        {
            return _hashAlgorithm.CalculateHash(key);
        }
    }
}
