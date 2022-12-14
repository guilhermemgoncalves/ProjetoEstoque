using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Messages.Costumers
{
    public class UploadImageCommand
    {
        public string Image { get; set; } = null!;
        public string Container { get; set; } = null!;
        public string Prontuario { get; set; } = null!;
    }
}
