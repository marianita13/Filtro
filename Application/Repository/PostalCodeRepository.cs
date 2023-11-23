using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;
using Persistence.Repository;

namespace Persistence.Repository;
public class PostalCodeRepository : GenericRepository<PostalCode> , IPostalCode
    {
        private readonly FiltroGardenContext _context;
        public PostalCodeRepository(FiltroGardenContext context) : base(context)
        {
            _context = context;
        }
    }