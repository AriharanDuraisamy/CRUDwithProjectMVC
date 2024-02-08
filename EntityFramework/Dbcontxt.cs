using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Dbcontxt: DbContext
    {
       /* public Dbcontxt() : base(DbConnection)
        {

        }*/

        public Dbcontxt(DbContextOptions<Dbcontxt> options) : base(options)
        {

        }
        public DbSet<StudentDetails> StudDetail { get; set; }
    }
}
