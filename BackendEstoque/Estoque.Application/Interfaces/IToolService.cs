using Estoque.Application.Messages;
using Estoque.Domain.Entities;

namespace Estoque.Application.Interfaces
{
    public interface IToolService
    {
        Task<GetToolsResponse> GetTools();
        Task<CreateToolResponse> CreateTool(CreateToolRequest request);
        public Task<GetToolByIDResponse> GetToolById(Guid Id);
        bool TestService();
        public Task UpdateTool(Guid Id);
      
    }
}
