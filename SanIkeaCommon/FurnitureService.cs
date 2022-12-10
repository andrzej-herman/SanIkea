using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SanIkeaCommon
{
    public class FurnitureService : IFurnitureService
    {
        public FurnitureService()
        {
            GetFurnitures();
            Random = new Random();
        }

        private IEnumerable<Furniture> Furnitures { get; set; }
        private Random Random { get; set; }

        private void GetFurnitures()
        {
            var json = File.ReadAllText("wwwroot\\data\\sklep.json");
            Furnitures = JsonConvert.DeserializeObject<IEnumerable<Furniture>>(json);   
        }


        public IEnumerable<string> GetCategories()
        {
            return Furnitures.Select(f => f.Category).Distinct().OrderBy(c => c);
        }

        public IEnumerable<SimpleFurniture> GetFurnitureByCategory(string category)
        {
            return Furnitures.Where(f => f.Category.ToLower().Contains(category.ToLower())).Select(f => Map(f));
        }

        public IEnumerable<SimpleFurniture> GetFurnitureByName(string name)
        {
            return Furnitures.Where(f => f.Name.ToLower().Contains(name.ToLower())).Select(f => Map(f));   
        }

        public IEnumerable<SimpleFurniture> GetFurnitureByPrice(decimal minprice, decimal maxprice)
        {
            return Furnitures.Where(f => f.Price >= minprice && f.Price <= maxprice).Select(f => Map(f));
        }

        public IEnumerable<SimpleFurniture> GetPromotedFurniture()
        {
            var furnitures = Furnitures.OrderBy(f => Random.Next());  
            return furnitures.Take(6).Select(f => Map(f));
        }

        private SimpleFurniture Map(Furniture furniture)
        {
            return new SimpleFurniture
            {
                Id = furniture.Id,
                Name = furniture.Name,
                Category= furniture.Category,
                Price = furniture.Price,
                FrontImage = furniture.Images.First()
            };
        }
    }
}
