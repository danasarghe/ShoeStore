using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShoeStore.Data
{
    public partial class ShoeStoreContext
    {
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShoeStoreContext>
        {
            public ShoeStoreContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ShoeStoreContext>();
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q3V5PD4;Database=ShoeDB;Trusted_Connection=True;");

                return new ShoeStoreContext(optionsBuilder.Options);
            }
        }


    }
    
    

}
