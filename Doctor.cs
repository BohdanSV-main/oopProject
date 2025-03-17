// Doctor.cs
using System;

namespace GameAssistant
{
    // Клас Doctor успадковує Civilian і додає нову функціональність (метод HealPlayer).
    // Це приклад наслідування
    public class Doctor : Civilian
    {
        public Doctor() : base()
        {
            Role = "Лікар";
        }

        // Новий метод HealPlayer, який дозволяє лікарю лікувати гравців.
        public void HealPlayer(General_Props player)
        {
            if (!player.IsAlive)
            {
                player.IsAlive = true;
                Console.WriteLine($"Лікар врятував гравця {player.Role}!");
            }
            else
            {
                Console.WriteLine("Гравець уже живий, лікування не потрібне.");
            }
        }

        // Перевизначення методу PerformRoleAction для лікаря.
        public override void PerformRoleAction()
        {
            Console.WriteLine("Лікар може врятувати одного гравця за ніч.");
        }
    }
}