using RevitAPI.Document;
using RevitAPI.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RevitAPI.Elements.HostObject
{
    public class Wall : HostObject
    {
        // Свойства-значения
        public ElementId EId { get; private set; }

        // Свойства-объекты (композиция)
        public WallType Type { get; private set; }
        public LocationCurve Location { get; private set; }
        public List<object> Parameters { get; private set; } // Просто для примера


        public static RevitDocumentSimulator doc = new RevitDocumentSimulator();
        ElementId wallId = doc.CreateNewElementId();

        // Конструктор, который "собирает" стену из готовых деталей
        public Wall(ElementId Eid, WallType wallType, LocationCurve location, int id, string name, object document, object category)
            : base(id, name, document, category)
        {
            // Проверяем, что нам не передали пустые детали
            if (wallType == null || location == null)
            {
                throw new ArgumentNullException("Тип и расположение стены не могут быть null.");
            }

            // Присваиваем свойства
            this.EId = Eid;
            this.Type = wallType;
            this.Location = location;

            // Инициализируем другие свойства
            this.Pinned = false;
            this.Parameters = new List<object>(); // Создаем пустой список параметров
        }

        public Wall(WallType wallType, LocationCurve location, int id, string name, object document, object category)
            : base(id, name, document, category)
        {
            // Проверяем, что нам не передали пустые детали
            if (wallType == null || location == null)
            {
                throw new ArgumentNullException("Тип и расположение стены не могут быть null.");
            }
            
            // Присваиваем свойства
            this.EId = wallId;
            this.Type = wallType;
            this.Location = location;

            // Инициализируем другие свойства
            this.Pinned = false;
            this.Parameters = new List<object>(); // Создаем пустой список параметров
        }


        public void PrintInfo()
        {
            Console.WriteLine($"--- Стена ID: {this.EId} ---");
            Console.WriteLine($"Тип стены: '{this.Type.Name}' (Толщина: {this.Type.Width} м)");
            Console.WriteLine($"Длина стены: {this.Location.Curve.Length:F2} м");
            Console.WriteLine($"Начальная точка: ({this.Location.Curve.StartPoint.X}, {this.Location.Curve.StartPoint.Y})");
        }
    }

    public class WallType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Width { get; set; } // Толщина стены

        public WallType(int id, string name, double width)
        {
            Id = id; Name = name; Width = width;
        }
    }
}
