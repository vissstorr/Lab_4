using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4.Interface
{
    interface IDataOutPut
    {
        void Exit();
        void EncryptSymmetric();
        void EncryptAsymmetric();
        void DecryptAsymmetric();
        void DecryptSymmetric();
        void Hash();
    }
}
