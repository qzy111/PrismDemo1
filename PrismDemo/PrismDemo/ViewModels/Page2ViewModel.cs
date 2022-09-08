using ControlzEx.Standard;
using FreeSQLHelper;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PrismDemo.Models;

namespace PrismDemo.ViewModels
{
    internal class Page2ViewModel : BindableBase
    {
        private readonly IFreeSql freeSql;
        private string name = "This is a Name";
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }
        public List<Task> TaskList { get; set; }
        public Page2ViewModel(IContainerExtension container)
        {
            freeSql = container.Resolve<Init>().GetInstance();
            TaskList = freeSql.Select<Task>().ToList();
        }
    }
}
