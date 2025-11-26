using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI.Geometry
{
    public class LocationCurve
    {
        public Line Curve { get; set; }

        public LocationCurve(Line curve)
        {
            Curve = curve;
        }
    }
}

