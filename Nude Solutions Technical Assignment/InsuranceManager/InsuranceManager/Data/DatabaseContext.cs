using InsuranceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManager.Data
{
    /// <summary>
    /// Represents the database context class.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Property to set or return the high value item set.
        /// </summary>
        public DbSet<HighValueItem>? HighValueItemSet
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DatabaseContext"/> class.
        /// </summary>
        /// <param name="options">The database context options</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
    }
}
