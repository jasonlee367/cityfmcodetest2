using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cityfmcodetests.Models
{
	public class OrderRequestModels
	{
		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; }
		public List<OrderLine> LineItems { get; set; }
	}

	public class OrderLine
	{
		public string productId { get; set; }
		public int Quantity { get; set; }
	}
}