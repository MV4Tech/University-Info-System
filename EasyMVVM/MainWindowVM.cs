using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyMVVM
{
    class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        private ObservableCollection<string> _BackingProperty;

        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set
            {
                _BackingProperty = value;
                PropChanged("BoundProperty");
            }
        }


        public MainWindowVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }

  

        public void PropChanged(String propertyName)
        {
            //Did WPF registerd to listen to this event
            if (PropertyChanged != null)
            {
                //Tell WPF that this property changed
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

    }
}
