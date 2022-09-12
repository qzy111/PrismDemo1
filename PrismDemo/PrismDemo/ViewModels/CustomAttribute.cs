using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
}
