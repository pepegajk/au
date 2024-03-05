using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace audioplayer
{
    public partial class MainWindow : Window
    {
        private List<string> playlist;
        private bool isPlaying;
        private bool isDraggingSlider;
        private bool isRepeat = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Audio Files (*.mp3, *.wav)|*.mp3;*.wav";
            if (openFileDialog.ShowDialog() == true)
            {
                playlist = openFileDialog.FileNames.ToList();
                PlaylistListBox.ItemsSource = playlist;
                Play();
            }
        }

        private void PlaylistListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlaylistListBox.SelectedIndex >= 0)
            {
                Stop();
                string selectedFile = PlaylistListBox.SelectedItem.ToString();
                Play(selectedFile);

              
                if (isRepeat)
                {
                    isRepeat = false;
                    RepeatButton.Content = "Repeat: Off";
                }
            }
        }

        private void AudioPlayerMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (AudioPlayerMediaElement.NaturalDuration.HasTimeSpan)
            {
                TimeSpan duration = AudioPlayerMediaElement.NaturalDuration.TimeSpan;
                PositionSlider.Maximum = duration.TotalSeconds;
            }
        }

        private void AudioPlayerMediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (isRepeat)
            {
                AudioPlayerMediaElement.Position = TimeSpan.Zero;
                AudioPlayerMediaElement.Play();
            }
            else
            {
                if (PlaylistListBox.SelectedIndex < playlist.Count - 1)
                {
                   
                    PlaylistListBox.SelectedIndex++;
                }
                else
                {
                    
                    Stop();
                }
            }
        }

        private void PositionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!isDraggingSlider)
            {
          
                TimeSpan newPosition = TimeSpan.FromSeconds(PositionSlider.Value);
                AudioPlayerMediaElement.Position = newPosition;
            }
        }

        private void Play(string filePath)
        {
            AudioPlayerMediaElement.Source = new Uri(filePath);
            AudioPlayerMediaElement.Play();
            isPlaying = true;
        }

        private void Play()
        {
            if (playlist != null && playlist.Count > 0)
            {
                PlaylistListBox.SelectedIndex = 0;
            }
        }

        private void Stop()
        {
            AudioPlayerMediaElement.Stop();
            isPlaying = false;
        }

        private void TogglePlayback()
        {
            if (isPlaying)
            {
                AudioPlayerMediaElement.Pause();
                isPlaying = false;
            }
            else
            {
                AudioPlayerMediaElement.Play();
                isPlaying = true;
            }
        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            TogglePlayback();
        }

       
        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            AudioPlayerMediaElement.Volume = e.NewValue;
        }

        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            int nextTrackIndex = PlaylistListBox.SelectedIndex + 1;

            if (nextTrackIndex >= PlaylistListBox.Items.Count)
            {
                nextTrackIndex = 0;
            }

            PlaylistListBox.SelectedIndex = nextTrackIndex;
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            isRepeat = !isRepeat;
            RepeatButton.Content = isRepeat ? "Repeat: On" : "Repeat: Off";
        }
    }
}