using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GameAssistant;

namespace GameAssistant
{
    // Інтерфейс IRoleAction визначає метод PerformRoleAction, який мають реалізувати всі класи, що його імплементують.
    // Це приклад інтерфейсу
    public interface IRoleAction
    {
        void PerformRoleAction();
    }

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

        // Це приклад **абстрактного методу** та **динамічного поліморфізму**.
        public abstract void PerformRoleAction();

        // Це приклад **віртуального методу** та **динамічного поліморфізму**.
        public virtual void DisplayStatus()
        {
            Console.WriteLine($"Роль: {Role}, Живий: {IsAlive}, Виставлений: {IsNominated}, Голосував за: {VotedFor}");
        }
    }

    // Клас Civilian успадковує General_Props і реалізує метод PerformRoleAction.
    // Це приклад **наслідування** та **динамічного поліморфізму**
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

    // Клас Doctor успадковує Civilian і додає нову функціональність (метод HealPlayer).
    // Це приклад **наслідування**
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

    // Це приклад інкапсуляції :)
    public partial class MainForm : Form
    {
        private GameMaster gameMaster;
        private DataGridView dgv;
        private Button btnVote;
        private Button btnNominate;
        private Button btnHeal;

        public MainForm()
        {
            InitializeComponent();
            gameMaster = new GameMaster();
            SetupUI();
        }

        // Метод для налаштування графічного інтерфейсу.
        private void SetupUI()
        {
            dgv = new DataGridView
            {
                Dock = DockStyle.Top,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = true,
                AllowUserToDeleteRows = true,
                Height = 200
            };

            dgv.Columns.Add("Number", "Номер");
            dgv.Columns.Add("Player", "Гравець");

            DataGridViewComboBoxColumn roleColumn = new DataGridViewComboBoxColumn
            {
                Name = "Role",
                HeaderText = "Роль",
                DataSource = new string[] { "Мирний", "Шериф", "Лікар", "Мафія", "Дон" }
            };
            dgv.Columns.Add(roleColumn);

            dgv.Columns.Add("Comment", "Коментар");
            dgv.Columns.Add("Votes", "Голоси");
            dgv.Columns.Add("Alive", "Живий");

            btnVote = new Button { Text = "Проголосувати", Dock = DockStyle.Bottom };
            btnVote.Click += BtnVote_Click;

            btnNominate = new Button { Text = "Виставити на голосування", Dock = DockStyle.Bottom };
            btnNominate.Click += BtnNominate_Click;

            btnHeal = new Button { Text = "Лікувати", Dock = DockStyle.Bottom };
            btnHeal.Click += BtnHeal_Click;

            Controls.Add(dgv);
            Controls.Add(btnVote);
            Controls.Add(btnNominate);
            Controls.Add(btnHeal);
        }


        private void UpdateAliveStatus()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Alive"].Value != null)
                {
                    row.Cells["Alive"].Value = "Так";
                }
            }
        }

        // Обробник події для кнопки "Проголосувати".
        private void BtnVote_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                string playerName = dgv.SelectedRows[0].Cells["Player"].Value.ToString();
                gameMaster.MarkVote(new Civilian(), playerName);
            }
        }

        // Обробник події для кнопки "Виставити на голосування".
        private void BtnNominate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                string playerName = dgv.SelectedRows[0].Cells["Player"].Value.ToString();
                gameMaster.NominateForVoting(new Civilian());
            }
        }

        // Обробник події для кнопки "Лікувати".
        private void BtnHeal_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                General_Props player = new Civilian();
                Doctor doctor = new Doctor();
                doctor.HealPlayer(player);
                UpdateAliveStatus();
            }
        }
    }
}

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