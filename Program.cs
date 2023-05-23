using Lab_4.Interface;
namespace Lab_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Facade en = new Facade();
            IDataOutPut dt = new DataOutPut(en);
            ICommandInvoker cmd = new CommandInvoker(dt);
            IRunner runer = new Runner(cmd);
            runer.Run();
            
        }
    }
}
