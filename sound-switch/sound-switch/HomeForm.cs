﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sound_switch
{
    public partial class HomeForm : Form
    {
        //Flag for changing contents on the form.
        bool enabledFlag;

        //Instance of the binding manager
        BindingManager bm = new BindingManager();

        public HomeForm()
        {
            InitializeComponent();
            enabledFlag = false;
        }

        private void btnBackBind_Click(object sender, EventArgs e)
        {
            panelBindings.Hide();
            panelMain.Show();
        }

        private void btnBindings_Click(object sender, EventArgs e)
        {
            panelBindings.Show();
            panelMain.Hide();
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
            Executor ex = new Executor();
            ex.runPollingScript();

            //Change button text depending on activation.
            if (enabledFlag)
            {
                btnToggleListen.Text = "Start Listening";
                enabledFlag = false;
            }
            else
            {
                btnToggleListen.Text = "Stop Listening";
                enabledFlag = true;
            }
        }

        private void btnNewBind_Click(object sender, EventArgs e)
        {
            //Intermediary vals for creation of a new bind
            string bNameTemp = "";
            string bBindTemp = "";

            //Open dialog prompts for the new binding
            BindDialog dialog = new BindDialog();

            //Open the dialogue and wait a resolution flag
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                //Get value out of description box from the dialog.
                bNameTemp = dialog.txtDescription.Text;
                bBindTemp = dialog.txtBindCode.Text;

                //Build the binding instance and add it to the binding list in the manager.
                Binding newBinding = new Binding(bNameTemp, bBindTemp);
                bm.addBinding(newBinding);

                //Update the binding display
                bm.update(dgvBind);
            }
            else
            {
                MessageBox.Show("Binding not created, dialog was exited prematurely.");
            }
        }
    }
}