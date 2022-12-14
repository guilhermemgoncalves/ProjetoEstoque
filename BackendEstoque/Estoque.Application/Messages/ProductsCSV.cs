﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Messages
{
    public class ProductsCSV
    {
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Location { get; set; } = null!;
        public decimal Price { get; set; } 
        public int Total { get; set; }

    }
}