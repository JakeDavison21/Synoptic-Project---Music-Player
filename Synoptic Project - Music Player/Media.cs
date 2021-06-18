using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Synoptic_Project___Music_Player
{
    class Media
    {
        //Notify flag from Windows notification to get playack end
        public const int MM_MCINOTIFY = 0x3B9;

#region private members
        private string fileName;
        private bool isOpen = false;
        private Form notifyForm;
        private string mediaName = "Media";
#endregion

        //Import winmm.dll for multimedia playback control
        [DllImport("winmm.dll")]
        //Reference external method from winmm library to play media file (mciSendString)
        private static extern long mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr winHandle);

        /// <summary>
        /// Stops media if a file is in playing state
        /// </summary>
        private void StopMedia()
        {
            if (isOpen)
            {
                string playCommand = "Close " + mediaName;
                mciSendString(playCommand, null, 0, IntPtr.Zero);
                isOpen = false;
            }
        }

        /// <summary>
        /// Stops any currently playing media and 
        /// opens media file with mciSendString method
        /// </summary>
        private void OpenMedia()
        {
            StopMedia();
            string playCommand = "Open \"" + fileName + "\" type mpegvideo alias " + mediaName;
            mciSendString(playCommand, null, 0, IntPtr.Zero);
            isOpen = true;
        }

        /// <summary>
        /// Plays media with mciSendString method
        /// </summary>
        private void PlayMedia()
        {
            if (isOpen)
            {
                string playCommand = "Play " + mediaName + " notify";
                mciSendString(playCommand, null, 0, notifyForm.Handle);
            }
        }

        /// <summary>
        /// Publicly exposed method to play media file 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="notifyForm"></param>
        public void Play(string fileName, Form notifyForm)
        {
            //Set local variables of instance
            this.fileName = fileName;
            this.notifyForm = notifyForm;
            //Open and play media file
            OpenMedia();
            PlayMedia();
        }

        /// <summary>
        /// Publicly exposed method to stop media playback
        /// </summary>
        public void Stop()
        {
            StopMedia();
        }
    }
}
