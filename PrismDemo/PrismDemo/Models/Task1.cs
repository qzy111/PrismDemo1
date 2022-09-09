using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo.Models
{
    public class Task1
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ParentId { get; set; }
        public Task2 Parent { get; set; }
        public List<Task> Topics { get; set; }
    }
}
