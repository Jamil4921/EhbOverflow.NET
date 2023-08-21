using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EhbOverflow
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<Note> Notes { get; set; } // List of notes associated with the user

        public User()
        {
            Notes = new List<Note>();
        }
    }
}
