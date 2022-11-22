using Estoque.Application.Messages;
using Estoque.Domain.Entities;

namespace Estoque.Application.Interfaces
{
    public interface IToolService
    {
        Task<GetToolsResponse> GetTools();
        Task<CreateToolResponse> CreateTool(CreateToolRequest request);
        Task<GetToolByIDResponse> GetToolById(Guid Id);      
        Task<UpdateToolResponse> UpdateTool(UpdateToolRequest request);
        Task<UpdateToolResponse> DeleteTool(UpdateToolRequest request);
        Task ActivateAll();
    }
}
