using Lab_4.Interface;
using System;
namespace Lab_4
{
    class Runner:IRunner
    {
        private ICommandInvoker _commandInvoker;
        public Runner(ICommandInvoker commandInvoker)
        {
            _commandInvoker = commandInvoker;
        }
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. Encrypt Symmetric");
                Console.WriteLine("2. Encrypt Asymmetric");
                Console.WriteLine("3. Decrypt Symmetric");
                Console.WriteLine("4. Decrypt Asymmetric");
                Console.WriteLine("5. Hash");
                Console.WriteLine("0. Exit");
                if (Enum.TryParse(Console.ReadLine(), out Command command) && _commandInvoker.RunCommand().ContainsKey(command))
                {
                    _commandInvoker.RunCommand()[command]();
                }
                else
                {
                    Console.WriteLine("НЕ вірно ведене число , введіть число від 1-4");
                }
            }

        }
    }
}
