using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI.Document
{
    public class RevitDocumentSimulator
    {
        private int _nextAvailableId = 100000; // Начинаем с большого числа для реалистичности

        // Словарь для хранения всех "элементов" в нашем проекте
        private Dictionary<ElementId, object> _elements = new Dictionary<ElementId, object>();

        /// <summary>
        /// Единственный правильный способ создать новый уникальный ElementId.
        /// </summary>
        /// <returns>Новый, гарантированно уникальный ElementId.</returns>
        public ElementId CreateNewElementId()
        {
            int newId = _nextAvailableId;
            _nextAvailableId++; // Увеличиваем счетчик для следующего вызова
            return new ElementId(newId);
        }

        // Метод для добавления "элементов" в нашу "базу данных"
        public void AddElement(object element, ElementId id)
        {
            if (!_elements.ContainsKey(id))
            {
                _elements.Add(id, element);
            }
        }
    }
}
