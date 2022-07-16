using System.Collections.Generic;
using System.Text.Json;

namespace DesignPatterns.Services;

public class DesignPatternsService : ITransientService
{
    private List<Category> Categories = new();
    private List<Pattern> Patterns = new();

    public DesignPatternsService()
    {
        Task.Run(async () =>
       {
           await LoadCategoriesFromJson();
           await LoadPatternsFromFile();
       });
    }

    async Task LoadCategoriesFromJson()
    {
        using Stream stream = await FileSystem.OpenAppPackageFileAsync("categories.json");

        using StreamReader streamReader = new StreamReader(stream);

        var content = streamReader.ReadToEnd();

        Categories = JsonSerializer.Deserialize<List<Category>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
    }

    async Task LoadPatternsFromFile()
    {
        using Stream stream = await FileSystem.OpenAppPackageFileAsync("patterns.json");

        using StreamReader streamReader = new StreamReader(stream);

        var content = streamReader.ReadToEnd();

        Patterns = JsonSerializer.Deserialize<List<Pattern>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
    }
    
    public async Task<List<Category>> GetCategoriesAsync()
    {
        await LoadIfEmpty();
        return Categories;
    }

    public async Task<Category> GetCategoryAsync(int categoryId)
    {
        await LoadIfEmpty();
        return Categories.FirstOrDefault(x => x.Id == categoryId);
    }

    public async Task<List<Pattern>> GetCategoryPatternsAsync(int categoryId)
    {
        await LoadIfEmpty();
        return Patterns.Where(x => x.CategoryId == categoryId).ToList();
    }

    private async Task LoadIfEmpty()
    {

        if (IsEmpty(Categories))
            await LoadCategoriesFromJson();

        if (IsEmpty(Patterns))
            await LoadPatternsFromFile();
    }

    bool IsEmpty<T> (List<T> items) => (items).Count == 0;
}

