using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo.Models
{
    public class Task
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Status { get; set;}
    }
}
