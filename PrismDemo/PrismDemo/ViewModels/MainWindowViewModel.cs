using ControlzEx.Theming;
using FreeSQLHelper;
using Prism.Ioc;
using Prism.Mvvm;
using PrismDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PrismDemo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IFreeSql freeSql;
        private string _title = "Prism Application Demo";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string menuTitle = "menu";
        public string MenuTitle
        {
            get { return menuTitle; }
            set { SetProperty(ref menuTitle, value); }
        }
        public MainWindowViewModel(IContainerExtension container)
        {
            freeSql = container.Resolve<Init>().GetInstance();
            var dataList = freeSql.Select<Task>().ToList();
            //Type t = typeof(SimpleCommand<string>);
            //var attrs = t.GetCustomAttributes(true);
            this.AccentColors = ThemeManager.Current.Themes
                                              .GroupBy(x => x.ColorScheme)
                                              .OrderBy(a => a.Key)
                                              .Select(a => new AccentColorMenuData { Name = a.Key, ColorBrush = a.First().ShowcaseBrush })
                                              .ToList();
        }
        public List<AccentColorMenuData> AccentColors { get; set; }
    }
    public class AccentColorMenuData
    {
        public string Name { get; set; }

        public Brush BorderColorBrush { get; set; }

        public Brush ColorBrush { get; set; }

        public AccentColorMenuData()
        {
            this.ChangeAccentCommand = new SimpleCommand<string>(o => true, this.DoChangeTheme);
        }

        public ICommand ChangeAccentCommand { get; }

        protected virtual void DoChangeTheme(string name)
        {
            if (name is not null)
            {
                ThemeManager.Current.ChangeThemeColorScheme(Application.Current, name);
            }
        }
    }
}
