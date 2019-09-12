using NumberToSentenceConverter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToSentenceConverter.ViewModels
{
    public class ConverterVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string value;

        public string Value { get => value; set { this.value = value; OnPropertyChanged("Result"); } }
        
        public string Result { get => Converter.toSentence(value);}

        
    }
}
