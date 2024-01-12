using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(int RentalId);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetList();
        IDataResult<Rental> GetById(int id);
    }
}
