using RevitAPI.Document;
using RevitAPI.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RevitAPI.Document;

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
            this.IsPinned = false;
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
            this.IsPinned = false;
            this.Parameters = new List<object>(); // Создаем пустой список параметров
        }


        public void PrintInfo()
        {
            Console.WriteLine($"--- Стена ID: {this.Id} ---");
            Console.WriteLine($"Тип стены: '{this.Type.Name}' (Толщина: {this.Type.Width} м)");
            Console.WriteLine($"Длина стены: {this.Location.Curve.Length:F2} м");
            Console.WriteLine($"Начальная точка: ({this.Location.Curve.StartPoint.X}, {this.Location.Curve.StartPoint.Y})");
        }
    }

    public class Wall2 : HostObject2
    {
        //       From abstract class HostObject2 -> Element2
        //public ElementId? Id { get; protected set; }
        //public string Name { get; set; }
        //public List<object> Parameters { get; private set; }
        //public bool IsPinned { get; set; }

        // Свойства-объекты (композиция)
        public WallType Type { get; private set; }
        public LocationCurve Location { get; private set; }



        // Конструктор, который "собирает" стену из готовых деталей
        public Wall2(ElementId id, WallType wallType, LocationCurve location, string name)
            : base(id, name)
        {
            // Проверяем, что нам не передали пустые детали
            if (wallType == null || location == null)
            {
                throw new ArgumentNullException("Тип и расположение стены не могут быть null.");
            }

            // Присваиваем свойства
            this.Type = wallType;
            this.Location = location;

            // Инициализируем другие свойства
            IsPinned = false;
            Parameters = new List<object>(); // Создаем пустой список параметров
        }

        public void PrintInfo()
        {
            Console.WriteLine($"--- Стена ID: {this.Id} ---");
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
