using RestSharp;

namespace Biblioteca.AplicacaoMvc.Services
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = await _client.ExecuteAsync<T>(request);

            if (!response.IsSuccessful)
            {
                throw new ApplicationException($"Erro ao consumir API: {response.StatusCode} - {response.ErrorMessage}");
            }

            return response.Data;
        }

        public async Task<T> PostAsync<T>(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(body);

            var response = await _client.ExecuteAsync<T>(request);

            if (!response.IsSuccessful)
            {
                throw new ApplicationException($"Erro ao consumir API: {response.StatusCode} - {response.ErrorMessage}");
            }

            return response.Data;
        }

        public async Task<T> PutAsync<T>(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddJsonBody(body);

            var response = await _client.ExecuteAsync<T>(request);

            if (!response.IsSuccessful)
            {
                throw new ApplicationException($"Erro ao consumir API: {response.StatusCode} - {response.ErrorMessage}");
            }

            return response.Data;
        }

        public async Task DeleteAsync<T>(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Delete);
            var response = await _client.ExecuteAsync<T>(request);

            if (!response.IsSuccessful)
            {
                throw new ApplicationException($"Erro ao consumir API: {response.StatusCode} - {response.ErrorMessage}");
            }
        }
    }
}
