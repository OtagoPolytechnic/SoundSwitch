using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecorderTest
{
    public partial class Form1 : Form
    {
        // Attributes
        private Manager manager;

        public Form1()
        {
            InitializeComponent();

            // Insantiate the manager
            manager = new Manager();
        }

        // Displays any available wave in devices to the List View
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            manager.SetSourceListView(lvSource);
        }

        // Kills all recording process
        private void btnStop_Click(object sender, EventArgs e)
        {
            manager.Stop();
            MessageBox.Show("Recording stopped");
        }

        // Same as btnStop_Click except this closes the app
        private void btnExit_Click(object sender, EventArgs e)
        {
            manager.Stop();
            this.Close();
        }

        // Starts recording
        private void btnRecord_Click(object sender, EventArgs e)
        {
            manager.StartRecording(lvSource, rbSoundLevel);
        }
        
        // Causes rich text box to scroll to the bottom when new data is written
        private void rbSoundLevel_TextChanged(object sender, EventArgs e)
        {
            manager.DisplayLatestRMS(rbSoundLevel);
        }
    }
}
