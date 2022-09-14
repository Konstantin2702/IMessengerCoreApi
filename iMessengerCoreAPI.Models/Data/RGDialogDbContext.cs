using iMessengerCoreAPI.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace iMessengerCoreAPI.Models.Data
{
    public class RGDialogDbContext : DbContext
    {

        public DbSet<RGDialogsClients> RGDialogsClients {get; set;}
        public RGDialogDbContext(DbContextOptions<RGDialogDbContext> options) : base(options)
        {
        
        }
    }
}
