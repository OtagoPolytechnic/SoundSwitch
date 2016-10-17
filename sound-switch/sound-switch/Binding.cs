using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sound_switch
{
    class Binding
    {
        //Descriptive name of the sound binding.
        public string bindTarget;

        //Keybind code of the bindings
        public string bindCode;

        //Location of this bindings sound file.
        public string pathToWav;

        //Ctor
        public Binding(string bindTarget, string bindCode, bool suppressWarns)
        {
            this.bindTarget = bindTarget;
            this.bindCode = bindCode;

            //Debug
            pathToWav = bindTarget + "_" + bindCode;

            //Check that we have an unprocessed file to work with
            if (File.Exists(ProgramSettings.UnprocessedFileName))
            {
                //Check if the binding we're trying to make already has a file.
                if (File.Exists(pathToWav + ".wav"))
                {
                    MessageBox.Show("Binding could not be created, a binding with the same name already exists.");
                }
                else
                {
                    //Bind file successfully made
                    File.Move(ProgramSettings.UnprocessedFileName, pathToWav + ".wav");
                }
            }
            else if(!suppressWarns)
            {
                MessageBox.Show("Unprocessed wav not found, maybe you didn't record a sound first?");
            }
        }

        //Method to return the full file path of a bind name. Used by recorder.
        public string returnFullpath()
        {
            return pathToWav + ".wav";
        }
    }
}
