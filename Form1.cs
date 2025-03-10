using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GameAssistant;
using System.Linq;

namespace GameAssistant
{
    // Інтерфейс IRoleAction визначає метод PerformRoleAction, який мають реалізувати всі класи, що його імплементують.
    public interface IRoleAction
    {
        void PerformRoleAction();
    }

    // Абстрактний клас General_Props є базовим класом для всіх ролей у грі.
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

        // Абстрактний метод, який мають реалізувати всі похідні класи.
        public abstract void PerformRoleAction();

        // Віртуальний метод для відображення статусу гравця.
        public virtual void DisplayStatus()
        {
            Console.WriteLine($"Роль: {Role}, Живий: {IsAlive}, Виставлений: {IsNominated}, Голосував за: {VotedFor}");
        }
    }

    // Клас Civilian успадковує General_Props і реалізує метод PerformRoleAction.
    public class Civilian : General_Props
    {
        public Civilian()
        {
            Role = "Мирний";
            IsAlive = true;
            IsNominated = false;
            VotedFor = "";
        }

        // Реалізація методу PerformRoleAction для мирного жителя.
        public override void PerformRoleAction()
        {
            Console.WriteLine("Мирний житель не має активної дії.");
        }
    }

    // Клас Doctor успадковує Civilian і додає нову функціональність (метод HealPlayer).
    public class Doctor : Civilian
    {
        public Doctor() : base()
        {
            Role = "Лікар";
        }

        // Метод для лікування гравця.
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

        // Реалізація методу PerformRoleAction для лікаря.
        public override void PerformRoleAction()
        {
            Console.WriteLine("Лікар може врятувати одного гравця за ніч.");
        }
    }

    // Клас GameMaster керує гравцями та їх діями.
    public class GameMaster
    {
        public List<General_Props> Players { get; private set; }

        public GameMaster()
        {
            Players = new List<General_Props>();
        }

        // Метод для додавання гравця до списку.
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

    // Інтерфейс IRepository<T> визначає основні методи CRUD.
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T item);
    }

    // Клас Repository<T> реалізує інтерфейс IRepository<T>.
    public class Repository<T> : IRepository<T> where T : class
    {
        private List<T> _items = new List<T>();

        // Додає елемент до репозиторію.
        public void Add(T item)
        {
            _items.Add(item);
            Console.WriteLine("Елемент додано до репозиторію.");
        }

        // Видаляє елемент з репозиторію.
        public void Remove(T item)
        {
            _items.Remove(item);
            Console.WriteLine("Елемент видалено з репозиторію.");
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
                Console.WriteLine("Елемент оновлено.");
            }
        }

        // Сортує елементи за вказаним ключем.
        public IEnumerable<T> SortBy(Func<T, object> keySelector)
        {
            return _items.OrderBy(keySelector).ToList();
        }

        // Відображає поточний стан репозиторію.
        public void ShowRepositoryState()
        {
            Console.WriteLine("Поточний стан репозиторію:");
            foreach (var item in _items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    // Клас PlayerRepository успадковує Repository<General_Props> і додає метод для отримання живих гравців.
    public class PlayerRepository : Repository<General_Props>
    {
        public IEnumerable<General_Props> GetAlivePlayers()
        {
            return GetAll().Where(p => p.IsAlive).ToList();
        }
    }

    // Клас RoleRepository успадковує Repository<string> і додає метод для отримання активних ролей.
    public class RoleRepository : Repository<string>
    {
        public IEnumerable<string> GetActiveRoles()
        {
            return GetAll().Where(r => r == "Шериф" || r == "Лікар" || r == "Мафія" || r == "Дон").ToList();
        }
    }

    // Головна форма програми.
    public partial class MainForm : Form
    {
        private GameMaster gameMaster;
        private PlayerRepository playerRepository;
        private RoleRepository roleRepository;
        private DataGridView dgv;
        private Button btnVote;
        private Button btnNominate;
        private Button btnHeal;
        private Button btnShowState;
        private Button btnSortByRole;

        public MainForm()
        {
            InitializeComponent();
            gameMaster = new GameMaster();
            playerRepository = new PlayerRepository();
            roleRepository = new RoleRepository();
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

            btnShowState = new Button { Text = "Показати стан репозиторію", Dock = DockStyle.Bottom };
            btnShowState.Click += BtnShowState_Click;

            btnSortByRole = new Button { Text = "Сортувати за ролями", Dock = DockStyle.Bottom };
            btnSortByRole.Click += BtnSortByRole_Click;

            Controls.Add(dgv);
            Controls.Add(btnVote);
            Controls.Add(btnNominate);
            Controls.Add(btnHeal);
            Controls.Add(btnShowState);
            Controls.Add(btnSortByRole);
        }

        // Оновлює статус "Живий" у таблиці.
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

        // Обробник події для кнопки "Показати стан репозиторію".
        private void BtnShowState_Click(object sender, EventArgs e)
        {
            // Оновлюємо дані в репозиторії з таблиці
            playerRepository = new PlayerRepository();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Player"].Value != null)
                {
                    string role = row.Cells["Role"].Value.ToString();
                    bool isAlive = row.Cells["Alive"].Value.ToString() == "Так";

                    General_Props player;
                    switch (role)
                    {
                        case "Лікар":
                            player = new Doctor();
                            break;
                        case "Мафія":
                            player = new Mafia();
                            break;
                        default:
                            player = new Civilian();
                            break;
                    }

                    player.Role = role;
                    player.IsAlive = isAlive;
                    player.IsNominated = false; // Додайте логіку для цього поля, якщо потрібно

                    playerRepository.Add(player);
                }
            }

            FormShowState formShowState = new FormShowState(playerRepository);
            formShowState.ShowDialog();
        }

        // Обробник події для кнопки "Сортувати за ролями".
        private void BtnSortByRole_Click(object sender, EventArgs e)
        {
            // Оновлюємо дані в репозиторії з таблиці
            playerRepository = new PlayerRepository();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Player"].Value != null)
                {
                    string role = row.Cells["Role"].Value.ToString();
                    bool isAlive = row.Cells["Alive"].Value.ToString() == "Так";

                    General_Props player;
                    switch (role)
                    {
                        case "Лікар":
                            player = new Doctor();
                            break;
                        case "Мафія":
                            player = new Mafia();
                            break;
                        default:
                            player = new Civilian();
                            break;
                    }

                    player.Role = role;
                    player.IsAlive = isAlive;
                    player.IsNominated = false; // Додайте логіку для цього поля, якщо потрібно

                    playerRepository.Add(player);
                }
            }

            FormSortByRole formSortByRole = new FormSortByRole(playerRepository);
            formSortByRole.ShowDialog();
        }
    }

    // Форма для відображення стану репозиторію.
    public class FormShowState : Form
    {
        private PlayerRepository _playerRepository;
        private TextBox txtOutput;

        public FormShowState(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Стан репозиторію";
            this.Size = new System.Drawing.Size(400, 300);

            txtOutput = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                ReadOnly = true
            };

            this.Controls.Add(txtOutput);

            ShowRepositoryState();
        }

        // Відображає поточний стан репозиторію.
        private void ShowRepositoryState()
        {
            txtOutput.Clear();
            txtOutput.AppendText("Поточний стан репозиторію:\n");
            foreach (var player in _playerRepository.GetAll())
            {
                txtOutput.AppendText($"{player.Role} (Живий: {player.IsAlive}, Виставлений: {player.IsNominated})\n");
            }
        }
    }

    // Форма для відображення відсортованих гравців за ролями.
    public class FormSortByRole : Form
    {
        private PlayerRepository _playerRepository;
        private TextBox txtOutput;

        public FormSortByRole(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Сортування за ролями";
            this.Size = new System.Drawing.Size(400, 300);

            txtOutput = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                ReadOnly = true
            };

            this.Controls.Add(txtOutput);

            ShowSortedPlayers();
        }

        // Відображає відсортованих гравців за ролями.
        private void ShowSortedPlayers()
        {
            txtOutput.Clear();
            var sortedPlayers = _playerRepository.SortBy(p => p.Role);
            txtOutput.AppendText("Гравці, відсортовані за ролями:\n");
            foreach (var player in sortedPlayers)
            {
                txtOutput.AppendText($"{player.Role} (Живий: {player.IsAlive})\n");
            }
        }
    }
}

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

    // Метод для вбивства гравця.
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

    // Перевантажений метод для вбивства гравця з причиною.
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

    // Метод для залишення коментаря.
    public void LeaveComment(string comment)
    {
        Console.WriteLine($"Мафія залишила коментар: {comment}");
    }

    // Перевантажений метод для залишення коментаря про гравця.
    public void LeaveComment(General_Props player, string comment)
    {
        Console.WriteLine($"Мафія залишила коментар про {player.Role}: {comment}");
    }

    // Реалізація методу PerformRoleAction для мафії.
    public override void PerformRoleAction()
    {
        Console.WriteLine("Мафія може вбити одного гравця за ніч.");
    }
}