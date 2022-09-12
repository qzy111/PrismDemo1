using MahApps.Metro.Controls;
using Prism.Ioc;
using Prism.Regions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using FreeSQLHelper;
using PrismDemo.Models;

namespace PrismDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Dictionary<string, UserControl> dic_control = new Dictionary<string, UserControl>();
        IContainerExtension _container;
        IRegionManager _regionManager;

        public MainWindow(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;
        }

        private void LaunchMahAppsOnGitHub(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/MahApps/MahApps.Metro");
        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            if (!dic_control.ContainsKey("page1"))
            {
                dic_control.Add("page1", new Page1());
            }
            contentControl1.Content = dic_control["page1"];
            //if (_regionManager.Regions["ContentRegion1"].Views.Contains(typeof(Page2))) {
            //    _regionManager.Regions["ContentRegion1"].Remove(typeof(Page2));
            //}

            //_regionManager.RegisterViewWithRegion("ContentRegion1", typeof(Page1));
            //MessageBox.Show(dep.Dep.ToString());
        }

        private void File2_Click(object sender, RoutedEventArgs e)
        {
            if (!dic_control.ContainsKey("page2"))
            {
                dic_control.Add("page2", new Page2());
            }
            if (_regionManager.Regions["ContentRegion1"].Views.Contains(typeof(Page1)))
            {
                _regionManager.Regions["ContentRegion1"].Remove(typeof(Page1));
            }
            //_regionManager.RegisterViewWithRegion("ContentRegion1", typeof(Page2));
            contentControl1.Content = dic_control["page2"];
            //dep.Dep = new Thickness(4);
        }
    }
}
