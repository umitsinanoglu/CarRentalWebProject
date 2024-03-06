using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim başarıyla yüklendi");
        }

        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetList(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult("");
        }
        public IResult Delete(int carImageId)
        {
            var result = new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.id == carImageId));
            if (result == null)
            {
                return new ErrorResult(Messages.CarImageIdInvalid);
            }
            _carImageDal.Delete(result.Data);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<CarImage> GetByImageId(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.id == id), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetList()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetList().ToList());
        }
        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetList(c => c.CarId == carId).ToList(), Messages.CarImagesListed);
        }

    }
}
