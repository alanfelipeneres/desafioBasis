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
            return await _apiClient.PostAsync<LivroVM>("/livros", livro);
        }
    }
}
