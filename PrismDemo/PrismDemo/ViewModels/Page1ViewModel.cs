using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using FreeSQLHelper;

namespace PrismDemo.ViewModels
{
    public class Page1ViewModel : BindableBase
    {
        private readonly IFreeSql freeSql;
        public DelegateCommand ClickCommd { get; set; }
        public Page1ViewModel(IContainerExtension container)
        {
            freeSql = container.Resolve<Init>().GetInstance();
            ClickCommd = new DelegateCommand(ClickCommdExecute);
        }
        public Page1ViewModel() { }
        private void ClickCommdExecute()
        {
            MessageBox.Show("命令执行");
        }

        private double translateValue;
        public double TranslateValue
        {
            get { return translateValue; }
            set
            {
                if (translateValue != value)
                {
                    SetProperty(ref translateValue, value);

                }
            }
        }
        private Color color;
        public Color Color
        {
            get { return color; }
            set
            {
                if (color != value)
                {
                    string nameOfTheColor = MahApps.Metro.Controls.ColorHelper.GetColorName(value);
                    CubeColor = nameOfTheColor.Split("(")[0].Replace(" ", "");
                    SetProperty(ref color, value);
                }
            }
        }
        private string cubeColor = "Red";
        public string CubeColor
        {
            get { return cubeColor; }
            set
            {
                if (cubeColor != value)
                {
                    SetProperty(ref cubeColor, value);

                }
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        //{
        //    if (!Equals(field, newValue))
        //    {
        //        field = newValue;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //        return true;
        //    }

        //    return false;
        //}
    }
}
