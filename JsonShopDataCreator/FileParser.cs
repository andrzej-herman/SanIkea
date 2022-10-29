using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonShopDataCreator
{
    internal class FileParser
    {
        private readonly string path;

        public FileParser(string path)
        {
            this.path = path;
        }

        public List<Product> GetProducts()
        {
            Console.WriteLine();
            Console.WriteLine(" Rozpoczynam parsowanie pliku ...");
            var result = new List<Product>();
            var text = File.ReadAllText(path);
            var jsonProducts = JsonConvert.DeserializeObject<List<JsonProduct>>(text);
            foreach (var item in jsonProducts)
            {
                result.Add(CreateProduct(item));
            }

            Console.WriteLine($" Utworzono {result.Count} produktów ...");
            return result;
        }


        private Product CreateProduct(JsonProduct jp)
        {
            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = jp.name,
                Category = jp.category,
                Price = decimal.TryParse(jp.price, out var p) ? p : 12m,
                Description = jp.description,
            };

            if (!string.IsNullOrEmpty(jp.photo_1) && !string.IsNullOrWhiteSpace(jp.photo_1))
                product.Images.Add(jp.photo_1.Trim());

            if (!string.IsNullOrEmpty(jp.photo_2) && !string.IsNullOrWhiteSpace(jp.photo_2))
                product.Images.Add(jp.photo_2.Trim());

            if (!string.IsNullOrEmpty(jp.photo_3) && !string.IsNullOrWhiteSpace(jp.photo_3))
                product.Images.Add(jp.photo_3.Trim());

            return product;
        }
    }
}
