using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace BV_Binding_Convert
{
    // Define the Convert method to change a DateTime object to // a month string.
    public class DataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string type = parameter.ToString();

            double count = (double)value;
            string temp;
            if (count < 60)
            {
                if (type == "1")
                    temp = "不及格";
                else
                    temp = "糟糕";
            }
            else if (count >= 60 && count <= 90)
            {
                if (type == "1")
                    temp = "及格";
                else
                    temp = "还行";
            }
            else
            {
                if (type == "1")
                    temp = "优秀";
                else
                    temp = "非常棒";
            }

            return temp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
