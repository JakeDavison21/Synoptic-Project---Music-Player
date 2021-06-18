using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Synoptic_Project___Music_Player
{
    /// <summary>
    /// Implementation of ILogger interfce
    /// Text logger for logging errors or debug info to 
    /// a log file
    /// Path to log file configured in app.config
    /// </summary>
    class TextLogger : ILogger
    {
        static NameValueCollection appSettings;
        static string logPath;
        static string today;
        static string logFileName;
        static string pathToLogFile;

        public TextLogger()
        {
            //Get and format path to log file from app.config
            appSettings = ConfigurationManager.AppSettings;
            logPath = appSettings.Get("logPath");
            today = DateTime.Now.ToShortDateString().Replace('/', '-');
            logFileName = today + "_Log.txt";
            pathToLogFile = Path.Combine(logPath, logFileName);

            //Check if file exists. If not, create it
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
        }

        /// <summary>
        /// Logs error message passed in by calling code
        /// Formats message body with date/time stamps
        /// Appends formatted message to log file
        /// </summary>
        /// <param name="messageBody"></param>
        public void LogError(string messageBody)
        {
            try
            {
                if (messageBody.Length > 0)
                {
                    //Using streamwriter, write formatted message to log file
                    using (StreamWriter sw = File.AppendText(pathToLogFile))
                    {
                        sw.WriteLine("[" + DateTime.Now + "] " + "[Error] " + messageBody);
                    }
                }
                else
                    //If message length is 0, throw detailed exception
                    throw new ArgumentNullException("messageBody", "message length was 0, cannot write to log file");
            }
            catch (IOException)//Catch possible filesystem errors 
            {
                MessageBox.Show("Offline error logging failed \r\n please check file paths and restart application");
            }
        }

        /// <summary>
        /// LogInfo method for writing debug information to the log file
        /// Formats message with date/time stamps and [Debug] flag in log
        /// </summary>
        /// <param name="message"></param>
        public void LogInfo(string messageBody)
        {
            try
            {
                if (messageBody.Length > 0)
                {
                    //Using streamwriter, write formatted message to log file
                    using (StreamWriter sw = File.AppendText(pathToLogFile))
                    {
                        sw.WriteLine("[" + DateTime.Now + "] " + "[Debug] " + messageBody);
                    }
                }
                else
                    //If message length is 0, throw detailed exception
                    throw new ArgumentNullException("messageBody", "message length was 0, cannot write to log file");
            }
            catch (IOException)//Catch possible filesystem errors 
            {
                MessageBox.Show("Offline error logging failed \r\n please check file paths and restart application");
            }
        }
    }
}
