using System.ComponentModel;
using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Process[] Processes;
        public string execPath;

        public ObservableCollection<string> files = new ObservableCollection<string>();

        public ObservableCollection<string> GetFiles
        {
            get { return files; }
            set
            {
                files = value;
                OnPropertyChanged("files");
            }
        }

        public string filePath {
            get { return execPath;  }
            set {
                execPath = value;
                OnPropertyChanged("filePath");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            DataContext = this;
            Processes = Process.GetProcesses();
            InitializeComponent();
        }

        public Process[] AllProcess
        {
            get { return Processes; }
            set
            {
                Processes = value;

                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("AllProcess");
            }
        }

        

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string value)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(value));
            }
        }

        private void fetchFiles(object sender, RoutedEventArgs e)
        {
            this.scanner();

        }

        public void scanner()
        {
            List<DriveInfo> infoList = DriveInfo.GetDrives().Where(x => x.IsReady == true).ToList();

            foreach (DriveInfo d in infoList)
            {
                this.Findfile(d.Name, "*.exe");

                Console.WriteLine("Scann Complete"+ files);
            }
        }

        public void Findfile(string folder, string fname)
        {

            foreach (string newFolder in Directory.GetDirectories(folder))
            {
                try
                {
                    DirectoryInfo dinfo = new DirectoryInfo(newFolder);

                    FileInfo[] Files = dinfo.GetFiles(fname);

                    foreach (FileInfo file in Files)
                    {
                        files.Add(file.FullName);
                    }

                    Console.WriteLine($"scann on:- {dinfo.Name}");

                }
                catch (Exception e)
                {
                    Console.WriteLine($"error on getting dir, {e.Message}");
                }
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string openFile = (sender as Button).Content.ToString();
            //Process.Start("notepad.exe");
            Process.Start(openFile);
            Console.WriteLine(e.Source.ToString());
        }
    }
}
