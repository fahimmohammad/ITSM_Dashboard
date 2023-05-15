using itsm.parser.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ITSM_MVC.Models
{
    public class ServerDBContext: DbContext
    {
        public ServerDBContext(DbContextOptions<ServerDBContext> options) : base(options) { }
        public DbSet<OTRS> OTRS { get; set; }
        public DbSet<GPlex> GPlex { get; set; }

    }
    
}
