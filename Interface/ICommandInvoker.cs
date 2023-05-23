using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4.Interface
{
    interface ICommandInvoker
    {
        Dictionary<Command, Action> RunCommand();
    }
}
