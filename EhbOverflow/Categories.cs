using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EhbOverflow
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string SubjectName { get; set; }
    }
}
