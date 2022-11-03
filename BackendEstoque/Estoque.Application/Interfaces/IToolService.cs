using Estoque.Application.Messages;
using Estoque.Domain.Entities;

namespace Estoque.Application.Interfaces
{
    public interface IToolService
    {
        Task<GetToolsResponse> GetTools();
        List<Tool> GetFakeRepository();
        bool TestService();
    }
}
