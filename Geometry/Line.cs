using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI.Geometry
{
    public class Line
    {
        public XYZ StartPoint { get; set; }
        public XYZ EndPoint { get; set; }

        public double Length
        {
            get
            {
                // Просто для примера рассчитаем длину
                double dx = EndPoint.X - StartPoint.X;
                double dy = EndPoint.Y - StartPoint.Y;
                double dz = EndPoint.Z - StartPoint.Z;
                return Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }
        }

        public Line(XYZ start, XYZ end)
        {
            StartPoint = start;
            EndPoint = end;
        }
    }
}

