using RevitAPI;
using RevitAPI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI.Interfaces
{
    public interface IElement
    {
        int Id { get; }
        string Name { get; set; }
        // Имитация ссылки на документ
        Document Document { get; }
        // Имитация категории
        Category Category { get; }
        // Имитация коллекции параметров
        ParameterSet Parameters { get; }
        // Имитация расположения
        Location Location { get; set; }
        bool Pinned { get; set; }
    }
}
