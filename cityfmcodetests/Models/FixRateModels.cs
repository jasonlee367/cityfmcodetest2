using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cityfmcodetests.Models
{
	public class FixRateModels
	{
		public string SourceCurrency { get; set; }
		public string TargetCurrency { get; set; }
		public double? Rate { get; set; } = 1;
	}

	public enum Currency
	{
		AUD,
		USD,
		GBP
	}
}