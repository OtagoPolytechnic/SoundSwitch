﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace sound_switch
{
    public partial class HomeForm : Form
    {
        //Instance of the binding manager
        BindingManager bm = new BindingManager();
        RecorderManager rm = new RecorderManager();

        public HomeForm()
        {
            InitializeComponent();

            notifyIcon.Icon = new Icon("TrayIcon.ico");
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.Visible = false;

            //Load an initial device list into the settings page.
            rm.SetSourceListView(lvSource);
        }

        private void btnBackBind_Click(object sender, EventArgs e)
        {
            panelBindings.Hide();
            panelMain.Show();
        }

        private void btnBindings_Click(object sender, EventArgs e)
        {
            if (rm.CheckIfSourceSelected(lvSource))
            {
                panelBindings.Show();
                panelMain.Hide();

                //Update the display on the datagridview that holds the binding information.
                bm.update(dgvBind);
            }
            else
            {
                MessageBox.Show("Please ensure your microphone is properly setup before creating or altering bindings.");
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            panelSettings.Show();
            panelMain.Hide();
        }

        private void btnBackSet_Click(object sender, EventArgs e)
        {
            panelSettings.Hide();
            panelMain.Show();
        }

        private void btnToggleListen_Click(object sender, EventArgs e)
        {
            //Ensure we have at least 1 binding and a valid mic input before we enable listening.
            if (bm.bindings.Count != 0 && rm.CheckIfSourceSelected(lvSource))
            {
                rm.StartListening(lvSource, rtbSoundLevel);
                timer1.Enabled = true;

                //Turn start off, turn stop on.
                btnToggleListen.Enabled = false;
                btnStop.Enabled = true;

                //Disable settings and bindings while listening is active.
                btnBindings.Enabled = false;
                btnSettings.Enabled = false;
            }
            else
            {
                MessageBox.Show("Before starting SoundSwitch, you require a properly configured microphone and at least one binding active.");
            }
        }

        private void btnNewBind_Click(object sender, EventArgs e)
        {
            //Intermediary vals for creation of a new bind
            string bNameTemp = "";
            string bBindTemp = "";

            //Open dialog prompts for the new binding
            BindDialog dialog = new BindDialog(lvSource);

            //Open the dialogue and wait a resolution flag
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                //Get value out of description box from the dialog.
                bNameTemp = dialog.txtDescription.Text;
                bBindTemp = dialog.txtBindCode.Text;

                //Build the binding instance and add it to the binding list in the manager.
                Binding newBinding = new Binding(bNameTemp, bBindTemp, false);

                //Make sure the binding we just created didn't get flagged as incomplete, etc.
                if (!newBinding.invalidBinding)
                {
                    bm.addBinding(newBinding);
                }
                
                //Update the binding display
                bm.update(dgvBind);
            }
            else
            {
                //Reaching here flushes the half-finished binding.
            }
        }

        private void btnRemoveBind_Click(object sender, EventArgs e)
        {
            int rowToDelete = dgvBind.CurrentCell.RowIndex;

            bm.removeBindingAtIndex(rowToDelete);

            bm.update(dgvBind);
        }

        private void btnGit_Click(object sender, EventArgs e)
        {
            //Open new tab to our git page.
            Process.Start("https://github.com/OtagoPolytechnic/SoundSwitch");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //Fetch device list
            rm.SetSourceListView(lvSource);

            //Clear currently selected device
            tbDeviceName.Text = "";
        }

        private void btnSetValues_Click(object sender, EventArgs e)
        {
            rm.SetValues(tbThreshold);
        }

        private void lvSource_ItemActivate(object sender, EventArgs e)
        {
            tbDeviceName.Text = rm.DisplaySelectedDeviceName(lvSource);
            rm.SetValues(tbThreshold);
        }

        private void tbThreshold_Leave(object sender, EventArgs e)
        {
            rm.ThresFlag = rm.CheckRegex(tbThreshold);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            rm.Stop();

            // Disable timer
            timer1.Enabled = false;

            //Disable self, enable start button.
            btnToggleListen.Enabled = true;
            btnStop.Enabled = false;

            //Enable settings and bindings since listening is stopped.
            btnBindings.Enabled = true;
            btnSettings.Enabled = true;
        }

        private void rtbSoundLevel_TextChanged(object sender, EventArgs e)
        {
            rtbSoundLevel.SelectionStart = rtbSoundLevel.Text.Length;
            rtbSoundLevel.ScrollToCaret();
        }

        //This timer runs inline with the 'start listening' button.
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Every timer tick, we check if our recorder manager needs us to process & send a binding.
            if (rm.readyForProcessing)
            {
                //Set the processor back to false.
                rm.readyForProcessing = false;

                //Find our best-match binding.
                Binding toExecute = bm.compareUnprocessed();

                if (toExecute != null)
                {
                    //Send the retrieved bindings code to the currently focused form.
                    SendKeys.Send(toExecute.bindCode);
                }
                else
                {
                    //no readings were of acceptable quality to be executed.
                }
            }
        }

        //Event handler attached to the form that will send application to tray when minimised.
        private void HomeForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                this.Hide();
                notifyIcon.ShowBalloonTip(1000, "Sound Switch", "Now running in background. Double-click here to reopen.", ToolTipIcon.Info);
            }
        }

        private void notifyIcon2_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void HomeForm_Activated(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void lvSource_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
