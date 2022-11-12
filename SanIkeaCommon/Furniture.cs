using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanIkeaCommon
{
    public class Furniture
    {
        public string Id { get; set; }
        public string Name{ get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> Images { get; set; }
        public string Description { get; set; }

    }
}
