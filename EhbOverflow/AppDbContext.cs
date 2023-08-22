using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace EhbOverflow
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\furqa\\OneDrive - Erasmushogeschool Brussel\\Documenten\\EhbUsers.mdf\";Integrated Security=True;Connect Timeout=30")
        {
        }

        public DbSet<Categories> Categories { get; set; }
    }
}


