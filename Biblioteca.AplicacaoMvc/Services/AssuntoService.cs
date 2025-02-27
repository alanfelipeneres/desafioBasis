﻿using Biblioteca.AplicacaoMvc.Models;

namespace Biblioteca.AplicacaoMvc.Services
{
    public class AssuntoService
    {
        private readonly ApiClient _apiClient;

        public AssuntoService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<AssuntoVM>> ObterAssuntosAsync()
        {
            return await _apiClient.GetAsync<List<AssuntoVM>>("/assunto");
        }

        public async Task<AssuntoVM> CriarAssuntoAsync(AssuntoVM assunto)
        {
            return await _apiClient.PostAsync<AssuntoVM>("/assunto", assunto);
        }

        public async Task<AssuntoVM> ObterAssuntoPorIdAsync(int id)
        {
            return await _apiClient.GetAsync<AssuntoVM>($"/assunto/{id}");
        }

        public async Task<AssuntoVM> EditarAssuntoAsync(AssuntoVM assunto)
        {
            return await _apiClient.PutAsync<AssuntoVM>($"/assunto?id={assunto.CodAs}", assunto);
        }

        public async Task ExcluirAssuntoAsync(int id)
        {
            await _apiClient.DeleteAsync<AssuntoVM>($"/assunto/{id}");
        }
    }
}
