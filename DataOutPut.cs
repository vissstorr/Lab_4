using Lab_4.Interface;
using System;


namespace Lab_4
{
    public class DataOutPut: IDataOutPut
    {
        private Facade _facade;
        public DataOutPut(Facade facade)
        {
            _facade = facade;
        }
       
        public void EncryptSymmetric()
        {
            Console.Write("Enter text to encrypt: ");
            string symmetricPlainText = Console.ReadLine();
            Console.Write("Enter key to encrypt: ");
            string key = Console.ReadLine();
            Console.WriteLine($"Text encrypted :{_facade.EncryptSymmetric(symmetricPlainText, key)}");
        }
        public void EncryptAsymmetric()
        {
            Console.Write("Enter text to encrypt: ");
            string asymmetricPlainText = Console.ReadLine();
            Console.Write("Enter keyname to encrypt: ");
            string asymmetricNameKey = Console.ReadLine();
            Console.WriteLine($"Text encrypted : {_facade.EncryptAsymmetric(asymmetricPlainText, asymmetricNameKey)}");
        }
        public void DecryptSymmetric()
        {
            Console.WriteLine("Key name:");
            foreach (var key in _facade.GetSymmetricKeys())
            {
                Console.WriteLine(key);
            }
            Console.Write("Enter key name: ");
            string symmetricKeyName = Console.ReadLine();
            Console.WriteLine($"Decrypted Text: { _facade.DecryptSymmetric(symmetricKeyName)}");
        }
        public void DecryptAsymmetric()
        {
            Console.WriteLine("Key name:");
            foreach (var key in _facade.GetAsymmetricKeys())
            {
                Console.WriteLine(key);
            }

            Console.Write("Enter key name: ");
            string asymmetricKeyName = Console.ReadLine();
            Console.WriteLine($"Decrypted Text:{_facade.DecryptAsymmetric(asymmetricKeyName)}");

        }
        public void Exit()
        {
            Environment.Exit(0);
        }

        public void Hash()
        {
            Console.Write("Enter text to hash: ");
            string hash = Console.ReadLine();
            Console.WriteLine($" Hash : {Convert.ToBase64String(_facade.Hash(hash))}");
        }
    }
}
