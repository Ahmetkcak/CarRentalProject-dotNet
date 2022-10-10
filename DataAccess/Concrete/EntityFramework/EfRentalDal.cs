using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using(CarRentalContext context = new CarRentalContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars on re.CarId equals ca.Id
                             join br in context.Brands on ca.BrandId equals br.Id
                             join cu in context.Customers on re.CustomerId equals cu.Id
                             join us in context.Users on cu.UserId equals us.Id
                             select new RentalDetailDto
                             {
                                 Id = re.Id,
                                 CarId = ca.Id,
                                 BrandName = br.BrandName,
                                 CustomerName = us.FirstName + " " + us.LastName,
                                 CustomerId = cu.Id,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
