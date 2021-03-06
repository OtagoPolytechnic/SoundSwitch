﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sound_switch
{
    public class BindingManager
    {
        //Binding manager holds a list of bindings which are created by the user at runtime.
        public List<Binding> bindings = new List<Binding>();

        public BindingManager()
        {
            //When bindmanager is instantiated, trawl the specified dir for existing binds.
            loadExistingBinds();
        }

        //Load existing binds NYI
        public void loadExistingBinds()
        {
            //Get this solutions debug directory dynamically.
            string debugPath = System.AppDomain.CurrentDomain.BaseDirectory;

            //Create an array of paths holding all wav files in /debug
            string[] dirs = System.IO.Directory.GetFiles(debugPath, "*.wav");

            for (int i = 0; i < dirs.Length; i++)
            {
                //Get relevant path splits at certain characters
                int posSlash = dirs[i].LastIndexOf("\\") + 1;
                int posUnderscore = dirs[i].LastIndexOf("_");
                int posLastPeriod = dirs[i].LastIndexOf(".") - 1;

                //Create intermediaries that store the substrings of the split path.
                string newBindName = dirs[i].Substring(posSlash, posUnderscore - posSlash);

                //Filter out the unprocessed file from the newbind list.
                if (newBindName != "unprocessed")
                {
                    string newBindAction = dirs[i].Substring(posUnderscore + 1, posLastPeriod - posUnderscore);

                    //Create a new binding from these intermediaries.
                    bindings.Add(new Binding(newBindName, newBindAction, true));
                }
            }
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
        //!! This method is currently very inefficient, if alterations are made in the future, I
        //recommend optimising this one first.
        public Binding compareUnprocessed()
        {
            //Path to the unprocessed wav file
            string pathToUnprocessed = ProgramSettings.UnprocessedFileName;

            //Name of the xcorr library script we want to execute
            string pathToScript = ProgramSettings.MatcherExecutable;

            //Create an executor instance to pass commands to the cmd prompt
            Executor executor = new Executor();

            //String array that holds the script run results
            double[] compareResults = new double[bindings.Count];

            //Loop over each stored binding and execute the compare script on each of them.
            for (int i = 0; i < bindings.Count; i++)
            {
                //Build the command we wish to send to the overlap-analysis executable.
                string commandToExecute = pathToScript + " " + bindings[i].pathToWav + ".wav " + pathToUnprocessed;
                
                //Pass the command to the executor instance, and retrieve the result as a double (for comparison).
                compareResults[i] = Convert.ToDouble(executor.ExecuteCommand(commandToExecute));
            }

            //Find the index which holds the highest value in the array
            //BUG: It is possible (although very unlikely) for matches to generate the exact same match value, this could cause the wrong binding to be returned.
            double bestMatchValue = Convert.ToDouble(compareResults.Max());
            int bestMatchIndex = Array.IndexOf(compareResults, bestMatchValue);

            if (bestMatchValue < ProgramSettings.quality)
            {
                return null;
            }
            else
            {
                return bindings[bestMatchIndex];
            }
        }

        public void removeBindingAtIndex(int index)
        {
            //Prompt the user to confirm if they wish to delete the file or not.
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this binding?", "Confirm Deletion", MessageBoxButtons.YesNo);

            //If the user selects yes, delete the file as promised.
            if (dialogResult == DialogResult.Yes)
            {
                //First, delete the file that accompanies this bind index.
                File.Delete(bindings[index].pathToWav + ".wav");

                //Remove binding from binding list at specified index.
                bindings.RemoveAt(index);
            }
            else if (dialogResult == DialogResult.No)
            {
                //No action required.
            }
        }
    }
}
