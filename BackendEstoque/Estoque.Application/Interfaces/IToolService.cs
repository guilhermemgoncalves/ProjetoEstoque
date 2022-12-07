using Estoque.Application.Messages;
using Estoque.Domain.Entities;

namespace Estoque.Application.Interfaces;

public interface IToolService
{
    Task<GetToolsResponse> GetTools(string toolStatus);
    Task<CreateToolResponse> CreateTool(CreateToolRequest request);
    Task<GetToolByIDResponse> GetToolById(Guid id);
    Task<UpdateToolResponse> UpdateTool(UpdateToolRequest request);
    Task<UpdateToolResponse> DeleteTool(Guid id);
    Task ActivateAll();
}
