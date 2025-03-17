// General_Props.cs
using System;

namespace GameAssistant
{
    // Абстрактний клас General_Props є базовим класом для всіх ролей у грі.
    // Це приклад абстрактного класу та динамічного поліморфізму (через перевизначення методів).
    public abstract class General_Props : IRoleAction
    {
        protected string votedFor;
        protected bool isNominated;
        protected bool isAlive;
        protected string role;

        public string VotedFor { get => votedFor; set => votedFor = value; }
        public bool IsNominated { get => isNominated; set => isNominated = value; }
        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public bool IsActiveRole => Role == "Шериф" || Role == "Лікар" || Role == "Мафія" || Role == "Дон";
        public string Role { get => role; set => role = value; }

        // Це приклад абстрактного методу та динамічного поліморфізму.
        public abstract void PerformRoleAction();

        // Це приклад віртуального методу та динамічного поліморфізму.
        public virtual void DisplayStatus()
        {
            Console.WriteLine($"Роль: {Role}, Живий: {IsAlive}, Виставлений: {IsNominated}, Голосував за: {VotedFor}");
        }
    }
}