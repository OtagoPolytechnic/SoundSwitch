﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sound_switch
{
    public class RecorderManager
    {
        //Attributes
        private Recorder rec;
        private int threshold;
        private int recSeconds;
        private bool thresFlag;
        private bool secFlag;

        //Properties
        public bool ThresFlag
        {
            get { return thresFlag; }
            set { thresFlag = value; }
        }
        public bool SecFlag
        {
            get { return secFlag; }
            set { secFlag = value; }
        }

        //Constructor
        public RecorderManager()
        {
            rec = new Recorder();
            threshold = 0;
            recSeconds = 1;
        }

        //Methods
        public void SetSourceListView(ListView lvSource)
        {
            // Clear the list view
            lvSource.Items.Clear();

            // Obtain a list of wave in devices and save into variable 'sources'
            List<NAudio.Wave.WaveInCapabilities> sources = rec.CheckForInputSources();

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
        private void checkIfSourceSelected(ListView lvSource)
        {
            if (lvSource.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a wave in device!");
            }
        }

        // Obtain the index value of the selected source from the List View
        private int obtainDeviceNumberFromList(ListView lvSource)
        {
            // Obtain device number from the index of the first selected item
            int deviceNumber = lvSource.SelectedItems[0].Index;

            return deviceNumber;
        }

        // Starts the listening and records when a sound exceeds threshold
        public void StartListening(ListView lvSource, RichTextBox rtbSoundLevel)
        {
            // Checks if any source has been selected
            checkIfSourceSelected(lvSource);

            // Saves the source's number
            int deviceNumber = obtainDeviceNumberFromList(lvSource);

            // Sets up the source stream with that source device
            rec.SetUpSourceStream(deviceNumber);

            // Starts recording
            rec.Record((sender, e) => sourceListening_DataAvailable(sender, e, rtbSoundLevel));
        }

        public void StartRecording(ListView lvSource)
        {
            // Checks if any source has been selected
            checkIfSourceSelected(lvSource);

            // Saves the source's number
            int deviceNumber = obtainDeviceNumberFromList(lvSource);

            // Sets up the source stream with that source device
            rec.SetUpSourceStream(deviceNumber);

        }

        // Kills all recording process
        public void Stop()
        {
            // If it is not null,
            // Stop the source stream and the wave writer
            if (rec.SourceStream != null)
            {
                rec.StopSourceStream();
            }

            if (rec.WaveWriter != null)
            {
                rec.StopWaveWriter();
            }
        }

        // Set the threshold and recording seconds values
        private void setValues(int threshold, int recSeconds)
        {
            this.threshold = threshold;
            this.recSeconds = recSeconds;
        }

        private void sourceListening_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e, RichTextBox rtbSoundLevel)
        {
            // Obtain RMS value
            double rms = rec.CalculateRMS(e);

            // Format the RMS to 2 decimal places
            string rmsFormatted = rec.FormatRMSOutput(rms);

            // Dispaly the RMS in Rich Text Box
            rtbSoundLevel.AppendText(rmsFormatted + "\n");

            // If flagis false, check if the RMS exceeds the threshold
            if (rec.RecordedFlag == false)
            {
                if (rms > threshold)
                {
                    // Inititalise WaveWriter
                    // Enter file location and make sure the format saved is the same as the source stream
                    rec.WaveWriter = new NAudio.Wave.WaveFileWriter(ProgramSettings.UnprocessedFileName, rec.SourceStream.WaveFormat);

                    // Write the first byte of the sound when triggered
                    rec.WriteToWaveWriter(e);

                    // Set flag to true 
                    rec.RecordedFlag = true;
                }
            }

            // If the flag is true, check to see if it is writing for 
            if (rec.RecordedFlag == true)
            {
                // Obtain the length of time in the wave file writer
                int seconds = rec.WaveWriterLengthOfTime();

                // If it is less than 1 second, then write data to the wave file writer
                if (seconds < recSeconds)
                {
                    rec.WriteToWaveWriter(e);
                }
                else // Display message box and dispose ofthe wave file writer
                {
                    MessageBox.Show("Rec done!");

                    rec.WaveWriter.Dispose();

                    // Set flag to false
                    rec.RecordedFlag = false;
                }
            }
        }

        public string DisplaySelectedDeviceName(ListView lvSource)
        {
            ListView.SelectedIndexCollection sel = lvSource.SelectedIndices;
            string deviceName = "";

            if (sel.Count == 1)
            {
                MessageBox.Show("Device Selected!");
                ListViewItem selItem = lvSource.Items[sel[0]];
                deviceName = selItem.SubItems[0].Text;
            }

            return deviceName;
        }

        public bool CheckRegex(TextBox tb)
        {
            string pattern = @"^[1-9]\d*$";

            bool regexFlag;

            Regex reg = new Regex(pattern);

            if (reg.IsMatch(tb.Text))
            {
                regexFlag = true;
            }
            else
            {
                regexFlag = false;
            }

            return regexFlag;
        }

        public void SetValues(TextBox tbThreshold, TextBox tbSeconds)
        {
            // Convert text to int
            try
            {
                int thresConv = Int32.Parse(tbThreshold.Text);
                int secConv = Int32.Parse(tbSeconds.Text);

                // Set the values 
                if (thresFlag == true && secFlag == true)
                {
                    setValues(threshold, recSeconds);
                    MessageBox.Show("Values set!");
                }
                else
                {
                    MessageBox.Show("Please enter positive numeric values!");
                }
            }
            catch
            {
                MessageBox.Show("Please do not leave fields empty");
            }
        }
    }
}
