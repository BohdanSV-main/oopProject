// IRepository.cs
using System;
using System.Collections.Generic;

namespace GameAssistant
{
    // Інтерфейс IRepository<T> визначає основні методи CRUD.
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T item);
    }
}