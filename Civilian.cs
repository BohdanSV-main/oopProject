// Civilian.cs
using System;

namespace GameAssistant
{
    // Клас Civilian успадковує General_Props і реалізує метод PerformRoleAction.
    // Це приклад наслідування та динамічного поліморфізму
    public class Civilian : General_Props
    {
        public Civilian()
        {
            Role = "Мирний";
            IsAlive = true;
            IsNominated = false;
            VotedFor = "";
        }

        // Перевизначення абстрактного методу PerformRoleAction.
        public override void PerformRoleAction()
        {
            Console.WriteLine("Мирний житель не має активної дії.");
        }
    }
}