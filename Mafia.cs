// Mafia.cs
using System;

namespace GameAssistant
{
    // Клас Mafia успадковує General_Props і реалізує метод PerformRoleAction.
    public class Mafia : General_Props
    {
        public bool IsMafia { get; private set; }

        public Mafia()
        {
            Role = "Мафія";
            IsAlive = true;
            IsNominated = false;
            VotedFor = "";
            IsMafia = true;
        }

        // Статичний поліморфізм (перевантаження методу KillPlayer)
        public void KillPlayer(General_Props player)
        {
            if (player.IsAlive)
            {
                player.IsAlive = false;
                Console.WriteLine($"Мафія вбила гравця {player.Role}!");
            }
            else
            {
                Console.WriteLine("Гравець уже мертвий.");
            }
        }

        public void KillPlayer(General_Props player, string reason)
        {
            if (player.IsAlive)
            {
                player.IsAlive = false;
                Console.WriteLine($"Мафія вбила гравця {player.Role}! Причина: {reason}");
            }
            else
            {
                Console.WriteLine("Гравець уже мертвий.");
            }
        }

        // Статичний поліморфізм (перевантаження методу LeaveComment)
        public void LeaveComment(string comment)
        {
            Console.WriteLine($"Мафія залишила коментар: {comment}");
        }

        public void LeaveComment(General_Props player, string comment)
        {
            Console.WriteLine($"Мафія залишила коментар про {player.Role}: {comment}");
        }

        public override void PerformRoleAction()
        {
            Console.WriteLine("Мафія може вбити одного гравця за ніч.");
        }
    }
}