using Azure.Storage.Blobs;
using Estoque.Application.Interfaces;
using Estoque.Domain.Entities;
using Estoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Estoque.Application.Services
{
    public class CostumerService : ICostumerService
    {
        private readonly ICostumerRepository _costumerRepository;
        public CostumerService(ICostumerRepository costumerRepository)
        {
            _costumerRepository = costumerRepository;
        }

        public async Task<bool> CreateCostumer(Costumer costumer)
        {
            await _costumerRepository.CreateAsync(costumer);

            return true;
        }

        public async Task<List<Costumer>> GetAll()
        {
            return await _costumerRepository.GetAsync();
        }

        public async Task<Costumer> GetById(string prontuario)
        {
            return await _costumerRepository.GetByIdAsync(prontuario);
        }

        public Task<string> UploadBase64Image(string base64Image, string container, string prontuario)
        {
            var fileName = Guid.NewGuid().ToString()+".jpg";
            Console.WriteLine("id: "+prontuario);

            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            byte[] imageBytes = Convert.FromBase64String(data);

            var blobCliente = new BlobClient("DefaultEndpointsProtocol=https;AccountName=estoqueferramenta;AccountKey=8DMh3cWIGAi+mINmIidIGfpqiFy3pgJgNhMx1S2JT/HuvVOHU+cn2J+iZwL/dSVpoqTMWTE+12N7+AStfRPHRA==;EndpointSuffix=core.windows.net", container, fileName);

            using (var stream = new MemoryStream(imageBytes))
            {
                blobCliente.Upload(stream);
            }
            return Task.FromResult(blobCliente.Uri.AbsoluteUri);
        }
    }
}
