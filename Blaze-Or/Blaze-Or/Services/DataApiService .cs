using Blaze_Or.Components;
using Blaze_Or.Factories;
using Blaze_Or.Models;

namespace Blaze_Or.Services
{
    public class DataApiService : IDataService
    {
        private readonly HttpClient _http;

        public DataApiService(
            HttpClient http)
        {
            _http = http;
        }

        public async Task Add(ItemModel model)
        {
            // Get the item
            var item = ItemFactory.Create(model);

            // Save the data
            await _http.PostAsJsonAsync("https://localhost:7234/api/Crafting/", item);
        }

        public async Task<int> Count()
        {
            return await _http.GetFromJsonAsync<int>("https://localhost:7234/api/Crafting/count");
        }

        public async Task<List<Item>> List(int currentPage, int pageSize)
        {
            return await _http.GetFromJsonAsync<List<Item>>($"https://localhost:7234/api/Crafting/?currentPage={currentPage}&pageSize={pageSize}");
        }

        public async Task<Item> GetById(int id)
        {
            return await _http.GetFromJsonAsync<Item>($"https://localhost:7234/api/Crafting/{id}");
        }

        public async Task Update(int id, ItemModel model)
        {
            // Get the item
            var item = ItemFactory.Create(model);

            await _http.PutAsJsonAsync($"https://localhost:7234/api/Crafting/{id}", item);
        }

        public async Task Delete(int id)
        {
            await _http.DeleteAsync($"https://localhost:7234/api/Crafting/{id}");
        }

<<<<<<< HEAD
        public Task<List<CraftingRecipe>> GetRecipes()
        {
            throw new NotImplementedException();
        }

        /*public async Task<List<CraftingRecipe>> GetRecipes()
=======
        public async Task<List<CraftingRecipe>> GetRecipes()
>>>>>>> 7a331b8015a32361caa1eacf4830078aba10249f
        {
            return await _http.GetFromJsonAsync<List<CraftingRecipe>>("https://localhost:7234/api/Crafting/recipe");
        }
    }
}
