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
                //var data = toyDAO.ReadAllChild().Result;
                //var result = data
                //    .Include(x => x.Product)
                //    .Include(x => x.Product.ProductForPetType)
                //    .Where(x => x.Product.Price >= 0
                //                && x.Product.Price <= 99999
                //                && x.Product.ProductForPetType.Any(y => y.PetType.Name == "Thỏ"));

                //var result = data
                //    .Include(x => x.Product)
                //    .Include(x => x.Product.ProductForPetType);

                //foreach (var ele in data)
                //{
                //    Console.WriteLine(ele.Product.ProductForPetType.ToArray().Length);
                //}

                //foreach (var ele in result)
                //{
                //    Console.WriteLine(ele.Product.Name);
                //}

                //var tmp = new CutieshopContext().Product
                //    .Include(x => x.ProductForPetType)
                //    .ThenInclude(x => x.PetType)
                //    .Include(x => x.Accessory)
                //    .Include(x => x.Cage)
                //    .Include(x => x.Food)
                //    .Include(x => x.Toy)
                //    .ToArray()
                //    .Where(x => ProductEqualTypeNotNull(x, typeof(Food)))
                //    .ToArray();

                //var msgs = (new CutieshopContext().Product
                //        .Include(x => x.ProductForPetType)
                //        .ThenInclude(x => x.PetType)
                //        .Include(x => x.Accessory)
                //        .Include(x => x.Cage)
                //        .Include(x => x.Food)
                //        .Include(x => x.Toy)
                //        .ToArray()
                //        .Where(x => ProductEqualTypeNotNull(x, typeof(Food))
                //                    && x.Price <= 300000
                //                    && x.Price >= 100000
                //                    && x.ProductForPetType.Any(y => y.PetType.Name == "Mèo"))
                //        .Select(x => new { x.Name, Price = x.Price.ToString(), x.ProductId, x.ImgUrl, BtnText = "Đặt liền" })
                //        .ToArray())
                //    .Select(ele => (ele.Name, ele.Price, ele.ProductId, ele.ImgUrl, ele.BtnText))
                //    .ToArray();

                //Console.WriteLine(msgs.Length);

                //Console.WriteLine("Hello World!");

                var arr = new[]
                {
                    new
                    {
                        arr = new[] {1, 2, 3}
                    },
                    new
                    {
                        arr = new[] {1, 6}
                    }
                };

                var tmp = arr.SelectMany(x => x.arr).ToArray();
                var tmp2 = arr.Aggregate((a, b) => new {arr = a.arr.Concat(b.arr).ToArray()});
            }
        }

        private static bool ProductEqualTypeNotNull(Product o, Type t)
        {
            if (t == typeof(Toy) && o.Toy != null
                || t == typeof(Food) && o.Food != null
                || t == typeof(Cage) && o.Cage != null)
                return true;
            return t == typeof(Accessory) && o.Accessory != null;
        }
    }
}
