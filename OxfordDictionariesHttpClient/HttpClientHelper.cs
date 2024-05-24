using Newtonsoft.Json;
using OxfordDictionariesHttpClient.Interfaces;
using System.Text;

namespace OxfordDictionariesHttpClient
{
	public class HttpClientHelper : IHttpGet, IHttpPost
	{
		private readonly HttpClient _httpClient;

		public HttpClientHelper(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<T> GetAsync<T>(string url, IDictionary<string, string> headers = null)
		{
			if (headers != null)
			{
				foreach (var header in headers)
				{
					_httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
				}
			}

			HttpResponseMessage response = await _httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();

			string responseData = await response.Content.ReadAsStringAsync();
			T result = JsonConvert.DeserializeObject<T>(responseData);
			return result;
		}

		public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest content)
		{
			string jsonContent = JsonConvert.SerializeObject(content);
			StringContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

			HttpResponseMessage response = await _httpClient.PostAsync(url, httpContent);
			response.EnsureSuccessStatusCode();

			string responseData = await response.Content.ReadAsStringAsync();
			TResponse result = JsonConvert.DeserializeObject<TResponse>(responseData);
			return result;
		}
	}
}
