using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo.ViewModels
{
    public class Page4ViewModel : BindableBase
    {
        public List<Chose> Data { get; set; }
        public Page4ViewModel()
        {
            Data = new List<Chose>
            {
                new Chose() {  Name = "Chose1" },
                new Chose() {  Name = "Chose2" },
                new Chose() {  Name = "Chose3" },
                new Chose() {  Name = "Chose4" },
                new Chose() {  Name = "Chose5" },
                new Chose() {  Name = "Chose6" }
            };
        }
    }
    public class Chose
    {
        public string Name { get; set; }
    }
}
