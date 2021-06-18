using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.WindowsAPICodePack.Shell;
using System.Configuration;
using System.Linq;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace Synoptic_Project___Music_Player
{
    public partial class Form1 : Form
    {
#region private members
        private Media media;
        private ILogger logger;
        private int currentIndex;

        private static string playlistName;
#endregion

        /// <summary>
        /// Setter method for private field playlistName
        /// </summary>
        /// <param name="value"></param>
        public static void SetPlaylistName(string value)
        {
            playlistName = value;
        }

        /// <summary>
        /// Constructor for class -
        /// Instantiates instances of Media and ILogger implementation
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            media = new Media();

            logger = new TextLogger();
        }

        /// <summary>
        /// Stops currently playing media and closes application
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Stop media
            media.Stop();
            //Close application
            Application.Exit();
        }

        /// <summary>
        /// Browse local machine function
        /// Opens file dialog with filtered search results for audio files
        /// If valid file selected, write path to file to text box
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Set filter on open file dialog to show only sound file types
            ofdBrowse.Filter = "Media File(*.mpg,*.avi,*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.mpg;*.avi;*.wmv";
            ofdBrowse.ShowDialog();

            //Check if file selected
            if (ofdBrowse.FileName == "")
                //Prompt user error
                MessageBox.Show("No file selected,\r\n please select a file for playback", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                txtMediaFile.Text = ofdBrowse.FileName;
        }

        /// <summary>
        /// Play selected media function
        /// Checks for item in text box - if nothing found checks for selected items in list view
        /// If file exists, begin media playback and set album art thumbnail
        /// </summary>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            string currentFile = "";
            //Check for media file in text box
            if (txtMediaFile.Text != "")
            {
                //Check if item exists
                if (File.Exists(txtMediaFile.Text))
                {
                    //Set current file from text box
                    currentFile = txtMediaFile.Text;
                }
                else
                {
                    //Prompt user error
                    MessageBox.Show("The media file does not exist.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Log error to log file
                    logger.LogError("The media file: " + txtMediaFile.Text + " does not exist.");
                }
            }
            //Check for selected items in list
            else if (listView1.SelectedItems.Count > 0)
            {
                //Check if file exists
                if (File.Exists(listView1.SelectedItems[0].SubItems[1].Text))
                {
                    //Set current media from list (1st selection)
                    currentFile = listView1.SelectedItems[0].SubItems[1].Text;

                    //Set current index in list
                    currentIndex = listView1.SelectedItems[0].Index;
                }
                else
                    //Prompt user error
                    MessageBox.Show("File does not exist", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                //Prompt user error
                MessageBox.Show("No media file selected, please select a file for playback", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //If valid file selected, call Play function and set thumbnail image
            if (currentFile != "")
            {
                if (IsValidAudioFile(currentFile))
                {
                    media.Play(currentFile, this);
                    btnStop.Enabled = true;
                    SetAlbumArt(currentFile);
                }
                else
                    MessageBox.Show("Invalid file selection\r\nFile is not a valid audio format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Stops currently playing media and clears thumbnail
        /// Disables Stop button
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            //Stop media
            media.Stop();
            //Clear thumbnail and disable stop button
            pbCoverArt.Image = null;
            btnStop.Enabled = false;
        }

        /// <summary>
        /// Adds file in text box to list if file exists
        /// Checks for existence in list already - prompt user to index if found
        /// </summary>
        private void btnAddToPlaylist_Click(object sender, EventArgs e)
        {
            bool existsInList = false;
            int mediaIndex = 0;
            int itemCount;
            if (IsValidAudioFile(txtMediaFile.Text))
            {
                //Before add to list, check if it has already been added
                foreach (ListViewItem lvi in listView1.Items)
                {
                    if (lvi.SubItems[1].Text == txtMediaFile.Text)
                    {
                        existsInList = true;
                        mediaIndex = lvi.Index + 1;
                        break;
                    }
                }
                //If file hsa not already been added, add to the list
                if (!existsInList)
                {
                    if (txtMediaFile.Text != "" && File.Exists(txtMediaFile.Text))
                    {
                        itemCount = listView1.Items.Count + 1;
                        ListViewItem lvi = new ListViewItem(itemCount.ToString());
                        lvi.SubItems.Add(txtMediaFile.Text);
                        listView1.Items.Add(lvi);
                        txtMediaFile.Text = "";
                    }
                    else
                        //Prompt user invalid selection
                        MessageBox.Show("Invalid selection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    //Prompt user of file already in list, give user index of file in list
                    MessageBox.Show("Item already exists in playlist\r\nIndex: " + mediaIndex.ToString());
            }
            else
                //Prompt user file is not valid audio file
                MessageBox.Show("Invalid file selection\r\nFile is not a valid audio format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Removes highlighted items from list view
        /// Refreshes indexing as item count will change
        /// </summary>
        private void btnRemoveFromPlaylist_Click(object sender, EventArgs e)
        {
            //Remove all highlighted items from list and refresh indexing
            foreach(ListViewItem lvi in listView1.SelectedItems)
            {
                listView1.Items.Remove(lvi);
            }
            //Refresh list indexing
            RefreshListIndex();
        }

        /// <summary>
        /// Clears all items from list view and text box
        /// </summary>
        private void btnClearPlaylist_Click(object sender, EventArgs e)
        {
            //Clear list view and text entry field
            listView1.Items.Clear();
            txtMediaFile.Text = "";
        }

        /// <summary>
        /// Skips to previous track in list view
        /// </summary>
        private void btnSkipBack_Click(object sender, EventArgs e)
        {
            string currentMedia = "";
            //Stop currently playing media
            media.Stop();

            if (currentIndex > 0)
            {
                currentIndex--;
                currentMedia = listView1.Items[currentIndex].SubItems[1].Text;
                //Play media
                media.Play(currentMedia, this);
                btnStop.Enabled = true;

                //Clear selected items from list view
                foreach (ListViewItem lvi in listView1.SelectedItems)
                    lvi.Selected = false;
                //Highlight newly selected item
                listView1.Items[currentIndex].Selected = true;
                SetAlbumArt(currentMedia);
            }
            else
                MessageBox.Show("No previous file in list\r\nAlready at start of list", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Refreshes index values for items in list view based on item count
        /// </summary>
        private void RefreshListIndex()
        {
            foreach(ListViewItem lvi in listView1.Items)
            {
                int ind = lvi.Index + 1;
                lvi.SubItems[0].Text = ind.ToString();
            }
        }

        /// <summary>
        /// Sets current index to selected item in list view
        /// </summary>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cast sender object to listview object to access attributes
            ListView lv = sender as ListView;

            if (lv.SelectedItems.Count > 0)
            {
                //Set current index if passed check
                currentIndex = lv.Items.IndexOf(lv.SelectedItems[0]);
            }
        }

        /// <summary>
        /// Skips forward track if there is a next file in the list view 
        /// Prompts user if no next item in view
        /// </summary>
        private void btnSkipForward_Click(object sender, EventArgs e)
        {
            string currentMedia = "";
            //Stop currently playing media
            media.Stop();

            try
            {
                currentIndex++;
                currentMedia = listView1.Items[currentIndex].SubItems[1].Text;
                //Play media
                media.Play(currentMedia, this);
                btnStop.Enabled = true;

                //Clear selected items from list view
                foreach (ListViewItem lvi in listView1.SelectedItems)
                    lvi.Selected = false;
                //Highlight newly selected item
                listView1.Items[currentIndex].Selected = true;
                SetAlbumArt(currentMedia);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("No next file in selection,\r\nplease select a file for playback", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Shuffle to random track function
        /// Shuffles through items in list view 
        /// Does not allow same value twice (repeated sogn)
        /// </summary>
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                int indexBeforeSuffle = 0;

                //Check for items in list view
                if (listView1.SelectedItems.Count > 0)
                    indexBeforeSuffle = listView1.SelectedItems[0].Index;

                //Get index to shuffle to
                int shuffleTo = ShuffleTrack(indexBeforeSuffle);

                string currentMedia = listView1.Items[shuffleTo].SubItems[1].Text;

                //If file exists, play media and un-select all from list view
                if (File.Exists(currentMedia))
                {
                    media.Play(currentMedia, this);
                    btnStop.Enabled = true;

                    foreach (ListViewItem lvi in listView1.SelectedItems)
                        lvi.Selected = false;

                    listView1.Items[shuffleTo].Selected = true;

                    SetAlbumArt(currentMedia);
                }
            }
        }

        /// <summary>
        /// Get random index for shiffle function
        /// Does not allow same index to be repeated more than once cocurrently
        /// </summary>
        /// <param name="indexBeforeShuffle"></param>
        /// <returns></returns>
        private int ShuffleTrack(int indexBeforeShuffle)
        {
            Random rnd = new Random();
            int newRandom = rnd.Next(0, listView1.Items.Count);

            if (newRandom != indexBeforeShuffle)
                return newRandom;
            else
                ShuffleTrack(indexBeforeShuffle);
            return 0;
        }

        /// <summary>
        /// Set picturebox to dislpay file thumbnail / album art
        /// Uses Microsoft.WindowsAPICodePack.Shell to inherit shell controls
        /// </summary>
        /// <param name="pathToFile"></param>
        private void SetAlbumArt(string pathToFile)
        {
            try
            {
                ShellFile file = ShellFile.FromFilePath(pathToFile);
                Bitmap thumbnail = file.Thumbnail.LargeBitmap;
                pbCoverArt.Image = thumbnail;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get thmbnail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                logger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// Clear text box
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            txtMediaFile.Text = "";
        }

        /// <summary>
        /// Creates text file containing paths to selected files
        /// Saves file to path configured in app/config
        /// </summary>
        private void btnCreatePlaylist_Click(object sender, EventArgs e)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string playlistFolder = appSettings.Get("playlistPath");

            using (NamePlaylist nameForm = new NamePlaylist())
            {
                if (nameForm.ShowDialog() == DialogResult.OK)
                {
                    //Close playlist naming form on DialogResult.OK
                    nameForm.Close();

                    List<string> fileList = new List<string>();
                    foreach (ListViewItem lvi in listView1.Items)
                        fileList.Add(lvi.SubItems[1].Text);

                    string playlistPath = Path.Combine(playlistFolder, "Playlist_" + playlistName + ".txt");

                    //Create/append to playlist text file
                    File.AppendAllLines(playlistPath, fileList);

#region FutureImplementation
                    //============================================================================================

                    //Future implementation: write file attributes to deliniate between standard text file 
                    //and file created by this application - only allow playlist files to be loaded

                    //var file = ShellFile.FromFilePath(playlistPath);
                    //file.Properties.System.ContentType.Value = new string[] { "playlist" };

                    //ShellPropertyWriter propertyWriter = file.Properties.GetPropertyWriter();
                    //propertyWriter.WriteProperty(SystemProperties.System.ContentType, "playlist");
                    //propertyWriter.Close();

                    //============================================================================================
#endregion
                }
            }
        }

        /// <summary>
        /// Loads previously made playlist from file browser
        /// </summary>
        private void btnLoadPlaylist_Click(object sender, EventArgs e)
        {
            ofdBrowsePlaylists.Filter = "Text|*.txt";
            ofdBrowsePlaylists.ShowDialog();

            //Check if file selected
            if (ofdBrowsePlaylists.FileName == "")
                //Prompt user error
                MessageBox.Show("No file selected,\r\n please select a valid playlist file", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (! ofdBrowsePlaylists.FileName.Split('\\')[ofdBrowsePlaylists.FileName.Split('\\').Length-1].Contains("Playlist_"))
            {
                MessageBox.Show("The file you have selected is not a valid playlist file.\r\nPlease select a playlist file to load", "Invalid file selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string currentLine;
                int itemCount;
                ListViewItem lvi;

                listView1.Items.Clear();

                //Open and read from file - add items to list view
                using (StreamReader sr = File.OpenText(ofdBrowsePlaylists.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        currentLine = sr.ReadLine();
                        if (currentLine != "" && File.Exists(currentLine))
                        {
                            itemCount = listView1.Items.Count+1;
                            lvi = new ListViewItem(itemCount.ToString());
                            lvi.SubItems.Add(currentLine);
                            listView1.Items.Add(lvi);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Opens database view form if none are active
        /// Passes reference to main form for passing data back for playback
        /// </summary>
        private void btnDbSearch_Click(object sender, EventArgs e)
        {
            //Check count of active database view forms
            if (Application.OpenForms.OfType<DatabaseView>().Count<DatabaseView>() == 0)
            {
                //Show database view form - pass reference to main form 
                DatabaseView dbv = new DatabaseView(this);
                dbv.Show();
            }
        }

        /// <summary>
        /// Gets file path to selected file from database view form
        /// Plays media if file is valid
        /// Sets thumbnail art
        /// </summary>
        /// <param name="filePath"></param>
        public void GetTrackFromDBForm(string filePath)
        {
            if (File.Exists(filePath))
            {
                this.Focus();
                media.Play(filePath, this);
                btnStop.Enabled = true;
                SetAlbumArt(filePath);
            }
        }

        /// <summary>
        /// Checks file extension for audio file types
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <returns>
        /// boolean result - whether file is audio file or not
        /// </returns>
        private bool IsValidAudioFile(string pathToFile)
        {
            //Get file name and extensions 
            string fileName = pathToFile.Split('\\')[pathToFile.Split('\\').Length - 1];
            string fileExtension = fileName.Split('.')[fileName.Split('.').Length - 1];

            if (fileExtension != "mpg" && fileExtension != "avi" && fileExtension != "wmv" 
                && fileExtension != "wav" && fileExtension != "mp3")
            {
                return false;
            }
            else
                return true;
        }
    }
}
