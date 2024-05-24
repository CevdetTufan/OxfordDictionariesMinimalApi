namespace OxfordDictionariesHttpClient.Interfaces
{
	public interface IHttpPost
	{
		Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest content);
	}
}
