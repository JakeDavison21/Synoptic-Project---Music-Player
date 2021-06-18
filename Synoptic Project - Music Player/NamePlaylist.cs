using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synoptic_Project___Music_Player
{
    public partial class NamePlaylist : Form
    {
        private string playListName { get; set; }


        public NamePlaylist()
        {
            InitializeComponent();
            //Set accept button to btnSave to return DialogResult.OK
            this.AcceptButton = btnSave;
        }

        /// <summary>
        /// Send playlist name to main form to create file 
        /// </summary>
        public void btnSave_Click(object sender, EventArgs e)
        {
            playListName = txtPlaylistName.Text;
            //Set playlist name from main form static method
            Form1.SetPlaylistName(playListName);
            //Set DialogResult.OK
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Enter key press on textbox
        /// Pass execution back to btnSave_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPlaylistName_KeyDown(object sender, KeyEventArgs e)
        {
            //On enter press, pass execution to btnSave_Click handler
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }
    }
}