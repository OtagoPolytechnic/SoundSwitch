using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sound_switch
{
    //Executor class is used to interpret a string as a console command.
    public class Executor
    {
        //String to hold a desired command
        string command;

        //String to hold the location of the script we want to run
        string scriptLocation;

        //String to hold the location of the users python library
        string pythonLocation;

        //Ctor
        public Executor()
        {
            //Init command as blank string at creation.
            command = "";

            pythonLocation = "C:\\Python27\\python.exe";
            scriptLocation = "H:\\Github\\SoundSwitch\\python-recorder\\Recorder.py";
        }

        //Methods
        public string ExecuteCommand(string command)
        {
            try
            {
                //Begin running the 'cmd' process in the background.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c" + command);

                //Redirect output to the newly created process
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;

                //Prevents the typical black console window from opening
                procStartInfo.CreateNoWindow = true;

                //Create a process and assign it to procStart instance
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = procStartInfo;
                process.Start();

                //Read output into a var
                string result = process.StandardOutput.ReadToEnd();
                return result;
            }
            catch(Exception objException){
                return null;
            }
        }

        public void runPollingScript()
        {
            //Build a ProcessStart variable, and provide it with a set of properties.
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = pythonLocation;
            start.Arguments = scriptLocation;
            start.UseShellExecute = false;  //Required to hide the window.
            start.CreateNoWindow = true;    //Functions under the assumption that useShellExecute will be false.

            //Begin running the process.
            Process process = Process.Start(start);
        }
    }
}
