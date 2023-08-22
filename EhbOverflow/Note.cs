using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EhbOverflow
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; } 

        [ForeignKey("CategoryId")]
        public Categories Category { get; set; }

        public string? ImagePath { get; set; }
    }
}
