using cityfmcodetests.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace cityfmcodetests.Controllers
{
	public class OrderController : Controller
	{
		static HttpClient client = new HttpClient();

		public OrderController()
		{
		}

		[System.Web.Http.AllowAnonymous]
		public async Task<ActionResult> GetProducts()
		{
			List<ProductsViewModels> list = new List<ProductsViewModels>();
			IEnumerable<ProductsViewModels> product = list;
			var username = "api-key";
			var password = "API-44SAUQWAIFA9MLA";
			string creds = string.Format("{0}:{1}", username, password);
			byte[] bytes = Encoding.ASCII.GetBytes(creds);
			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Add("api-key", "API-44SAUQWAIFA9MLA");
			client.DefaultRequestHeaders.Add("accept", "text/plain");
			HttpResponseMessage response = await client.GetAsync(
				"http://alltheclouds.com.au/api/Products");
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				JsonSerializerSettings settings = new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.All
				};

				//string strJson = JsonConvert.SerializeObject(content, settings);
				var responseModel = JsonConvert.DeserializeObject<IEnumerable<ProductsViewModels>>(content, settings);
				return View(responseModel);
			}
			return View(product);
		}

		[System.Web.Http.AllowAnonymous]
		public async Task<string> GetFixRate(string NewCurrency, string OldCurrency)
		{
			string rate = "1";
			//IEnumerable<FixRateModels> fixRate = list;
			if (NewCurrency != null && OldCurrency != null)
			{
				var username = "api-key";
				var password = "API-44SAUQWAIFA9MLA";
				string creds = string.Format("{0}:{1}", username, password);
				byte[] bytes = Encoding.ASCII.GetBytes(creds);
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Add("api-key", "API-44SAUQWAIFA9MLA");
				client.DefaultRequestHeaders.Add("accept", "text/plain");
				HttpResponseMessage response = await client.GetAsync(
					"http://alltheclouds.com.au/api/fx-rates");
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					JsonSerializerSettings settings = new JsonSerializerSettings
					{
						TypeNameHandling = TypeNameHandling.All
					};

					//string strJson = JsonConvert.SerializeObject(content, settings);
					var responseModel = JsonConvert.DeserializeObject<IEnumerable<FixRateModels>>(content, settings);
					var filterResponse = responseModel.Where(x => x.SourceCurrency == OldCurrency && x.TargetCurrency == NewCurrency).Distinct();
					if (filterResponse.Count() > 0)
					{
						return filterResponse.ToList().FirstOrDefault().Rate?.ToString();
					}
					else
					{
						filterResponse = responseModel.Where(x => x.SourceCurrency == OldCurrency || x.TargetCurrency == NewCurrency).Distinct();
						if (filterResponse.Count() > 1)
						{
							var tt = filterResponse.ToList().FirstOrDefault().Rate?.ToString() + "," + filterResponse.ToList()[1].Rate?.ToString();
							return tt;
						}
					}
				}
			}
			return rate;
		}

		[HttpPost]
		public async Task<ActionResult> GetProducts(IEnumerable<ProductsViewModels> productsViewModels)
		{
			List<ProductsViewModels> list = new List<ProductsViewModels>();
			IEnumerable<ProductsViewModels> product = list;
			//IEnumerable<FixRateModels> fixRate = list;
			var username = "api-key";
			var password = "API-44SAUQWAIFA9MLA";
			string creds = string.Format("{0}:{1}", username, password);
			byte[] bytes = Encoding.ASCII.GetBytes(creds);
			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Add("api-key", "API-44SAUQWAIFA9MLA");
			client.DefaultRequestHeaders.Add("accept", "text/plain");
			var jsonString = "";
			HttpContent httpcontent = new StringContent(jsonString, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PostAsync(
				"http://alltheclouds.com.au/api/Orders", httpcontent);
			if (response.IsSuccessStatusCode)
			{
				return await GetProducts();
			}
			return await GetProducts();
		}
	}
}