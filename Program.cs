using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using RevitAPI.Document;
using RevitAPI.Geometry;
using RevitAPI.Elements.HostObject;
using RevitAPI;

namespace RevitAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WallType concreteWallType = new WallType(1, "Бетон 250мм", 0.25);

            XYZ startPoint = new XYZ(10, 5, 0);
            XYZ endPoint = new XYZ(25, 5, 0);

            // 3. На основе точек создаем объект-линию
            Line wallAxis = new Line(startPoint, endPoint);

            // 4. На основе линии создаем объект-расположение
            LocationCurve wallLocation = new LocationCurve(wallAxis);

            // 1. У нас есть "документ", который управляет всем.
            var doc = new RevitDocumentSimulator();

            // 2. Мы ПРОСИМ у документа создать для нас новый уникальный ID.
            ElementId wallId = doc.CreateNewElementId();
            Console.WriteLine($"Документ выдал новый ID для стены: {wallId.Value}");

            Object category = new Object();

            Wall myFirstWall = new Wall(wallId, concreteWallType, wallLocation, 4345, "First wall", doc, category);

            Wall mySecondWall = new Wall(concreteWallType, wallLocation, 4345, "Second wall", doc, category);
            Wall myThirdWall = new Wall(concreteWallType, wallLocation, 4345, "Third wall", doc, category);


            Console.WriteLine("First Wall");
            myFirstWall.PrintInfo();
            // 4. Добавляем стену в "базу данных" документа
            // doc.AddElement(myWall, wallId);
            Console.WriteLine(myFirstWall.EId.ToString());

            Console.WriteLine("Second Wall");
            mySecondWall.PrintInfo();
            Console.WriteLine(mySecondWall.EId.ToString());

            Console.WriteLine("Third Wall");
            myThirdWall.PrintInfo();
            Console.WriteLine(myThirdWall.EId.ToString());


            // Повторяем для двери
            ElementId doorId = doc.CreateNewElementId();
            Console.WriteLine($"Документ выдал новый ID для двери: {doorId.ToString()}");

            Console.ReadLine();
        }
    }
}
