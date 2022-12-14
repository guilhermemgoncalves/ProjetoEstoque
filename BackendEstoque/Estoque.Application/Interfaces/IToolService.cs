using Estoque.Application.Messages;
using Estoque.Domain.Entities;

namespace Estoque.Application.Interfaces;

public interface IToolService
{
    Task<GetProductResponse> GetTools(string toolStatus);
    Task<CreateProductResponse> CreateTool(CreateProductRequest request);
    Task<GetProductByIDResponse> GetToolById(Guid id);
    Task<UpdateProductResponse> UpdateTool(UpdateProductRequest request);
    Task<UpdateProductResponse> DeleteTool(Guid id);
    Task ActivateAll();
}
