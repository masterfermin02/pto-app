using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace PtoApp.Models
{
	public class PTOContext : DbContext
    {
		public PTOContext(DbContextOptions<PTOContext> options)
			: base(options)
		{
		}

        public DbSet<PaidTimeOff>? PaidTimeOffs { get; set; } = null;
        public DbSet<PtoType>? PtoTypes { get; set; } = null;
    }
}

