﻿using System;
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
    //!! Warning !!
    //Binding setup currently doesn't allow the use of a Carat (^) due to filename restrictions.
    //Means that any Ctrl+X bind cant work. ;(
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
            //reset pbar
            pbar.Value = 0;

            //Instruct the recordmanager to begin recording at its specified quality.
            rm.StartRecording(lvSource);

            //Allow the user to submit after at least something has been recorded.
            btnSubmit.Enabled = true;

            //Cycle an anim to give a progress metric to the user.
            while (pbar.Value != pbar.Maximum)
            {
                pbar.Value++;
                Thread.Sleep(1);
            }

            //Feedback to let user know their recording has been saved.
            MessageBox.Show("Binding trigger saved. To re-record for this binding, just click record again.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send(v=vs.110).aspx");
        }

        private void progTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
