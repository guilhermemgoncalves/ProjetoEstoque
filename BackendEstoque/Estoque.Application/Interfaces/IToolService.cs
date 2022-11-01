using Estoque.Application.Messages;

namespace Estoque.Application.Interfaces
{
    public interface IToolService
    {
        Task<GetToolsResponse> GetTools();
    }
}
