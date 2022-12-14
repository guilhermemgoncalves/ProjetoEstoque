using Estoque.Application.Messages;

namespace Estoque.Application.Interfaces;

public interface IProductsService
{
    Task ActivateAll();
    Task<CreateProductResponse> CreateTool(CreateProductRequest request);
    Task<UpdateProductResponse> DeleteTool(Guid id);
    Task<GetProductByIDResponse> GetToolById(Guid Id);
    Task<GetProductResponse> GetTools(string productStatus);
    Task<UpdateProductResponse> UpdateTool(UpdateProductRequest request);
    Task<string> ReadCSV<T>(Stream file);
}
