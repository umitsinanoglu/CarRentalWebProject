using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(string ColorName)
        {
            var result = new SuccessDataResult<Color>(_colorDal.Get(cl => cl.name == ColorName));
            if (result == null)
            {
                return new ErrorResult(Messages.ColorIdInvalid);
            }
            _colorDal.Delete(result.Data);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetList()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetList().ToList(), Messages.ColorsListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(cl => cl.id == id), Messages.ColorListed);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
