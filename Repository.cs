// Repository.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameAssistant
{
    // Клас реалізує інтерфейс IRepository<T>.
    public class Repository<T> : IRepository<T> where T : class
    {
        private List<T> _items = new List<T>();

        // Додає елемент до репозиторію.
        public void Add(T item)
        {
            _items.Add(item);
        }

        // Видаляє елемент з репозиторію.
        public void Remove(T item)
        {
            _items.Remove(item);
        }

        // Отримує елемент за ID.
        public T GetById(int id)
        {
            var item = _items.FirstOrDefault(i => (int)i.GetType().GetProperty("Id").GetValue(i) == id);
            return item;
        }

        // Отримує всі елементи з репозиторію.
        public IEnumerable<T> GetAll()
        {
            return _items;
        }

        // Оновлює елемент у репозиторії.
        public void Update(T item)
        {
            var existingItem = _items.FirstOrDefault(i => i == item);
            if (existingItem != null)
            {
                _items[_items.IndexOf(existingItem)] = item;
            }
        }

        // Сортує елементи за вказаним ключем.
        public IEnumerable<T> SortBy(Func<T, object> keySelector)
        {
            return _items.OrderBy(keySelector).ToList();
        }

        // Сортує елементи за користувацьким компаратором.
        public IEnumerable<T> SortByCustom(Func<T, T, int> comparer)
        {
            List<T> sortedList = new List<T>(_items);
            sortedList.Sort((a, b) => comparer(a, b));
            return sortedList;
        }

        // Відображає поточний стан репозиторію.
        public void ShowRepositoryState()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}