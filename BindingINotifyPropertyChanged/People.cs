using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV_Binding_INotifyPropertyChanged
{
    public class People : INotifyPropertyChanged
    {
        private int age = 0;

        private string typeLevel = "未成年";

        public string TypeLevel
        {
            get { return typeLevel; }
            set
            {
                typeLevel = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                if (age < 18)
                {
                    TypeLevel = "未成年";
                }
                else
                { 
                    TypeLevel = "成年";
                    NotifyPropertyChanged(string.Empty);
                    return;
                }

                NotifyPropertyChanged("Age");
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
