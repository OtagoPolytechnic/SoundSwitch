﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NAudio.Wave;
using System.Windows.Input;
using VoiceRecorder.Core;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;

namespace VoiceRecorder
{
    class WelcomeViewModel : ViewModelBase, IView
    {
        private ObservableCollection<string> recordingDevices;
        private int selectedRecordingDeviceIndex;
        private ICommand continueCommand;
        public const string ViewName = "WelcomeView";

        public WelcomeViewModel()
        {
            this.recordingDevices = new ObservableCollection<string>();
            this.continueCommand = new RelayCommand(() => MoveToRecorder());
        }

        public ICommand ContinueCommand { get { return continueCommand; } }

        public void Activated(object state)
        {
            this.recordingDevices.Clear();
            for (int n = 0; n < WaveIn.DeviceCount; n++)
            {
                this.recordingDevices.Add(WaveIn.GetCapabilities(n).ProductName);
            }
        }

        private void MoveToRecorder()
        {
            Messenger.Default.Send(new NavigateMessage(RecorderViewModel.ViewName, SelectedIndex));
        }

        public ObservableCollection<string> RecordingDevices 
        {
            get { return recordingDevices; }
        }

        public int SelectedIndex
        {
            get
            {
                return selectedRecordingDeviceIndex;
            }
            set
            {
                if (selectedRecordingDeviceIndex != value)
                {
                    selectedRecordingDeviceIndex = value;
                    RaisePropertyChanged("SelectedIndex");
                }
            }
        }
    }
}
