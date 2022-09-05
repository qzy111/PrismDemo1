using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrismDemo.Views
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : UserControl
    {
        Move m = new Move();
        readonly ModelImporter import = new();//导入模型的类对象
        public Page1()
        {
            InitializeComponent();
            Model3DGroup g1 = import.Load(@"./resource/testmode.obj");
            Model3DGroup g2 = import.Load(@"./resource/VWBus.3ds");
            if (g1.Children.Count > 0)
            {
                for (int i = 0; i < g1.Children.Count; i++)
                {
                    GeometryModel3D models = g1.Children[i] as GeometryModel3D;
                    Brush brush = new SolidColorBrush(Colors.White)
                    {
                        Opacity = 0.5
                    };
                    DiffuseMaterial material = new(brush);

                    //EmissiveMaterial em = new EmissiveMaterial();
                    models.Material = material;
                }
            }
            model.Content = g1;
            model1.Content = g2;
            this.DataContext = m;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            m.CubeColor = "Purple";
        }
    }
    public class Move : INotifyPropertyChanged
    {
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
