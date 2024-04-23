using Microsoft.EntityFrameworkCore;

namespace LayoutHomework.Models
{
	public class ProductsDb:DbContext
	{
		public DbSet<Products> Products { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase("ProductsDB");
		}
	}
}
