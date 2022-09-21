using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Data;

namespace PrismDemo.ViewModels
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CustomAttribute : Attribute
    {
        public string Name { get; }
        public string Comment { get; set; }
        public CustomAttribute(string name)
        {
            Name = name;
        }
    }

    public class CustomConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiConver : IMultiValueConverter
    {
        public string Symble { get; set; }
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string FirstName=values[0].ToString();
            string LastName=values[values.Length-1].ToString();
            return FirstName+Symble+ LastName;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
