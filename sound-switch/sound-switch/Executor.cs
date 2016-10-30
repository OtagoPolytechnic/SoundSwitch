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
        //Ctor
        public Executor()
        {
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
    }
}
