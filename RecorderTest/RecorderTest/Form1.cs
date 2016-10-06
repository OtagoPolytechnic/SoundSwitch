using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecorderTest
{
    public partial class Form1 : Form
    {
        private Manager manager;

        public Form1()
        {
            InitializeComponent();

            manager = new Manager();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            manager.SetSourceListView(lvSource);
        }

        private NAudio.Wave.WaveIn sourceStream = null;
        private NAudio.Wave.DirectSoundOut waveOut = null;
        private NAudio.Wave.WaveFileWriter waveWriter = null;

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Checks to see if any device was selected
            if (lvSource.SelectedItems.Count == 0) return;

            // Obtain device number from the index of the first selected item
            int deviceNumber = lvSource.SelectedItems[0].Index;

            // Inititalise the source stream
            sourceStream = new NAudio.Wave.WaveIn();

            // Set the device number to the source stream
            sourceStream.DeviceNumber = deviceNumber;

            // Assign a wave format with the standard 44.1kHz and the device number's channel
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

            // Inititalise direct sound out object using source stream
            // **Can't do this because source stream is not actually a wave provider** 
            // Need to use a wave in provider to bridge the gap between the wave in object and the sound out object
            NAudio.Wave.WaveInProvider waveIn = new NAudio.Wave.WaveInProvider(sourceStream);

            // Create wave output device
            waveOut = new NAudio.Wave.DirectSoundOut();

            // Initialise it using wave in
            waveOut.Init(waveIn);

            // Can't just tell the direct sound output to start playing because it will be playing from an empty buffer
            // Have to tell source to begin recording first 
            // Start grabbing audio samples from microphone or wave input device and push them into the buffer
            // And then we can play the wave output device (A direct sound out), it will begin to consume that buffer
            sourceStream.StartRecording();
            waveOut.Play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }

            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;

                MessageBox.Show("Recording stopped!");
            }

            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnStop_Click(sender, e);
            this.Close();
        }
        
        // USED TO WRITE TO WAVE FILE
        private void btnWave_Click(object sender, EventArgs e)
        {
            // Checks to see if any device was selected
            if (lvSource.SelectedItems.Count == 0) return;

            // Prompt user a save file dialog
            /*SaveFileDialog save = new SaveFileDialog();
            // Provide filter to ensure user choose the wave file extension
            save.Filter = "Wave File (*.wav)|*.wav;";
            if (save.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;*/

            // Obtain device number from the index of the first selected item
            int deviceNumber = lvSource.SelectedItems[0].Index;

            // Inititalise the source stream
            sourceStream = new NAudio.Wave.WaveIn();
            // Set the device number to the source stream
            sourceStream.DeviceNumber = deviceNumber;
            // Assign a wave format with the standard 44.1kHz and the device number's channel
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

            // source stream will want a new event when there is data available  
            sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);
            // Inititalise WaveWriter
            // Enter file location and make sure the format saved is the same as the source stream
            waveWriter = new NAudio.Wave.WaveFileWriter("aaa.wav", sourceStream.WaveFormat);

            sourceStream.StartRecording();
        }

        private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            // Checks if wave writer exists 
            if (waveWriter == null)
            {
                waveWriter = new NAudio.Wave.WaveFileWriter("aaa.wav", sourceStream.WaveFormat);
            }

            int seconds = (int)(waveWriter.Length / waveWriter.WaveFormat.AverageBytesPerSecond);

            // Write data to the waveWriter
            // Data is a byte array 
            // Offset set to 0 to write the whole array of data
            // Count is the bytes recorded
            //waveWriter.Write(e.Buffer, 0, e.BytesRecorded);

            // Ensure wave file is written by flushing the data out with each write
            // Prevent RAM from being held
            //waveWriter.Flush();

            // Got it to record for 2 seconds
            if (seconds < 1)
            {
                // Write data to the waveWriter
                // Data is a byte array 
                // Offset set to 0 to write the whole array of data
                // Count is the bytes recorded
                waveWriter.Write(e.Buffer, 0, e.BytesRecorded);

                // Ensure wave file is written by flushing the data out with each write
                // Prevent RAM from being held
                waveWriter.Flush();
            }
            else
            {
                MessageBox.Show("Recording done!");
                waveWriter.Dispose();
                waveWriter = null;
            }

        }

        /***********************************************************************************/
        /***********************************************************************************/
        /***********************************************************************************/
        private void StartListening()
        {
            NAudio.Wave.WaveIn waveInStream = new NAudio.Wave.WaveIn();
            waveInStream.BufferMilliseconds = 200;
            waveInStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(waveInStream_DataAvailable);
            waveInStream.StartRecording();
        }

        private double calculateDBinRMS(NAudio.Wave.WaveInEventArgs e)
        {
            double sum = 0;

            for (var i = 0; i < e.Buffer.Length; i = i + 2)
            {
                double sample = BitConverter.ToInt16(e.Buffer, i) / 32768.0;
                sum += (sample * sample);
            }

            double rms = Math.Sqrt(sum / (e.Buffer.Length / 2)); // SOIMETHING AINT FUCKING RIGHT

            rms = rms * 10000;

            return rms;
        }

        //Handler for the sound listener
        private void waveInStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            double rms = calculateDBinRMS(e);

            string rmsFormatted = string.Format("{0:0.00}", rms);

            rbSoundLevel.AppendText(rmsFormatted + "\n"); 
        }

        private void tbListen_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        // Causes rich text box to scroll to the bottom when new data is written
        private void rbDecibel_TextChanged(object sender, EventArgs e)
        {
            rbSoundLevel.SelectionStart = rbSoundLevel.Text.Length;
            rbSoundLevel.ScrollToCaret();
        }

        /***********************************************************************************/
        /***********************************************************************************/
        /***********************************************************************************/
        private void btnRecordEverything_Click(object sender, EventArgs e)
        {
            // Checks to see if any device was selected
            if (lvSource.SelectedItems.Count == 0) return;

            // Obtain device number from the index of the first selected item
            int deviceNumber = lvSource.SelectedItems[0].Index;

            // Inititalise the source stream
            sourceStream = new NAudio.Wave.WaveIn();
            // Set the device number to the source stream
            sourceStream.DeviceNumber = deviceNumber;
            // Assign a wave format with the standard 44.1kHz and the device number's channel
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

            // source stream will want a new event when there is data available  
            sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(source_DataAvailable);

            sourceStream.StartRecording();
        }

        private bool recordedFlag = false;

        private void source_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            double rms = calculateDBinRMS(e);

            string rmsFormatted = string.Format("{0:0.00}", rms); // Just formats the RMS value

            rbSoundLevel.AppendText(rmsFormatted + "\n"); // Writes RMS to the rich text box

            if (recordedFlag == false)
            {
                if (rms > 700)
                {
                    // Inititalise WaveWriter
                    // Enter file location and make sure the format saved is the same as the source stream
                    waveWriter = new NAudio.Wave.WaveFileWriter("aaa.wav", sourceStream.WaveFormat);

                    // This writes the first byte of the sound
                    // FIXES THE CLIPPING SOUND
                    waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
                    waveWriter.Flush();

                    recordedFlag = true;
                }
            }

            if (recordedFlag == true)
            {
                int seconds = (int)(waveWriter.Length / waveWriter.WaveFormat.AverageBytesPerSecond); // Calculates the length(time) of the WAV file

                // Writes to the waveWriter if the file time length is less than what is set
                if (seconds < 1)
                {
                    // Write data to the waveWriter
                    // Data is a byte array 
                    // Offset set to 0 to write the whole array of data
                    // Count is the bytes recorded
                    waveWriter.Write(e.Buffer, 0, e.BytesRecorded);

                    // Ensure wave file is written by flushing the data out with each write
                    // Prevent RAM from being held
                    waveWriter.Flush();
                }
                else // Display the 
                {
                    MessageBox.Show("Recording done!");
                    waveWriter.Dispose();

                    recordedFlag = false;
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            manager.StartRecording(lvSource, rbSoundLevel);
        }
    }
}
