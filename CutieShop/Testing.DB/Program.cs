using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testing.DB.DAOs;
using Testing.DB.Entities;
using Testing.DB.FacebookRichMessages;

namespace Testing.DB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var toyDAO = new ToyDAO())
            {
                var data = toyDAO.ReadAllChild().Result;
                //var result = data
                //    .Include(x => x.Product)
                //    .Include(x => x.Product.ProductForPetType)
                //    .Where(x => x.Product.Price >= 0
                //                && x.Product.Price <= 99999
                //                && x.Product.ProductForPetType.Any(y => y.PetType.Name == "Thỏ"));

                var result = data
                    .Include(x => x.Product)
                    .Include(x => x.Product.ProductForPetType);

                //foreach (var ele in data)
                //{
                //    Console.WriteLine(ele.Product.ProductForPetType.ToArray().Length);
                //}

                foreach (var ele in result)
                {
                    Console.WriteLine(ele.Product.Name);
                }

                Console.WriteLine("Hello World!");
            }
        }
    }
}
