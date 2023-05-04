using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
       => new() 
       {
         new Product
         {
             Id = Guid.NewGuid(),
             CreatedDate= DateTime.Now, 
             Name = "P1",
             Price = 199,
             Stock = 19
         },  
         new Product
         {
             Id = Guid.NewGuid(),
             CreatedDate= DateTime.Now, 
             Name = "P2",
             Price = 299,
             Stock = 19
         }  , new Product
         {
             Id = Guid.NewGuid(),
             CreatedDate= DateTime.Now, 
             Name = "P3",
             Price = 159,
             Stock = 11
         },   new Product
         {
             Id = Guid.NewGuid(),
             CreatedDate= DateTime.Now, 
             Name = "P4",
             Price = 119,
             Stock = 1
         } ,  new Product
         {
             Id = Guid.NewGuid(),
             CreatedDate= DateTime.Now, 
             Name = "P5",
             Price = 109,
             Stock = 10
         }
         
       };
    }
}
