using DesignPatterns.Models;

namespace DesignPatterns.Services;

public interface IDesignPatternsService
{
    Task<List<Category>> GetCategoriesAsync();
    Task<List<Pattern>> GetCategoryPatternsAsync(int categoryId);
    Task<Category> GetCategoryAsync(int categoryId);
    Task<Pattern> GetPatternAsync(int patternId);
}