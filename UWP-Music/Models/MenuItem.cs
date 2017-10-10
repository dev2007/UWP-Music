using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWP_Music.Models
{
    public class MenuItem : INotifyPropertyChanged
    {
        public Symbol Icon { get; set; }
        public string Text { get; set; }
        public string ShortText
        {
            get
            {
                if (Text.RealLength() > 9)
                {
                    var text = Text.RealSubString(8);
                    if (text != Text)
                        return text + "...";
                    return text;
                }

                return Text;
            }
        }

        private Visibility selected = Visibility.Collapsed;
        public Visibility Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                this.OnPropertyChanged("Selected");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
