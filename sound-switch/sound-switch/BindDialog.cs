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
        public BindDialog()
        {
            InitializeComponent();

            btnSubmit.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creator an executor instance so we can run the polling script
            Executor ex = new Executor();

            //Run the polling script once
            ex.runPollingScript();

            //TODO: Seperate python script to record as soon as the button is hit rather than when sound is heard.
            //Just modify what we already have and make it a seperate script @leonardsim

            //Wait 2s before enabling submit button.
            Thread.Sleep(2000);

            btnSubmit.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send(v=vs.110).aspx");
        }
    }
}
