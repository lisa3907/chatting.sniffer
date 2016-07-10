using System;
using System.ServiceModel;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using OdinSoft.LIB.Configuration;

namespace Sniffer.Client.Main
{
    /*
    *	Program  Main()
    *
    *	The only special thing about Main
    *	is that it calls SingleInstance.Start() at the top,
    *	and SingleInstance.Stop() at the bottom.
    *
    */

    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (SingleInstance.Start() == false)
            {
                SingleInstance.ShowFirstInstance();
                return;
            }

            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += Application_ThreadException;

            // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            DevExpress.UserSkins.BonusSkins.Register();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (sniffer dockForm = new sniffer())
                {
                    Application.Run(dockForm);
                }
            }
            catch (EndpointNotFoundException ex)
            {
                string _message
                        = "네트워크 오류 또는 설정문제로 인해 서버를 찾을 수 없습니다." + Environment.NewLine
                        + "QMonitor가 자동 종료 됩니다. " + Environment.NewLine
                        + "시스템관리자에게 문의 하시기 바랍니다." + Environment.NewLine
                        + Environment.NewLine + ex.Message;
                MessageBox.Show(_message);
            }
            catch (Exception ex)
            {
                string _message
                        = "알 수 없는 오류로 인해 QMonitor가 자동 종료 됩니다. " + Environment.NewLine
                        + "시스템관리자에게 문의 하시기 바랍니다." + Environment.NewLine
                        + Environment.NewLine + ex.Message;
                MessageBox.Show(_message);
            }
            finally
            {
                SingleInstance.Stop();
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var _result = DialogResult.Abort;

            try
            {
                _result = MessageBox.Show(
                        String.Format("Whoops! Please contact the developers with the following thread exception information:\n\n{0}{1}", e.Exception.Message, e.Exception.StackTrace),
                        "Application Error",
                        MessageBoxButtons.AbortRetryIgnore,
                        MessageBoxIcon.Stop
                    );
            }
            finally
            {
                if (_result == DialogResult.Abort)
                {
                    SingleInstance.Stop();
                    Application.Exit();
                }
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception _ex = (Exception)e.ExceptionObject;

                MessageBox.Show(
                        String.Format("Whoops! Please contact the developers with the following unhandled exception information:\n\n{0}{1}", _ex.Message, _ex.StackTrace),
                        "Fatal Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop
                    );
            }
            finally
            {
                SingleInstance.Stop();
                Application.Exit();
            }
        }
    }
}