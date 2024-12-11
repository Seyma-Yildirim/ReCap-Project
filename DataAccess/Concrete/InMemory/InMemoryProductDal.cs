using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Entities.Concrete.Cars;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal
    {
        //GetById, GetAll, Add, Update, Delete
        List<Car> _cars;
        public InMemoryProductDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1, ColorId=1, DailyPrice=1 , Description="",ModelYear=2008},
                new Car{CarId=2,BrandId=1, ColorId=2, DailyPrice=2 , Description="",ModelYear=2006},
                new Car{CarId=3,BrandId=1, ColorId=3, DailyPrice=3 , Description="",ModelYear=2004}
            };
        }
        public List<Car>GetById(int id)
        {
            return _cars.Where(c=>c.CarId==id).ToList();
            
        }
        public void GetAll()
        {
            foreach (Car car in _cars)
            {
                Console.WriteLine(car);
            }
        }
        public void Add(Car car) 
        {
            _cars.Add(car);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId= car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear= car.ModelYear;
            carToUpdate.Description= car.Description;

        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);

        }


    }
}
