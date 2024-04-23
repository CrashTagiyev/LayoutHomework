using Microsoft.EntityFrameworkCore;

namespace LayoutHomework.Models
{
	public class Products
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public double Price { get; set; }	
	}
}
