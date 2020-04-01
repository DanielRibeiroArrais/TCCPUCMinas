namespace TCC.PUC.SCA.Alert.WhatsApp
{
    static class Program
    {
        static void Main()
        {
#if DEBUG
            WhatsApp whatsApp = new WhatsApp();
            whatsApp.OnDebug();
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
