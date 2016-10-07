using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecorderTest
{
    public class RecInterface
    {
        //Methods
        // Adds the sources to the List View
        public void WriteToSourceList(List<NAudio.Wave.WaveInCapabilities> sources, ListView lvSource)
        {
            // Clear the list view
            lvSource.Items.Clear();

            // Checks to see if there are any recording devices connected
            if (sources.Count == 0)
            {
                MessageBox.Show("No wave in devices found!");
            }
            else
            {
                // Loop through the list of sources and add it to the list view
                foreach (var source in sources)
                {
                    // Create an item with the product name of the source for the left most column
                    ListViewItem item = new ListViewItem(source.ProductName);

                    // Adds the channels as a subitem to the product name
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, source.Channels.ToString()));

                    // Add the item to the list view
                    lvSource.Items.Add(item);
                }
            }
        }

        // Checks if any source device has been selected
        public void CheckIfSourceSelected(ListView lvSource)
        {
            if (lvSource.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a wave in device!");
            }
        }

        // Obtain the index value of the selected source from the List View
        public int ObtainDeviceNumberFromList(ListView lvSource)
        {
            // Obtain device number from the index of the first selected item
            int deviceNumber = lvSource.SelectedItems[0].Index;

            return deviceNumber;
        }

        // Displays the RMS value ont othe Rich Text Box
        public void SetRMStoRichTextBox(string rmsFormatted, RichTextBox rbSoundLevel)
        {
            rbSoundLevel.AppendText(rmsFormatted + "\n");
        }

        public void DisplayLatestRMSInRichTextBox(RichTextBox rbSoundLevel)
        {
            rbSoundLevel.SelectionStart = rbSoundLevel.Text.Length;
            rbSoundLevel.ScrollToCaret();
        }
    }
}
