using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;
using Persistence.Repository;

namespace Persistence.Repository;
public class OfficeRepository : GenericRepository<Office> , IOffice
    {
        private readonly FiltroGardenContext _context;
        public OfficeRepository(FiltroGardenContext context) : base(context)
        {
            _context = context;
        }
    }