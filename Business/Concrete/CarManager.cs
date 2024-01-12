using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Maintenance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    [MaintenanceAspect(14)]
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal cardal)
        {
            _carDal = cardal;
        }
        public IDataResult<List<Car>> GetList()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetList().ToList());
        }

        [ValidationAspect(typeof(CarValidator), Priority = 1)]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarModelNameExists(car.ModelName));

            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        private IResult CheckIfCarModelNameExists(string modelName)
        {
            var result = _carDal.GetList(c => c.ModelName == modelName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }

            return new SuccessResult();
        }
        public IDataResult<List<Car>> GetAllByDailyPriceRange(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.DailyPrice >= min && c.DailyPrice <= max).ToList(), Messages.CarsListed);

        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var result = new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.BrandId == brandId).ToList());

            if (result == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.BrandIdInvalid);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.BrandId == brandId).ToList(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var result = new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.ColorId == colorId).ToList());

            if (result == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.ColorIdInvalid);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.ColorId == colorId).ToList(), Messages.CarsListed);
        }


        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }


        public IResult DeleteById(int id)
        {
            var result = new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));

            if (result == null)
            {
                return new ErrorResult(Messages.CarIdInvalid);

            }
            _carDal.Delete(result.Data);
            return new SuccessResult(Messages.CarDeleted);

        }

        public IResult DeleteByName(string ModelName)
        {
            var result = new SuccessDataResult<Car>(_carDal.Get(c => c.ModelName == ModelName));
            if (result == null)
            {
                return new ErrorResult(Messages.ModelNameInvalid);
            }
            _carDal.Delete(result.Data);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByBrand(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.BrandId == brandId).ToList());
        }

        public IDataResult<List<Car>> GetAllByColor(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetList(c => c.ColorId == colorId).ToList());
        }


    }
}
