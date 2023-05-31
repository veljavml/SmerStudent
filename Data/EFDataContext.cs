using Microsoft.EntityFrameworkCore;
using StudentSmer3.Models;

namespace StudentSmer3.Data
{
    public class EFDataContext:DbContext
    {
        public EFDataContext(DbContextOptions options):base (options)
        {
            
        }

        public DbSet<Smer> Smerovi { get; set; }
        public DbSet<Student> Studenti { get; set; }
    }
}
