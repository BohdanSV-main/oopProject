// GameMaster.cs
using System;
using System.Collections.Generic;

namespace GameAssistant
{
    // Клас GameMaster керує(буде) гравцями та їх діями.
    public class GameMaster
    {
        public List<General_Props> Players { get; private set; }

        public GameMaster()
        {
            Players = new List<General_Props>();
        }

        // Метод для додавання(буде) гравця до списку.
        public void AddPlayer(General_Props player)
        {
            Players.Add(player);
        }

        // Метод для позначення голосу гравця.
        public void MarkVote(General_Props player, string target)
        {
            player.VotedFor = target;
            Console.WriteLine($"{player.Role} проголосував за {target}");
        }

        // Метод для виставлення гравця на голосування.
        public void NominateForVoting(General_Props player)
        {
            player.IsNominated = true;
            Console.WriteLine($"{player.Role} виставлений на голосування!");
        }
    }
}