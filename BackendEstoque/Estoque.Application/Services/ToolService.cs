using Estoque.Application.Interfaces;
using Estoque.Application.Messages;
using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Services
{
    public class ToolService : IToolService
    {
        public List<Tool> GetFakeRepository()
        {
            List<Tool> fakeRepository = new List<Tool>();
            var tool1 = new Tool()
            {
                Id = Guid.Parse("0a5c4372-ac05-4dc2-9acd-23bebb0779a9"), 
                Name = "Martelo bola",
                Category =  "Martelo",
                DateRegistry = DateTime.UtcNow,
                Description = "Martelo Bola, Cromo Vanadio, 2Kg",
                Price = 10.53,
                IsActive = true,
            };
           
            var tool2 = new Tool()
            {
                Id = Guid.Parse("5f8041ff-e74a-4c0d-ba20-32a65b65f67d"),
                Name = "Marreta",
                Category = "Martelo",
                DateRegistry = DateTime.UtcNow,
                Description = "Martelo Bola, Cromo Vanadio, 2Kg",
                Price = 10.53,
                IsActive= false,
            };
            fakeRepository.Add(tool1);
            fakeRepository.Add(tool2);
           
            return  fakeRepository;
        }

        public async Task<GetToolsResponse> GetTools()
        {
            var fakeRepository = GetFakeRepository();
            GetToolsResponse response = new GetToolsResponse();

            foreach (Tool tool in fakeRepository)
            {
                BasicToolResponse basicToolResponse = new BasicToolResponse()
                {
                    Id= tool.Id,
                    Name= tool.Name,
                    Category= tool.Category,
                    Description= tool.Description,
                    Price  = tool.Price,
                    Tags = tool.Tags,
                    IsActive = tool.IsActive
                };
                response.BasicToolResponse.Add(basicToolResponse);
            }
            return await Task.FromResult(response);
         }

        public bool TestService()
        {
            return false;
        }
    }
}
