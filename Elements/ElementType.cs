using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI.Elements
{
    public class ElementType : Element
    {
        public ElementType(int id, string name, object document, object category, Location location) : base(id, name, document, category, location)
        {
        }
    }
}
