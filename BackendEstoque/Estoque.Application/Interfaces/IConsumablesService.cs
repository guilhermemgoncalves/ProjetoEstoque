using Estoque.Application.Messages;

namespace Estoque.Application.Interfaces;

public interface IConsumablesService
{
    Task ActivateAll();
    Task<CreateToolResponse> CreateTool(CreateToolRequest request);
    Task<UpdateToolResponse> DeleteTool(Guid id);
    Task<GetToolByIDResponse> GetToolById(Guid Id);
    Task<GetToolsResponse> GetTools(string toolStatus);
    Task<UpdateToolResponse> UpdateTool(UpdateToolRequest request);
    Task<IEnumerable<T>> ReadCSV<T>(Stream file);
}
