using System.ServiceProcess;

namespace TCC.PUC.SCA.Alert
{
    static class Program
    {
        static void Main()
        {
#if DEBUG
            Alert alert = new Alert();
            alert.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Alert()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
