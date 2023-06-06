using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cityfmcodetests.Models
{
	// Models returned by MeController actions.
	public class ProductsViewModels
	{
		[Display(Name = "Product Id")]
		public string ProductId { get; set; }

		[Display(Name = "Product Name")]
		public string Name { get; set; }

		[Display(Name = "Product Description")]
		public string Description { get; set; }

		[Display(Name = "Unit Price")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n}")]
		public double? UnitPrice { get; set; }

		[Display(Name = "Maximum Quantity")]
		public int? MaximumQuantity { get; set; } = 0;

		[Display(Name = "Order Quantity")]
		[Range(0, 999)]
		public int? OrderQuantity { get; set; } = 0;
	}
}