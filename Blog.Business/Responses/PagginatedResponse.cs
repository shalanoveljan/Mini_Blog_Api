using System;
namespace Blog.Business.Responses
{
	public class PagginatedResponse<T>
	{
		public IEnumerable<T> Items { get; set; }
		public int CurrentPage { get; set; }
		public decimal TotalPages { get; set; }
	}
}

