// PlayerRepository.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameAssistant
{
    // Клас PlayerRepository успадковує Repository<General_Props> і додає метод для отримання живих гравців.
    public class PlayerRepository : Repository<General_Props>
    {
        public IEnumerable<General_Props> GetAlivePlayers()
        {
            return GetAll().Where(p => p.IsAlive).ToList();
        }
    }
}