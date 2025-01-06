using Biblioteca.AplicacaoMvc.Models;

namespace Biblioteca.AplicacaoMvc.Services
{
    public class RelatorioService
    {
        private readonly ApiClient _apiClient;

        public RelatorioService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<ViewLivrosPorAutorVM>> ObterViewAsync()
        {
            return await _apiClient.GetAsync<List<ViewLivrosPorAutorVM>>("/relatorio");
        }
    }
}
