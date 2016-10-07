using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecorderTest
{
    public class Manager
    {
        //Attributes
        private Recorder rec;
        private RecInterface ui;

        //Constructor
        public Manager()
        {
            rec = new Recorder();
            ui = new RecInterface();
        }

        //Methods
        // Displays onto the list view the available wave in devices
        public void SetSourceListView(ListView lvSource)
        {
            // Obtain a list of wave in devices and save into variable 'sources'
            List<NAudio.Wave.WaveInCapabilities> sources = rec.CheckForInputSources();

            // Add the lsit to the List View
            ui.WriteToSourceList(sources, lvSource);
        }

        // Starts the listening and recording 
        public void StartRecording(ListView lvSource, RichTextBox rtbSoundLevel)
        {
            // Checks if any source has been selected
            ui.CheckIfSourceSelected(lvSource);

            // Saves the source's number
            int deviceNumber = ui.ObtainDeviceNumberFromList(lvSource);

            // Sets up the source stream with that source device
            rec.SetUpSourceStream(deviceNumber);

            // Starts recording
            rec.Record((sender, e) => source_DataAvailable(sender, e, rtbSoundLevel));
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

        public void DisplayLatestRMS(RichTextBox rtbSoundLevel)
        {
            ui.DisplayLatestRMSInRichTextBox(rtbSoundLevel);
        }

        //Event Handler
        private void source_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e, RichTextBox rtbSoundLevel)
        {
            // Obtain RMS value
            double rms = rec.CalculateRMS(e);

            // Format the RMS to 2 decimal places
            string rmsFormatted = rec.FormatRMSOutput(rms);

            // Dispaly the RMS in Rich Text Box
            ui.SetRMStoRichTextBox(rmsFormatted, rtbSoundLevel);
            
            // If flagis false, check if the RMS exceeds the threshold
            if (rec.RecordedFlag == false)
            {
                if (rms > 700)
                {
                    // Inititalise WaveWriter
                    // Enter file location and make sure the format saved is the same as the source stream
                    rec.WaveWriter = new NAudio.Wave.WaveFileWriter("aaa.wav", rec.SourceStream.WaveFormat);

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
                if (seconds < 1)
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
    }
}
