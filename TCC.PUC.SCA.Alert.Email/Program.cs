using System.ServiceProcess;

namespace TCC.PUC.SCA.Alert.Email
{
    static class Program
    {
        static void Main()
        {
#if DEBUG
            Email email = new Email();
            email.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Email()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
