using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolvoCanLogger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += OnThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            Application.Run(new LoggerWindow());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private static void SaveExceptionToFile(Exception ex)
        {
            string errorMsg = $"\n{DateTime.Now} Exception: {ex.Message}\nStack Trace:\n {ex.StackTrace}";
            System.IO.File.AppendAllText("error.log", errorMsg);
        }

        private static void OnThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

            try
            {
                Exception ex = (Exception)e.Exception;
                SaveExceptionToFile(ex);
                ShowThreadExceptionDialog("Unexpected Error", e.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Error",
                        "Fatal Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            Application.Exit();
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                SaveExceptionToFile(ex);
                ShowThreadExceptionDialog("Unexpected Error", ex);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error",
                        "Fatal Non-UI Error. Could not write the error to the file log. Reason: "
                        + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = $"An application error occurred!\nInformation:\n\nException: {e.Message}\nStack Trace:\n{e.StackTrace}\n\nInformation saved to 'error.log'";
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.OK,
                MessageBoxIcon.Stop);
        }
    }
}
