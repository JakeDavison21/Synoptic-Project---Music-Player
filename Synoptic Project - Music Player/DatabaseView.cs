using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace Synoptic_Project___Music_Player
{
    public partial class DatabaseView : Form
    {
        //Reference to main form
        private Form1 frm;

        /// <summary>
        /// Constructor method sets reference to main
        /// page for passing data back to main control
        /// </summary>
        /// <param name="frmMain"></param>
        public DatabaseView(Form frmMain)
        {
            InitializeComponent();
            frm = frmMain as Form1;
        }

        /// <summary>
        /// View by album in list view
        /// populate view with selectioh from combobox
        /// </summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lear all items from list view
            lvViewTracks.Items.Clear();
            //Get database path from app.config
            string databasePath = ConfigurationManager.AppSettings.Get("databasePath");

            //If view all not selected
            if (comboBox1.Text != "Show All")
            {
                string album = Path.Combine(databasePath, comboBox1.Text);

                if (Directory.Exists(album))
                {
                    AddTrackListItem(new string[] { album });
                }
            }
            else
            {
                //If database directory is found, add all tracks from all albums found
                if (Directory.Exists(databasePath))
                {
                    //Add string array to list
                    AddTrackListItem(Directory.GetDirectories(databasePath));
                }
            }
        }

        /// <summary>
        /// Form load logic
        /// Gets database directory from app.config and 
        /// loads all albums found to list view
        /// </summary>
        private void DatabaseView_Load(object sender, EventArgs e)
        {
            //Get database path from app.config and check existence of directory
            string databasePath = ConfigurationManager.AppSettings.Get("databasePath");

            if (Directory.Exists(databasePath))
            {
                foreach (string album in Directory.GetDirectories(databasePath))
                {
                    //Add items to list view 
                    comboBox1.Items.Add(album.Split('\\')[album.Split('\\').Length - 1]);
                }
            }
            comboBox1.Text = "Show All";
            //Trigger event to load all items to list view
            comboBox1_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// Search through items in list view
        /// Can search either by file name or album name
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Check for entry in text box
            if (txtSearchText.Text != "")
            {
                //De-select all items in list view
                foreach (ListViewItem lvi in lvViewTracks.Items)
                    lvi.Selected = false;

                //Highlight all where text matches inside track or album name
                foreach (ListViewItem row in lvViewTracks.Items)
                {
                    if (row.SubItems[1].Text.ToLower().Contains(txtSearchText.Text.ToLower()) ||
                        row.SubItems[2].Text.ToLower().Contains(txtSearchText.Text.ToLower()))
                    {
                        //Highlight search results
                        row.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// Enter pressed on search text box
        /// </summary>
        /// <param name="e"></param>
        private void txtSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            //Send execution to btnSearch_Click event
            if (e.KeyCode == Keys.Enter)
                btnSearch.PerformClick();
        }

        /// <summary>
        /// Add item array to list view
        /// </summary>
        /// <param name="albums"></param>
        private void AddTrackListItem(string[] albums)
        {
            string albumName;
            string trackName;
            string filePath;
            int currentCount;

            foreach (string album in albums)
            {
                albumName = album.Split('\\')[album.Split('\\').Length - 1];

                foreach (string track in Directory.GetFiles(album))
                {
                    filePath = track;
                    trackName = track.Split('\\')[track.Split('\\').Length - 1];
                    currentCount = lvViewTracks.Items.Count + 1;

                    ListViewItem lvi = new ListViewItem(currentCount.ToString());
                    lvi.SubItems.Add(trackName);
                    lvi.SubItems.Add(albumName);
                    lvi.SubItems.Add(filePath);
                    lvViewTracks.Items.Add(lvi);
                }
            }
        }

        /// <summary>
        /// Get selected item
        /// Send selection back to main form for playback
        /// </summary>
        private void lvViewTracks_DoubleClick(object sender, EventArgs e)
        {
            //Get file path to selected item
            string filePath = lvViewTracks.SelectedItems[0].SubItems[3].Text;
            //Trigger pass data method on main form
            frm.GetTrackFromDBForm(filePath);
        }
    }
}
