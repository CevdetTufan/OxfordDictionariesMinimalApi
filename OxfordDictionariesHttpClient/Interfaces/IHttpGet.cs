namespace OxfordDictionariesHttpClient.Interfaces
{
    public interface IHttpGet
    {
        Task<T> GetAsync<T>(string url, IDictionary<string, string> headers = null);
    }
}
