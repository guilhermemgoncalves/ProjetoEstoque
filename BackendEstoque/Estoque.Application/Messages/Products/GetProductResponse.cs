namespace Estoque.Application.Messages
{
    public class GetProductResponse
    {
        public List<BasicProduct> BasicToolResponse { get; set; } = new();
    }
}