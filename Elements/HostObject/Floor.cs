using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI.Elements.HostObject
{
    public class Floor : HostObject
    {
        public double Thickness { get; set; }

        public Floor(int id, string name, object document, object category, double thickness)
            : base(id, name, document, category)
        {
            Thickness = thickness;
        }
    }
}
