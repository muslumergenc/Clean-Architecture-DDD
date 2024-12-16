using DDDTest.Domain.Entities;
namespace DDDTest.Application.Interfaces;
public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product> GetByIdAsync(int id);
    Task<List<Product>> GetByCategoryIdAsync(int categoryId);
    Task<List<Product>> GetAllAsync();
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}