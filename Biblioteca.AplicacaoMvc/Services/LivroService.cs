using Biblioteca.AplicacaoMvc.Models;

namespace Biblioteca.AplicacaoMvc.Services
{
    public class LivroService
    {
        private readonly ApiClient _apiClient;

        public LivroService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<LivroVM>> ObterLivrosAsync()
        {
            return await _apiClient.GetAsync<List<LivroVM>>("/livro");
        }

        public async Task<LivroVM> CriarLivroAsync(LivroVM livro)
        {
            return await _apiClient.PostAsync<LivroVM>("/livro", livro);
        }

        public async Task<LivroVM> ObterLivroPorIdAsync(int id)
        {
            return await _apiClient.GetAsync<LivroVM>($"/livro/{id}");
        }

        public async Task<LivroVM> EditarLivroAsync(LivroVM livro)
        {
            return await _apiClient.PutAsync<LivroVM>($"/livro?id={livro.CodL}", livro);
        }

        public async Task ExcluirLivroAsync(int id)
        {
            await _apiClient.DeleteAsync<LivroVM>($"/livro/{id}");
        }
    }
}
