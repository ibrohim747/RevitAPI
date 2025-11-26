using RevitAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI.Elements
{
    public abstract class Element : IElement
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public object Document { get; protected set; }
        public object Category { get; protected set; }
        public object Parameters { get; protected set; }
        public object Location { get; set; }

        protected Element(int id, string name, object document, object category)
        {
            Id = id;
            Name = name;
            Document = document;
            Category = category;
            // Инициализация параметров и местоположения
        }

        public void Delete()
        {
            // Логика удаления элемента
        }

        public void Pin()
        {
            // Логика закрепления элемента
        }

        public void Unpin()
        {
            // Логика открепления элемента
        }
    }
}
