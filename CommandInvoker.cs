using Lab_4.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4
{
    class CommandInvoker:ICommandInvoker
    {
        private IDataOutPut _dataOutput;
        public CommandInvoker(IDataOutPut dataOutPut)
        {
            _dataOutput = dataOutPut;

        }
        public Dictionary<Command, Action> RunCommand()
        {
            var dictionarycommand = new Dictionary<Command, Action>()
            {
                {Command.DecryptAsymmetric, _dataOutput.DecryptAsymmetric },
                {Command.Exit, _dataOutput.Exit },
                {Command.DecryptSymmetric, _dataOutput.DecryptSymmetric },
                {Command.EncryptSymmetric, _dataOutput.EncryptSymmetric },
                {Command.EncryptAsymmetric, _dataOutput.EncryptAsymmetric },
                {Command.Hash,_dataOutput.Hash }
            };
            return dictionarycommand;
        }
    }
}
