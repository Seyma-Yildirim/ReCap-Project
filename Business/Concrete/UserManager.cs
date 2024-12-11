using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Business.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
           _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
           return new SuccessDataResult<List<User>>(_userDal.GetAll(),true,Messages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id == id));
        }

        public IDataResult<User> GetByMail(string email)
        {
           return new SuccessDataResult<User>(_userDal.Get(u=>u.Email==email),true,Messages.UserListed);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
           return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user),true,Messages.UserClaimsListed);
        }

        public IResult Update(User user)
        {
           _userDal.Update(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        

    }
}
