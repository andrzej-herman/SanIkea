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

        public IEnumerable<Furniture> GetFurnitureByCategory(string category)
        {
            return Furnitures.Where(f => f.Category.ToLower().Contains(category.ToLower()));
        }

        public IEnumerable<Furniture> GetFurnitureByName(string name)
        {
            return Furnitures.Where(f => f.Name.ToLower().Contains(name.ToLower()));   
        }

        public IEnumerable<Furniture> GetFurnitureByPrice(decimal minprice, decimal maxprice)
        {
            return Furnitures.Where(f => f.Price >= minprice && f.Price <= maxprice);
        }

        public IEnumerable<Furniture> GetPromotedFurniture()
        {
            var furnitures = Furnitures.OrderBy(f => Random.Next());  
            return furnitures.Take(6);
        }
    }
}
