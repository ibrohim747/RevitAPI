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
        object Document { get; }
        // Имитация категории
        object Category { get; }
        // Имитация коллекции параметров
        object Parameters { get; }
        // Имитация расположения
        object Location { get; set; }

        void Delete();
        void Pin();
        void Unpin();
    }
}
