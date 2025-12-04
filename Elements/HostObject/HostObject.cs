using RevitAPI.Document;
using RevitAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI.Elements.HostObject
{
    public abstract class HostObject : Element
    {
        // Свойства, специфичные для HostObject
        public List<IElement> FindInserts()
        {
            // Логика поиска вставленных элементов
            return new List<IElement>();
        }

        protected HostObject(int id, string name, object document, object category)
            : base(id, name, document, category)
        {
        }
    }

    public abstract class HostObject2 : Element2
    {
        //       From abstract class Element2
        //public ElementId? Id { get; protected set; }
        //public string Name { get; set; }
        //public List<object> Parameters { get; private set; }
        //public bool IsPinned { get; set; }

        protected HostObject2(ElementId id, string name)
            : base(id, name)
        {
        }

    }
}
