using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Delete(int id);
        IResult Update(IFormFile file, CarImage carImage);
        IDataResult<List<CarImage>> GetList();
        IDataResult<CarImage> GetByImageId(int id);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}
