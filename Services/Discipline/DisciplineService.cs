using EasyToEnter.ASP.Models.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EasyToEnter.ASP.Services.Discipline
{
    public class DisciplineService: IDisciplineService
    {
        private readonly HttpClient HttpClient;

        public DisciplineService(HttpClient httpClient) => HttpClient = httpClient;

        public async Task<List<DisciplineModel>> GetDisciplineList()
        {
            HttpResponseMessage response = await HttpClient.GetAsync("api/Discipline");
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            List<DisciplineModel>? disciplineList = await JsonSerializer.DeserializeAsync<List<DisciplineModel>>(responseContent);

            if (disciplineList != null) return disciplineList;

            return new List<DisciplineModel>();
        }
    }
}