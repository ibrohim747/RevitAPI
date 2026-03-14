using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI
{
    // В Revit API это структура для эффективности. Мы последуем этому примеру.
    public struct ElementId : IEquatable<ElementId>
    {
        // --- 1. Основное хранилище ---
        // Внутри это простое число. Оно приватное, чтобы никто не мог изменить его извне.
        private readonly int _value;

        // --- 2. Публичное свойство для доступа (только для чтения) ---
        // В реальном Revit API это свойство называется .IntegerValue
        public int Value => _value;

        // --- 3. Специальное значение для "невалидного" или "нулевого" ID ---
        // Это статическое поле, доступное всем. Удобнее, чем использовать магическое число -1.
        public static readonly ElementId InvalidElementId = new ElementId(-1);

        // --- 4. Конструктор ---
        // Единственный способ создать ElementId - передать в него число.
        public ElementId(int value)
        {
            _value = value;
        }

        // --- 5. Методы для сравнения и работы в коллекциях (ОЧЕНЬ ВАЖНО) ---

        // Позволяет сравнивать два ElementId: id1.Equals(id2)
        public bool Equals(ElementId other)
        {
            return this._value == other._value;
        }

        public void toString()
        {
            _value.ToString();
        }

        // Стандартный метод Equals для сравнения с любым объектом
        public override bool Equals(object obj)
        {
            return obj is ElementId other && Equals(other);
        }

        // Обязателен при переопределении Equals. Нужен для хэш-таблиц (Dictionary, HashSet).
        public override int GetHashCode()
        {
            return _value;
        }

        // --- 6. Перегрузка операторов для удобства ---
        // Позволяет писать код `if (id1 == id2)` вместо `if (id1.Equals(id2))`
        public static bool operator ==(ElementId a, ElementId b)
        {
            return a.Equals(b);
        }

        // Позволяет писать код `if (id1 != id2)`
        public static bool operator !=(ElementId a, ElementId b)
        {
            return !a.Equals(b);
        }

        // --- 7. Удобное представление в виде строки для отладки ---
        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
