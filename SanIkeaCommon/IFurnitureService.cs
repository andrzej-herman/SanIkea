using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanIkeaCommon
{
    public interface IFurnitureService
    {
        IEnumerable<Furniture> GetPromotedFurniture();
        IEnumerable<Furniture> GetFurnitureByName(string name);
        IEnumerable<Furniture> GetFurnitureByCategory(string category);
        IEnumerable<Furniture> GetFurnitureByPrice(decimal minprice, decimal maxprice);
        IEnumerable<string> GetCategories();
    }
}
