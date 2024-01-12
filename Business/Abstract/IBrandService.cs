using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Delete(string BrandName);
        IResult Update(Brand brand);
        IDataResult<List<Brand>> GetList();
        IDataResult<Brand> GetById(int id);
    }
}
