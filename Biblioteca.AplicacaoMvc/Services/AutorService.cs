using Biblioteca.AplicacaoMvc.Models;

namespace Biblioteca.AplicacaoMvc.Services
{
    public class AutorService
    {
        private readonly ApiClient _apiClient;

        public AutorService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<AutorVM>> ObterAutoresAsync()
        {
            return await _apiClient.GetAsync<List<AutorVM>>("/autor");
        }

        public async Task<AutorVM> CriarAutorAsync(AutorVM autor)
        {
            return await _apiClient.PostAsync<AutorVM>("/autor", autor);
        }

        public async Task<AutorVM> ObterAutorPorIdAsync(int id)
        {
            return await _apiClient.GetAsync<AutorVM>($"/autor/{id}");
        }

        public async Task<AutorVM> EditarAutorAsync(AutorVM autor)
        {
            return await _apiClient.PutAsync<AutorVM>($"/autor?id={autor.CodAu}", autor);
        }

        public async Task ExcluirAutorAsync(int id)
        {
            await _apiClient.DeleteAsync<AutorVM>($"/autor/{id}");
        }
    }
}
