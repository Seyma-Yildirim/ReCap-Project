using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Users;
using Business.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {


            DateTime lastReturnDate = _rentalDal.Get(r => r.RentalId == rental.RentalId).ReturnDate;
            if (lastReturnDate <= DateTime.Now)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);

            }
            else
            {
                return new ErrorResult(Messages.RentalDeleted);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId == id));

        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailByCarId(int id)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailsByCarId(id).ToList());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
           return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails().ToList());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update (rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
