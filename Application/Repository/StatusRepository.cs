using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repository;

namespace Persistence.Repository;
public class StatusRepository : GenericRepository<Status> , IStatus
    {
        private readonly FiltroGardenContext _context;
        public StatusRepository(FiltroGardenContext context) : base(context)
        {
            _context = context;
        }

    public async Task<object> ProductosSinOrden()
    {
        return await (from order in _context.Orders
            join client in _context.Clients on order.ClientId equals client.Id
            join Employee in _context.Employees on client.EmployeeId equals Employee.Id
            join Office in _context.Offices on Employee.OfficeId equals Office.Id
            join city in _context.Citys on Office.CityId equals city.Id
            join state in _context.States on city.StateId equals state.Id
            group order by state.Id into groupedOrders
            orderby groupedOrders.Count() descending
            select new
            {
                State = groupedOrders.Key,
                NumberOfOrders = groupedOrders.Count()
            }).ToListAsync();
    }
}