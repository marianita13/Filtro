using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;
using Persistence.Repository;

namespace Persistence.Repository;
public class ProductRepository : GenericRepository<Product> , IProduct
    {
        private readonly FiltroGardenContext _context;
        public ProductRepository(FiltroGardenContext context) : base(context)
        {
            _context = context;
        }
    }