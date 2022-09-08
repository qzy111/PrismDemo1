using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using PrismDemo.Services;
using PrismDemo.Services.Interfaces;
using PrismDemo.Views;
using System;
using System.Reflection;
using System.Windows;

namespace PrismDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
