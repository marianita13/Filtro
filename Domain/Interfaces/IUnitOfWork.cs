using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICity Cities {get;}
        IClient Clients {get;}
        ICountry Countries {get;}
        IEmployee Employees {get;}
        IMethodPayment MethodPayments {get;}
        IOffice Offices {get;}
        IOrder Orders {get;}
        IOrderDetail OrderDetails {get;}
        IPayment Payments {get;}
        IPerson Persons {get;}
        IPersonType PersonTypes {get;}
        IProduct Products {get;}
        IProductLine ProductLines {get;}
        IState States {get;}
        IStatus Statuses {get;}
        ISupplier Suppliers {get;}
        Task<int> SaveAsync();
    }
}