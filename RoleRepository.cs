// RoleRepository.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameAssistant
{
    // Клас RoleRepository успадковує Repository<string> і додає метод для отримання активних ролей.
    public class RoleRepository : Repository<string>
    {
        public IEnumerable<string> GetActiveRoles()
        {
            return GetAll().Where(r => r == "Шериф" || r == "Лікар" || r == "Мафія" || r == "Дон").ToList();
        }
    }
}