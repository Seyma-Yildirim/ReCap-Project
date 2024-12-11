using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Cars;
using Business.BusinessAspect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Entities.Concrete.DTOs;

namespace Business.Concrete
{
   
    public class CarManager : ICarService  
    {
        ICarDal _cardal;
        public CarManager(ICarDal carDal)
        {
            _cardal = carDal;

        }
        [SecuredOperation("Admin")]
        public IResult Add(Car car)
        {
            _cardal.Add(car);
            return new SuccessResult("Ürün eklendi");
        }

        public IResult Delete(Car car)
        {
            _cardal.Delete(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(), true, Messages.CarListed);

        }

        public IDataResult<Car> GetById(int id)
        {

            return new SuccessDataResult<Car>(_cardal.Get(c => c.CarId == id));
            //<List> kaldırdım çünkü sadece tek ürün dönecek
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetailByColorId(id).ToList());

        }

        public IResult Update(Car car)
        {
            _cardal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetailByBrandId(id).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetailByCarId(id).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetail().ToList());
        }
    }
}
