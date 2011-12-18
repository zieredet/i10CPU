using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace MdPCPUGUI
{
    [ValueConversion(typeof(byte[]), typeof(string))]
    public class ByteArrayConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            byte[] bytes = (byte[])value;

            String[,] sArray = new String[bytes.Length / 2, 2];

            for (int x = 0; x < bytes.Length; x++)
            {
                for (int i = 0; i < 2; i++)
			    {
                    sArray[x, i] = bytes[x].ToString();
			    }
                
            }
            return sArray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
