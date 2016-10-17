using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace sound_switch
{
    public partial class BindDialog : Form
    {
        private RecorderManager rm;
        private ListView lvSource;

        public BindDialog(object lv)
        {
            InitializeComponent();

            //Init a recordermanager instance and fetch the device source list.
            rm = new RecorderManager();
            lvSource = (ListView)lv;

            //Set the submit button to return control to the previous form when we've made a binding.
            btnSubmit.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Instruct the recordmanager to begin recording at its specified quality.
            rm.StartRecording(lvSource);

            //Allow the user to submit after at least something has been recorded.
            btnSubmit.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send(v=vs.110).aspx");
        }
    }
}
