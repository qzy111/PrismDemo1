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
using System.Runtime.Intrinsics.X86;
using System.Diagnostics;
using FreeSql;

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
            List<Task> list = new List<Task>();
            list.Add(new Task { Id = 10, Name = "任务10", Status = 0, Category = null, CategoryId = 0 });
            list.Add(new Task { Id = 11, Name = "任务11", Status = 0, Category = null, CategoryId = 0 });
            list.Add(new Task { Id = 12, Name = "任务12", Status = 0, Category = null, CategoryId = 0 });
            freeSql = container.Resolve<Init>().GetInstance();
            //TaskList = freeSql.Select<Task>().ToList();
            TaskList = freeSql.Select<Task>().IncludeMany(a=>a.Category.Where(b=>b.Id==a.Id)).ToList();
        }
    }
}
