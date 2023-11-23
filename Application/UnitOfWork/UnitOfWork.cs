using System;
using Domain.Interfaces;
using iText.Commons.Actions.Contexts;
using Persistence.Data;
using Persistence.Repository;

namespace Persistence.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly FiltroGardenContext _context;

    public UnitOfWork(FiltroGardenContext context)
    {
        _context = context;
    }

    private ICity _city;
    private IClient _Client;
    private ICountry _Country;
    private IEmployee _Employee;
    private IMethodPayment _MethodPayment;
    private IOffice _Office;
    private IOrder _Order;
    private IOrderDetail _OrderDetail;
    private IPayment _Payment;
    private IPerson _Person;
    private IPersonType _PersonType;
    private IPostalCode _PosIPostalCode;
    private IProduct _Product;
    private IProductLine _ProdIProductLine;
    private IState _State;
    private IStatus _Status;
    private ISupplier _Supplier;

    public ICity Cities {
        get {
            if (_city == null) {
                _city = new CityRepository(_context);
            }
            return _city;
        }
    }

    public IClient Clients {
        get {
            if (_Client == null) {
                _Client = new ClientRepository(_context);
            }
            return _Client;
        }
    }

    public IEmployee Employees {
        get {
            if (_Employee == null) {
                _Employee = new EmployeeRepository(_context);
            }
            return _Employee;
        }
    }
    public IMethodPayment MethodPayments {
        get {
            if (_MethodPayment == null) {
                _MethodPayment = new MethodPaymentRepository(_context);
            }
            return _MethodPayment;
        }
    }

    public IPostalCode PostalCodes {
        get {
            if (_PosIPostalCode == null) {
                _PosIPostalCode = new PostalCodeRepository(_context);
            }
            return _PosIPostalCode;
        }
    }

    public IOffice Offices{
        get {
            if (_Office == null) {
                _Office = new OfficeRepository(_context);
            }
            return _Office;
        }
    }
    public IOrder Orders {
        get {
            if (_Order == null) {
                _Order = new OrderRepository(_context);
            }
            return _Order;
        }
    }
    public IOrderDetail OrderDetails {
        get {
            if (_OrderDetail == null) {
                _OrderDetail = new OrderDetailRepository(_context);
            }
            return _OrderDetail;
        }
    }

    public IPayment Payments{
        get {
            if (_Payment == null) {
                _Payment = new PaymentRepository(_context);
            }
            return _Payment;
        }
    }

    public IPerson Persons {
        get {
            if (_Person == null) {
                _Person = new PersonRepository(_context);
            }
            return _Person;
        }
    }

    public IPersonType PersonTypes {
        get {
            if (_PersonType == null) {
                _PersonType = new PersonTypeRepository(_context);
            }
            return _PersonType;
        }
    }

    public IProduct Products {
        get {
            if (_Product == null) {
                _Product = new ProductRepository(_context);
            }
            return _Product;
        }
    }

    public IProductLine ProductLines {
        get {
            if (_ProdIProductLine == null) {
                _ProdIProductLine = new ProductLineRepository(_context);
            }
            return _ProdIProductLine;
        }
    }
    public IState States {
        get {
            if (_State == null) {
                _State = new StateRepository(_context);
            }
            return _State;
        }
    }

    public IStatus Statuses {
        get {
            if (_Status == null) {
                _Status = new StatusRepository(_context);
            }
            return _Status;
        }
    }

    public ISupplier Suppliers{
        get {
            if (_Supplier == null) {
                _Supplier = new SupplierRepository(_context);
            }
            return _Supplier;
        }
    }

    public ICountry Countries{
        get {
            if (_Country == null) {
                _Country = new CountryRepository(_context);
            }
            return _Country;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}

