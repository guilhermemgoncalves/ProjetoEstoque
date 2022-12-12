using Estoque.Application.Messages;
using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Converters
{
    public class ConsumablesConverter
    {

        public Consumables ConvertToConsumables(ConsumablesCSV consumablesCsv )
        {
            Consumables consumables = new Consumables()
            {
                Brand =  consumablesCsv.Brand,
                Category = consumablesCsv.Category, 
                DateRegistry = DateTime.UtcNow,
                Description = consumablesCsv.Description,
                IsActive = true,
                Location = consumablesCsv.Location,
                Model = consumablesCsv.Model,
                Price = consumablesCsv.Price,
                Type = consumablesCsv.Type,
                LastUpdate = DateTime.UtcNow,
                Total = consumablesCsv.Total,

            };
            return consumables;
        }
    }
}
