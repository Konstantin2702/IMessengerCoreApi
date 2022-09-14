using Microsoft.EntityFrameworkCore;

namespace iMessengerCoreAPI.Models.Data
{
    public class TestDbContext : RGDialogDbContext
    {
        public TestDbContext(DbContextOptions<RGDialogDbContext> options) : base(options)
        {
        }
    }
}
