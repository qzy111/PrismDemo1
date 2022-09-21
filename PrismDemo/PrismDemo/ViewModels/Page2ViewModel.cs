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
using System.Threading;
using System.Security.Cryptography.Xml;
using Org.BouncyCastle.Crypto.Engines;

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
        public string firstName="firstName";
        public string FirstName {
            get { return firstName; }
            set
            {
                SetProperty(ref firstName, value);
            }
        }
        public string lastName = "lastName";
        public string LastName
        {
            get { return lastName; }
            set
            {
                SetProperty(ref lastName, value);
            }
        }
        public List<Category> TaskList { get; set; }
        public Page2ViewModel(IContainerExtension container)
        {
            List<Task> list = new List<Task>();
            list.Add(new Task { Id = 10, Name = "任务10", Status = 0, Category = null, CategoryId = 0 });
            list.Add(new Task { Id = 11, Name = "任务11", Status = 0, Category = null, CategoryId = 0 });
            list.Add(new Task { Id = 12, Name = "任务12", Status = 0, Category = null, CategoryId = 0 });
            freeSql = container.Resolve<Init>().GetInstance();
           
            //TaskList = freeSql.Select<Task>().ToList();
            //freeSql.Insert(list).ExecuteAffrows();
            freeSql.Aop.CurdAfter += (s, e) =>
            {
                if (e.ElapsedMilliseconds > 200)
                {
                    //记录日志
                    //发送短信给负责人
                }
            };
            //freeSql.GlobalFilter.Apply<Task>("filter", a => a.Id == 1);
            //TaskList = freeSql.Select<Task>().IncludeMany(a=>a.Category.Where(b=>b.Id==a.Id)).ToList();

            List<Topic> topic_l = new()
            {
                new Topic{Title="topic1",CreateTime=DateTime.Now,Clicks=10,Category=new Category{Id=1, Name="category1",Parent=new CategoryType{ Id=1,Name="categorytype1"} },CategoryId=1 },
                new Topic{Title="topic2",CreateTime=DateTime.Now,Clicks=11,Category=new Category{Id=2, Name="category2",Parent=new CategoryType{ Id=2,Name="categorytype2"} },CategoryId=2 },
                new Topic{Title="topic3",CreateTime=DateTime.Now,Clicks=12,Category=new Category{Id=3, Name="category3",Parent=new CategoryType{ Id=3,Name="categorytype3"} },CategoryId=3 }
            };
            List<CategoryType> ctype_l = new()
            {
                new CategoryType{ Id=1,Name="categorytype1"},
                new CategoryType{ Id=2,Name="categorytype2"},
                new CategoryType{ Id=3,Name="categorytype3"}
            };
            List<Category> cat_l = new()
            {
               new Category{Id=1, Name="category1",Parent=new CategoryType{ Id=1,Name="categorytype1"} },
               new Category{Id=2, Name="category2",Parent=new CategoryType{ Id=2,Name="categorytype2"} },
               new Category{Id=3, Name="category3",Parent=new CategoryType{ Id=3,Name="categorytype3"} }
            };

            //freeSql.Insert(ctype_l).ExecuteAffrows();
            //freeSql.Insert(cat_l).ExecuteAffrows();
            TaskList = freeSql.Select<Category>().IncludeMany(a=>a.Topics.Take(1)).ToList();
        }
    }
}
