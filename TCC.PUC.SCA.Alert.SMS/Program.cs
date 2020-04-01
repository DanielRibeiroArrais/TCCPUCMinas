namespace TCC.PUC.SCA.Alert.SMS
{
    static class Program
    {
        static void Main()
        {
#if DEBUG
            SMS sms = new SMS();
            sms.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SMS()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
