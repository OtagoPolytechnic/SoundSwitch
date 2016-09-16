﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sound_switch
{
    class BindingManager
    {
        //Binding manager holds a list of bindings which are created by the user at runtime.
        List<Binding> bindings = new List<Binding>();

        public BindingManager()
        {
            //Empty so far
        }

        //Load existing binds NYI
        public void loadExistingBinds()
        {

        }

        //Adds a newly generated bind to the list of current bindings.
        public void addBinding(Binding newBind)
        {
            bindings.Add(newBind);
        }

        //Updates the datagridview witha  list of current bindings
        public void update(DataGridView dgv)
        {
            //Clear current dgv content
            dgv.Rows.Clear();

            //Repopulate
            for (int i = 0; i < bindings.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dgv.Rows[i].Clone();
                row.Cells[0].Value = bindings[i].bindTarget;
                row.Cells[1].Value = bindings[i].bindCode;
                row.Cells[2].Value = bindings[i].pathToWav;
                dgv.Rows.Add(row);
            }
        }

        //Method to compare the unprocessed.wav file against the current set of stored bindings
        public Binding compareUnprocessed()
        {
            //The resultant best-matching binding we find for the unprocessed file.
            Binding bestMatch;

            //Path to the unprocessed wav file
            string pathToUnprocessed = "unprocessed.wav";

            //Name of the xcorr library script we want to execute
            string pathToScript = "NYI.exe";

            //Create an executor instance to pass commands to the cmd prompt
            Executor executor = new Executor();

            //String array that holds the script run results
            string[] compareResults = new string[bindings.Count];

            //Loop over each stored binding and execute the compare script on each of them.
            for (int i = 0; i < bindings.Count; i ++)
            {
                compareResults[i] = executor.ExecuteCommand(pathToScript + " " + pathToUnprocessed + " " + bindings[i].pathToWav);
            }

            return bestMatch;
        }
    }
}
