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
        public void SetSourceListView(ListView lvSource)
        {
            List<NAudio.Wave.WaveInCapabilities> sources = rec.CheckForInputSources();
            ui.WriteToSourceList(sources, lvSource);
        }

        public void StartRecording(ListView lvSource, RichTextBox rtbSoundLevel)
        {
            ui.CheckIfSourceSelected(lvSource);

            int deviceNumber = ui.ObtainDeviceNumberFromList(lvSource);

            rec.SetUpSourceStream(deviceNumber);

            rec.SourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>((sender, e) => source_DataAvailable(sender, e, rtbSoundLevel));

            rec.SourceStream.StartRecording();
        }

        //Event Handler
        private void source_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e, RichTextBox rtbSoundLevel)
        {
            double rms = rec.CalculateRMS(e);

            string rmsFormatted = rec.FormatRMSOutput(rms);

            rtbSoundLevel.AppendText(rmsFormatted + "\n"); // Writes RMS to the rich text box
       
            if (rec.RecordedFlag == false)
            {
                if (rms > 700)
                {
                    // Inititalise WaveWriter
                    // Enter file location and make sure the format saved is the same as the source stream
                    rec.WaveWriter = new NAudio.Wave.WaveFileWriter("aaa.wav", rec.SourceStream.WaveFormat);

                    rec.WriteToWaveWriter(e);

                    rec.RecordedFlag = true;
                }
            }

            if (rec.RecordedFlag == true)
            {
               int seconds = rec.WaveWriterLengthOfTime();

                if (seconds < 1)
                {
                    rec.WriteToWaveWriter(e);
                }
                else
                {
                    MessageBox.Show("Rec done!");

                    rec.WaveWriter.Dispose();

                    rec.RecordedFlag = false;
                }
            }
        }
    }
}
