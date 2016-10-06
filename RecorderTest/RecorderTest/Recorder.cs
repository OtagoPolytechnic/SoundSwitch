using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;

namespace RecorderTest
{
    public class Recorder
    {
        //Attributes
        private NAudio.Wave.WaveIn sourceStream;
        private NAudio.Wave.WaveFileWriter waveWriter;
        private bool recordedFlag;

        //Constructor
        public Recorder()
        {
            sourceStream = null;
            waveWriter = null;
            recordedFlag = false;
        }

        // Getters/Setters
        public bool RecordedFlag
        {
            get { return recordedFlag; }
            set { recordedFlag = value; }
        }
        public NAudio.Wave.WaveFileWriter WaveWriter
        {
            get { return waveWriter; }
            set { waveWriter = value; }
        }
        public NAudio.Wave.WaveIn SourceStream
        {
            get { return sourceStream; }
            set { sourceStream = value; }
        }

        //Methods
        public List<NAudio.Wave.WaveInCapabilities> CheckForInputSources()
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

            return sources;
        }

        public void SetUpSourceStream(int deviceNumber)
        {
            // Inititalise the source stream
            sourceStream = new NAudio.Wave.WaveIn();
            // Set the device number to the source stream
            sourceStream.DeviceNumber = deviceNumber;
            // Assign a wave format with the standard 44.1kHz and the device number's channel
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);
        }

        public double CalculateRMS(NAudio.Wave.WaveInEventArgs e)
        {
            double sum = 0;

            for (var i = 0; i < e.Buffer.Length; i = i + 2)
            {
                double sample = BitConverter.ToInt16(e.Buffer, i) / 32768.0;
                sum += (sample * sample);
            }

            double rms = Math.Sqrt(sum / (e.Buffer.Length / 2)); 

            rms = rms * 10000;

            return rms;
        }

        public string FormatRMSOutput(double rms)
        {
            string rmsFormatted = string.Format("{0:0.00}", rms);

            return rmsFormatted;
        }

        public void WriteToWaveWriter(NAudio.Wave.WaveInEventArgs e)
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

        public int WaveWriterLengthOfTime()
        {
            int seconds = (int)(waveWriter.Length / waveWriter.WaveFormat.AverageBytesPerSecond);

            return seconds;
        }

        public void Record(EventHandler<NAudio.Wave.WaveInEventArgs> e)
        {
            // Source stream will want a new event when there is data available  
            sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(e);

            sourceStream.StartRecording();
        }
    }
}
