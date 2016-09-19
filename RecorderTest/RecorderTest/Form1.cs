﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecorderTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Obtain a list of wave in devices   
            // Capabilities such as the name of device and the channels it has
            List<NAudio.Wave.WaveInCapabilities> sources = new List<NAudio.Wave.WaveInCapabilities>();

            // Loop through the devices available and add it to the sources list
            for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                // Add to the sources list
                sources.Add(NAudio.Wave.WaveIn.GetCapabilities(i));
            }

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
            }

            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }

            MessageBox.Show("Recording stopped!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnStop_Click(sender, e);
            this.Close();
        }

        private void btnWave_Click(object sender, EventArgs e)
        {
            // Checks to see if any device was selected
            if (lvSource.SelectedItems.Count == 0) return;

            // Prompt user a save file dialog
            SaveFileDialog save = new SaveFileDialog();
            // Provide filter to ensure user choose the wave file extension
            save.Filter = "Wave File (*.wav)|*.wav;";
            if (save.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

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
            waveWriter = new NAudio.Wave.WaveFileWriter(save.FileName, sourceStream.WaveFormat);

            sourceStream.StartRecording();
        }

        private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            // Checks if wave writer exists 
            if (waveWriter == null) return;

            // Write data to the waveWriter
            // Data is a byte array 
            // Offset set to 0 to write the whole array of data
            // Count is the bytes recorded
            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);

            // Ensure wave file is written by flushing the data out with each write
            // Prevent RAM from being held
            waveWriter.Flush();
        }
    }
}