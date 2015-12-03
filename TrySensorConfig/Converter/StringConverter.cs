﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TrySensorConfig.Converter
{
    [ValueConversion(typeof(object), typeof(string))]
    public class StringConverter : BaseConverter, IValueConverter
    {
        // Because deriving from MarkupExtension, the compiler
        // does not auto-generate a default constructor
        public StringConverter() { }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string valstring = string.Format("{0:0.00}", value);
                return valstring;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value as string;
            if (val != null)
            {
                if (string.Equals(targetType.Name, "double", StringComparison.OrdinalIgnoreCase))
                {
                    return Double.Parse(val);
                }
            }
            return null;
        }
    }
}

