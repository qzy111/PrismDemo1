using Prism.Commands;
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

namespace PrismDemo.ViewModels
{
    public class Page1ViewModel : BindableBase, INotifyPropertyChanged
    {
        public DelegateCommand ClickCommd { get; set; }
        public Page1ViewModel()
        {
            ClickCommd = new DelegateCommand(ClickCommdExecute);
        }
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
                    translateValue = value;
                    this.OnPropertyChanged();

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
                    color = value;
                    this.OnPropertyChanged();
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
                    cubeColor = value;
                    this.OnPropertyChanged();

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
    }
}
