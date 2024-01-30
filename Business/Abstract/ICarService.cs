using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult DeleteByName(string ModelName);
        IResult DeleteById(int id);
        //IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetList();
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
        IDataResult<List<Car>> GetAllByBrand(int brandId);
        IDataResult<List<Car>> GetAllByColor(int colorId);
        IDataResult<List<Car>> GetAllByDailyPriceRange(decimal min, decimal max);

    }
}
