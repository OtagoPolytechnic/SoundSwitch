using System;
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
    public partial class DebugForm : Form
    {
        Executor e1;

        public DebugForm()
        {
            InitializeComponent();

            e1 = new Executor();

            
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            //Feed a command here
            e1.ExecuteCommand("dir");
        }
    }
}
