using System;
using System.ServiceProcess;

namespace Sniffer.Server
{
    static class Program
    {
    #if TRACE
        public static void Main()
        {
            Host _configHost = new Host();
            _configHost.Start();

            Console.WriteLine("hit any key to exit.....");
            Console.ReadLine();

            _configHost.Stop();
        }
#else
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun = new ServiceBase[] { new PmsService() };

            // 동일한 프로세스 내에서 사용자 서비스가 두 개 이상 실행될 수 있습니다.
            // 이 프로세스에 다른 서비스를 추가하려면 다음 줄을 변경하여 두 번째
            // 서비스 개체를 만듭니다. 예를 들면 다음과 같습니다.
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //

            ServiceBase.Run(ServicesToRun);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception _ex = (Exception)e.ExceptionObject;
                //OdinSoft.SVC.Proxy.IConfig.Interface _interface = new OdinSoft.SVC.Proxy.IConfig.Interface();
                //_interface.WriteLog(_ex.ToString());
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }
#endif
    }
}