using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanIkeaCommon
{
    public interface IFurnitureService
    {
        IEnumerable<SimpleFurniture> GetPromotedFurniture();
        IEnumerable<SimpleFurniture> GetFurnitureByName(string name);
        IEnumerable<SimpleFurniture> GetFurnitureByCategory(string category);
        IEnumerable<SimpleFurniture> GetFurnitureByPrice(decimal minprice, decimal maxprice);
        IEnumerable<string> GetCategories();
    }
}
