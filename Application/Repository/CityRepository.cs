using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;
using Persistence.Repository;

namespace Persistence.Repository;
public class CityRepository : GenericRepository<City> , ICity
    {
        private readonly FiltroGardenContext _context;
        public CityRepository(FiltroGardenContext context) : base(context)
        {
            _context = context;
        }
    }