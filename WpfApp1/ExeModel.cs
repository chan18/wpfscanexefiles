using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp1
{
    public class ExeModel : INotifyPropertyChanged
    {
        private string exePath;

        public event PropertyChangedEventHandler PropertyChanged;
              
        public string execFilePath
        {
            get { return exePath; }
            set
            {
                exePath = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("PersonName");
            }
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string exePath)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(exePath));
            }
        }

    }
}
