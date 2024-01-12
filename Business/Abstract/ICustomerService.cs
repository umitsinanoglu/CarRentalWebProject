using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(int CustomerId);
        IResult Update(Customer customer);
        IDataResult<List<Customer>> GetList();
        IDataResult<Customer> GetById(int id);
    }
}
