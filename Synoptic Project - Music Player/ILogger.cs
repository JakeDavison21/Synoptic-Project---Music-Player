using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synoptic_Project___Music_Player
{
    /// <summary>
    /// Interface for logging information through various channelsImplementation-dependant 
    /// Can be used in future development to log data to other logging mechanisms (e.g. email team lead)
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Used specifically for logging error messages
        /// </summary>
        /// <param name="message"></param>
        void LogError(string message);

        /// <summary>
        /// For logging debug information 
        /// </summary>
        /// <param name="message"></param>
        void LogInfo(string message);
    }
}
