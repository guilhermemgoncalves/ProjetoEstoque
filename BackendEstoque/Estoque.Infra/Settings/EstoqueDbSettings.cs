using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Infra.Settings
{
    public class EstoqueDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ToolCollectionName { get; set; } = null!;
        public string OrderCollectionName { get; set; } = null!;
    }
}
