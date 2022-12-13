using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Messages.Costumers
{
    public class UploadImageCommand
    {
        public string Image { get; set; }
        public string Container { get; set; }
    }
}
