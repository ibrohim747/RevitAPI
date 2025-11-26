using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI.Elements.FamilyInstance
{
    public class FamilyInstance : Element
    {
        public object Symbol { get; set; }

        public FamilyInstance(int id, string name, object document, object category, object symbol)
            : base(id, name, document, category)
        {
            Symbol = symbol;
        }

        public void Rotate()
        {
            // Логика поворота экземпляра семейства
        }
    }
}
