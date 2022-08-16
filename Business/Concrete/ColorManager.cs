using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
         IColorDal _colorDal;

         public ColorManager(IColorDal colorDal)
         {
             _colorDal=colorDal;
         }
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed);
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IResult Update(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        public IDataResult<List<Color>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.Id == colorId));
        }
    }
}
