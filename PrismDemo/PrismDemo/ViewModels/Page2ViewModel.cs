using ControlzEx.Standard;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo.ViewModels
{
    internal class Page2ViewModel : BindableBase
    {
        private string name="This is a Name";
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }
    }
}
